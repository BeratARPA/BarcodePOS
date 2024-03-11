using Database.Data;
using Database.Models;
using System;
using System.Windows.Forms;
using WindowsFormsAppUI.Helpers;

namespace WindowsFormsAppUI.Forms
{
    public partial class QuickMenuSelectProductForm : Form
    {
        private readonly GenericRepository<Product> _genericRepositoryProduct = new GenericRepository<Product>(GlobalVariables.SQLContext);

        private readonly FileOperations<string> fileOperations = new FileOperations<string>(FolderLocations.barcodePOSFolderPath + "QuickMenu.txt");

        private int _index;

        public QuickMenuSelectProductForm(int index)
        {
            InitializeComponent();
            UpdateUILanguage();

            _index = index;

            this.ResizeBegin += (s, e) =>
            {
                this.Opacity = 0.50;
                this.SuspendLayout();
            };

            this.ResizeEnd += (s, e) =>
            {
                this.Opacity = 1;
                this.ResumeLayout(true);
            };
        }

        private void QuickMenuSelectProductForm_Load(object sender, EventArgs e)
        {
            AddProductDataGridView();
        }

        public void UpdateUILanguage()
        {
            this.Text = GlobalVariables.CultureHelper.GetText("SelectProduct");
            buttonSave.Text = GlobalVariables.CultureHelper.GetText("Save");
            dataGridViewProducts.Columns[1].HeaderText = GlobalVariables.CultureHelper.GetText("Product");
            dataGridViewProducts.Columns[2].HeaderText = GlobalVariables.CultureHelper.GetText("Barcode");
            dataGridViewProducts.Columns[3].HeaderText = GlobalVariables.CultureHelper.GetText("Amount");
        }

        public void AddProductDataGridView()
        {
            dataGridViewProducts.Rows.Clear();

            var products = _genericRepositoryProduct.GetAll();
            foreach (var product in products)
            {
                dataGridViewProducts.Rows.Add(product.ProductId, product.Name, product.Barcode, string.Format("{0:C}", product.Price));
            }

            dataGridViewProducts.ClearSelection();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count <= 0)
            {
                return;
            }

            string productId = dataGridViewProducts.CurrentRow.Cells[0].Value.ToString();

            string text = "#" + _index + "/" + productId;

            string file = fileOperations.ReadFile();
            string[] menus = file.Split('#');
            foreach (var menu in menus)
            {
                if (!string.IsNullOrEmpty(menu))
                {
                    string[] properties = menu.Split('/');

                    if (Convert.ToInt32(properties[1]) == Convert.ToInt32(productId))
                    {
                        fileOperations.FindAndRemoveLine("#" + menu);
                    }
                }
            }

            fileOperations.CreateFile();
            fileOperations.WriteToFile(text, true);

            POSForm _posForm = (POSForm)GetForm.Get("POSForm");
            _posForm.CreateQuickMenu(_posForm.GetQuickMenu());
            this.Close();
        }
    }
}
