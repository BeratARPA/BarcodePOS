using Database.Data;
using Database.Models;
using System;
using System.Drawing.Printing;
using System.Windows.Forms;
using WindowsFormsAppUI.Helpers;

namespace WindowsFormsAppUI.Forms.ManagementForms
{
    public partial class ManagementCategoryListForm : Form
    {
        private readonly IGenericRepository<Product> _genericRepositoryProduct = new GenericRepository<Product>(GlobalVariables.SQLContext);
        private readonly IGenericRepository<Category> _genericRepositoryCategory = new GenericRepository<Category>(GlobalVariables.SQLContext);

        public ManagementCategoryListForm()
        {
            InitializeComponent();
            UpdateUILanguage();
        }

        public void UpdateUILanguage()
        {
            label1.Text = GlobalVariables.CultureHelper.GetText("Name");
            label2.Text = GlobalVariables.CultureHelper.GetText("Printers");
            buttonSave.Text = GlobalVariables.CultureHelper.GetText("Save");
            buttonDelete.Text = GlobalVariables.CultureHelper.GetText("Delete");
            dataGridViewCategories.Columns[1].HeaderText = GlobalVariables.CultureHelper.GetText("Name");
            dataGridViewCategories.Columns[2].HeaderText = GlobalVariables.CultureHelper.GetText("Printer");
        }

        private void ManagementCategoryListForm_Load(object sender, EventArgs e)
        {
            LoadPrinters();
            LoadCategoriesDataGridView();
        }

        private void LoadPrinters()
        {
            comboBoxPrinters.Items.Clear();

            foreach (var printer in PrinterSettings.InstalledPrinters)
            {
                comboBoxPrinters.Items.Add(printer);
            }
        }

        private void LoadCategoriesDataGridView()
        {
            dataGridViewCategories.Rows.Clear();

            var categories = _genericRepositoryCategory.GetAll();
            foreach (var category in categories)
            {
                dataGridViewCategories.Rows.Add(category.CategoryId, category.Name, category.PrinterName);
            }

            dataGridViewCategories.ClearSelection();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxName.Text) || String.IsNullOrEmpty(comboBoxPrinters.Text))
            {
                return;
            }

            //Update
            if (dataGridViewCategories.SelectedRows.Count > 0)
            {
                int categoryId = Convert.ToInt32(dataGridViewCategories.CurrentRow.Cells[0].Value);

                var currentCategory = _genericRepositoryCategory.GetById(categoryId);

                currentCategory.Name = textBoxName.Text;
                currentCategory.PrinterName = comboBoxPrinters.Text;

                _genericRepositoryCategory.Update(currentCategory);

                Clear();
                LoadCategoriesDataGridView();
                return;
            }

            var categoryExist = _genericRepositoryCategory.GetAsNoTracking(x => x.Name == textBoxName.Text);
            if (categoryExist != null)
            {
                GlobalVariables.MessageBoxForm.ShowMessage(GlobalVariables.CultureHelper.GetText("RegistrationWithASimilarNameIsNotPossible!"), GlobalVariables.CultureHelper.GetText("Warning"), MessageButton.OK, MessageIcon.Warning);
                return;
            }

            //Save            
            Category category = new Category
            {
                Name = textBoxName.Text,
                PrinterName = comboBoxPrinters.Text,
                BackColor = "52,58,64",
                ForeColor = "224,224,224"
            };

            _genericRepositoryCategory.Add(category);

            Clear();
            LoadCategoriesDataGridView();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewCategories.SelectedRows.Count < 0)
            {
                return;
            }

            int categoryId = Convert.ToInt32(dataGridViewCategories.CurrentRow.Cells[0].Value);

            int productsExist = _genericRepositoryProduct.GetAllAsNoTracking(x => x.CategoryId == categoryId).Count;
            if (productsExist > 0)
            {
                GlobalVariables.MessageBoxForm.ShowMessage(GlobalVariables.CultureHelper.GetText("ThereAreProductsAssociatedWithThisCategory!"), GlobalVariables.CultureHelper.GetText("Warning"), MessageButton.OK, MessageIcon.Warning);
                return;
            }

            if (GlobalVariables.MessageBoxForm.ShowMessage(GlobalVariables.CultureHelper.GetText("AreYouSureTheEntityWillBeDeleted?"), GlobalVariables.CultureHelper.GetText("Information"), MessageButton.YesNo, MessageIcon.Information) == DialogResult.No)
            {
                return;
            }

            var currentCategory = _genericRepositoryCategory.GetById(categoryId);
            _genericRepositoryCategory.Delete(currentCategory);

            LoadCategoriesDataGridView();
        }

        private void Clear()
        {
            textBoxName.Clear();
            comboBoxPrinters.SelectedIndex = -1;
        }

        private void dataGridViewCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxName.Text = dataGridViewCategories.CurrentRow.Cells[1].Value.ToString();
            comboBoxPrinters.Text = dataGridViewCategories.CurrentRow.Cells[2].Value.ToString();
        }
    }
}
