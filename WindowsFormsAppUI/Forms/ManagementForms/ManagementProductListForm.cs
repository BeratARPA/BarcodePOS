using Database.Data;
using Database.Models;
using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsAppUI.Helpers;

namespace WindowsFormsAppUI.Forms.ManagementForms
{
    public partial class ManagementProductListForm : Form
    {
        private readonly IGenericRepository<Product> _genericRepositoryProduct = new GenericRepository<Product>(GlobalVariables.SQLContext);
        private readonly IGenericRepository<Category> _genericRepositoryCategory = new GenericRepository<Category>(GlobalVariables.SQLContext);

        public ManagementProductListForm()
        {
            InitializeComponent();
            UpdateUILanguage();
        }

        public void UpdateUILanguage()
        {
            label1.Text = GlobalVariables.CultureHelper.GetText("Barcode");
            label2.Text = GlobalVariables.CultureHelper.GetText("Categories");
            label3.Text = GlobalVariables.CultureHelper.GetText("Name");
            label4.Text = GlobalVariables.CultureHelper.GetText("Amount");
            label5.Text = GlobalVariables.CultureHelper.GetText("Units");
            buttonBrowse.Text = GlobalVariables.CultureHelper.GetText("Browse");
            buttonSave.Text = GlobalVariables.CultureHelper.GetText("Save");
            buttonDelete.Text = GlobalVariables.CultureHelper.GetText("Delete");
            dataGridViewProducts.Columns[2].HeaderText = GlobalVariables.CultureHelper.GetText("Name");
            dataGridViewProducts.Columns[3].HeaderText = GlobalVariables.CultureHelper.GetText("Barcode");
            dataGridViewProducts.Columns[4].HeaderText = GlobalVariables.CultureHelper.GetText("Category");
            dataGridViewProducts.Columns[5].HeaderText = GlobalVariables.CultureHelper.GetText("Name");
            dataGridViewProducts.Columns[6].HeaderText = GlobalVariables.CultureHelper.GetText("Amount");
            dataGridViewProducts.Columns[7].HeaderText = GlobalVariables.CultureHelper.GetText("Unit");
        }

        private void ManagementProductListForm_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadProductsDataGridView();
        }

        private void LoadProductsDataGridView()
        {
            dataGridViewProducts.Rows.Clear();

            var products = _genericRepositoryProduct.GetAll();
            foreach (var product in products)
            {
                dataGridViewProducts.Rows.Add(product.ProductId, product.CategoryId, product.ImageURL != "" ? Image.FromFile(product.ImageURL) : Properties.Resources.noPhoto64px, product.Barcode, product.Category.Name, product.Name, product.Price, UnitConvert.UnitOfMeasureToString(product.UnitOfMeasure), product.ImageURL);
            }

            dataGridViewProducts.ClearSelection();
        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxName.Text) || String.IsNullOrEmpty(comboBoxCategories.Text) || String.IsNullOrEmpty(comboBoxUnits.Text) || String.IsNullOrEmpty(textBoxPrice.Text))
            {
                return;
            }

            string imageURL = "";
            if (pictureBoxImage.Image != null)
                imageURL = pictureBoxImage.ImageLocation;

            //Update
            if (dataGridViewProducts.SelectedRows.Count > 0)
            {
                int productId = Convert.ToInt32(dataGridViewProducts.CurrentRow.Cells[0].Value);

                var currentProduct = _genericRepositoryProduct.GetById(productId);

                currentProduct.CategoryId = Convert.ToInt32(comboBoxCategories.SelectedValue);
                currentProduct.Barcode = textBoxBarcode.Text;
                currentProduct.Name = textBoxName.Text;
                currentProduct.Price = Convert.ToDouble(textBoxPrice.Text);
                currentProduct.UnitOfMeasure = comboBoxUnits.SelectedIndex;
                currentProduct.ImageURL = imageURL;

                _genericRepositoryProduct.Update(currentProduct);

                Clear();
                LoadProductsDataGridView();
                return;
            }

            var productExist = _genericRepositoryProduct.GetAsNoTracking(x => x.Name == textBoxName.Text);
            if (productExist != null)
            {
                GlobalVariables.MessageBoxForm.ShowMessage(GlobalVariables.CultureHelper.GetText("RegistrationWithASimilarNameIsNotPossible!"), GlobalVariables.CultureHelper.GetText("Warning"), MessageButton.OK, MessageIcon.Warning);
                return;
            }

            //Save            
            Product product = new Product
            {
                CategoryId = Convert.ToInt32(comboBoxCategories.SelectedValue),
                Index = 0,
                Barcode = textBoxBarcode.Text,
                Name = textBoxName.Text,
                Price = Convert.ToDouble(textBoxPrice.Text),
                ImageURL = imageURL,
                BackColor = "52,58,64",
                ForeColor = "224,224,224",
                UnitOfMeasure = 1
            };

            _genericRepositoryProduct.Add(product);

            Clear();
            LoadProductsDataGridView();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count < 0)
            {
                return;
            }

            if (GlobalVariables.MessageBoxForm.ShowMessage(GlobalVariables.CultureHelper.GetText("AreYouSureTheEntityWillBeDeleted?"), GlobalVariables.CultureHelper.GetText("Information"), MessageButton.YesNo, MessageIcon.Information) == DialogResult.No)
            {
                return;
            }

            int productId = Convert.ToInt32(dataGridViewProducts.CurrentRow.Cells[0].Value);
            var currentProduct = _genericRepositoryProduct.GetById(productId);
            _genericRepositoryProduct.Delete(currentProduct);

            LoadProductsDataGridView();
        }

        private void LoadCategories()
        {
            comboBoxCategories.Items.Clear();

            comboBoxCategories.DisplayMember = "Name";
            comboBoxCategories.ValueMember = "CategoryId";

            comboBoxCategories.DataSource = _genericRepositoryCategory.GetAll();
        }

        private void Clear()
        {
            textBoxBarcode.Clear();
            textBoxName.Clear();
            textBoxPrice.Clear();
            pictureBoxImage.ImageLocation = null;
            comboBoxUnits.SelectedIndex = -1;
            comboBoxCategories.SelectedIndex = -1;
        }

        private void dataGridViewProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //pictureBoxImage.ImageLocation = dataGridViewProducts.CurrentRow.Cells[8].Value.ToString();
            textBoxBarcode.Text = dataGridViewProducts.CurrentRow.Cells[3].Value.ToString();
            comboBoxCategories.Text = dataGridViewProducts.CurrentRow.Cells[4].Value.ToString();
            textBoxName.Text = dataGridViewProducts.CurrentRow.Cells[5].Value.ToString();
            textBoxPrice.Text = dataGridViewProducts.CurrentRow.Cells[6].Value.ToString();
            comboBoxUnits.Text = dataGridViewProducts.CurrentRow.Cells[7].Value.ToString();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;

                pictureBoxImage.ImageLocation = selectedFilePath;
            }
        }

        private void textBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            char comma = Convert.ToChar(GlobalVariables.CultureHelper.GetText("Comma"));
            //Only allow digits (0-9) or comma (,) characters
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != comma && e.KeyChar != '\b')
            {
                e.Handled = true; //Handle (ignore) the event
            }
        }
    }
}
