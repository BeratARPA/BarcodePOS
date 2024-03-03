using Database.Data;
using Database.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsAppUI.Helpers;

namespace WindowsFormsAppUI.Forms
{
    public partial class ProductPersonalizationForm : Form
    {
        private readonly IGenericRepository<Product> _genericRepositoryProduct = new GenericRepository<Product>();

        public ProductPersonalizationForm()
        {
            InitializeComponent();
            UpdateUILanguage();
        }

        private void ProductPersonalizationForm_Load(object sender, EventArgs e)
        {
            ComboBoxColor();
            AddCategoriesDataGridView();
        }

        public void UpdateUILanguage()
        {
            buttonSave.Text = GlobalVariables.CultureHelper.GetText("Save");
            label1.Text = GlobalVariables.CultureHelper.GetText("BackgroundColor");
            label2.Text = GlobalVariables.CultureHelper.GetText("FontSize");
            label3.Text = GlobalVariables.CultureHelper.GetText("ForegroundColor");
            dataGridViewProducts.Columns[1].HeaderText = GlobalVariables.CultureHelper.GetText("Name");
            dataGridViewProducts.Columns[2].HeaderText = GlobalVariables.CultureHelper.GetText("BackgroundColor");
            dataGridViewProducts.Columns[3].HeaderText = GlobalVariables.CultureHelper.GetText("ForegroundColor");
            dataGridViewProducts.Columns[4].HeaderText = GlobalVariables.CultureHelper.GetText("FontSize");
        }

        public void AddCategoriesDataGridView()
        {
            dataGridViewProducts.Rows.Clear();

            var products = _genericRepositoryProduct.GetAll();
            for (int i = 0; i < products.Count; i++)
            {
                dataGridViewProducts.Rows.Add();
                dataGridViewProducts.Rows[i].Cells[0].Value = products[i].ProductId;
                dataGridViewProducts.Rows[i].Cells[1].Value = products[i].Name;
                dataGridViewProducts.Rows[i].Cells[2].Value = products[i].BackColor;
                dataGridViewProducts.Rows[i].Cells[3].Value = products[i].ForeColor;
                dataGridViewProducts.Rows[i].Cells[4].Value = products[i].FontSize;

                string[] backColorArgb = products[i].BackColor.Split(',');
                Color backColor = Color.FromArgb(Convert.ToInt32(backColorArgb[0]), Convert.ToInt32(backColorArgb[1]), Convert.ToInt32(backColorArgb[2]));
                dataGridViewProducts.Rows[i].Cells[2].Style.BackColor = backColor;
                dataGridViewProducts.Rows[i].Cells[2].Style.ForeColor = backColor;

                string[] foreColorArgb = products[i].ForeColor.Split(',');
                Color foreColor = Color.FromArgb(Convert.ToInt32(foreColorArgb[0]), Convert.ToInt32(foreColorArgb[1]), Convert.ToInt32(foreColorArgb[2]));
                dataGridViewProducts.Rows[i].Cells[3].Style.BackColor = foreColor;
                dataGridViewProducts.Rows[i].Cells[3].Style.ForeColor = foreColor;
            }

            dataGridViewProducts.ClearSelection();
        }

        public void ComboBoxColor()
        {
            comboBoxBackColors.Items.Add("227,6,19");
            comboBoxBackColors.Items.Add("234,91,12");
            comboBoxBackColors.Items.Add("243,146,0");
            comboBoxBackColors.Items.Add("255,237,0");
            comboBoxBackColors.Items.Add("149,193,31");
            comboBoxBackColors.Items.Add("58,170,53");
            comboBoxBackColors.Items.Add("0,150,64");
            comboBoxBackColors.Items.Add("0,154,147");
            comboBoxBackColors.Items.Add("0,159,227");
            comboBoxBackColors.Items.Add("0,105,180");
            comboBoxBackColors.Items.Add("0,72,153");
            comboBoxBackColors.Items.Add("49,39,131");
            comboBoxBackColors.Items.Add("102,36,131");
            comboBoxBackColors.Items.Add("149,27,129");
            comboBoxBackColors.Items.Add("230,0,126");
            comboBoxBackColors.Items.Add("229,0,81");
            comboBoxBackColors.Items.Add("142,101,191");
            comboBoxBackColors.Items.Add("224,224,224");
            comboBoxBackColors.Items.Add("52,58,64");

            comboBoxForeColors.Items.Add("227,6,19");
            comboBoxForeColors.Items.Add("234,91,12");
            comboBoxForeColors.Items.Add("243,146,0");
            comboBoxForeColors.Items.Add("255,237,0");
            comboBoxForeColors.Items.Add("149,193,31");
            comboBoxForeColors.Items.Add("58,170,53");
            comboBoxForeColors.Items.Add("0,150,64");
            comboBoxForeColors.Items.Add("0,154,147");
            comboBoxForeColors.Items.Add("0,159,227");
            comboBoxForeColors.Items.Add("0,105,180");
            comboBoxForeColors.Items.Add("0,72,153");
            comboBoxForeColors.Items.Add("49,39,131");
            comboBoxForeColors.Items.Add("102,36,131");
            comboBoxForeColors.Items.Add("149,27,129");
            comboBoxForeColors.Items.Add("230,0,126");
            comboBoxForeColors.Items.Add("229,0,81");
            comboBoxForeColors.Items.Add("142,101,191");
            comboBoxForeColors.Items.Add("224,224,224");
            comboBoxForeColors.Items.Add("52,58,64");
        }

        private void dataGridViewProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBoxBackColors.Text = (string)dataGridViewProducts.CurrentRow.Cells[2].Value;
            comboBoxForeColors.Text = (string)dataGridViewProducts.CurrentRow.Cells[3].Value;
            numericUpDownFontSize.Text = dataGridViewProducts.CurrentRow.Cells[4].Value.ToString();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count == 0)
            {
                GlobalVariables.MessageBoxForm.ShowMessage(GlobalVariables.CultureHelper.GetText("MakeYourChoice!"), GlobalVariables.CultureHelper.GetText("Warning"), MessageButton.OK, MessageIcon.Warning);
                return;
            }

            int productId = (int)dataGridViewProducts.CurrentRow.Cells[0].Value;
            var product = _genericRepositoryProduct.GetAll(x => x.ProductId == productId).FirstOrDefault();
            if (product != null)
            {
                _genericRepositoryProduct.UpdateColumn(product, x => x.BackColor, comboBoxBackColors.Text);
                _genericRepositoryProduct.UpdateColumn(product, x => x.ForeColor, comboBoxForeColors.Text);
                _genericRepositoryProduct.UpdateColumn(product, x => x.FontSize, Convert.ToInt32(numericUpDownFontSize.Text));

                AddCategoriesDataGridView();
            }
        }

        private void comboBoxColors_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index >= 0)
            {
                var txt = comboBoxBackColors.GetItemText(comboBoxBackColors.Items[e.Index]);
                string[] argb = txt.Split(',');
                var color = Color.FromArgb(Convert.ToInt32(argb[0]), Convert.ToInt32(argb[1]), Convert.ToInt32(argb[2]));
                var r1 = new Rectangle(e.Bounds.Left + 1, e.Bounds.Top + 1, 2 * (e.Bounds.Height - 2), e.Bounds.Height - 2);
                var r2 = Rectangle.FromLTRB(r1.Right + 2, e.Bounds.Top, e.Bounds.Right, e.Bounds.Bottom);
                using (var b = new SolidBrush(color))
                    e.Graphics.FillRectangle(b, r1);
                e.Graphics.DrawRectangle(Pens.Black, r1);
                TextRenderer.DrawText(e.Graphics, txt, comboBoxBackColors.Font, r2, comboBoxBackColors.ForeColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
            }
        }
    }
}
