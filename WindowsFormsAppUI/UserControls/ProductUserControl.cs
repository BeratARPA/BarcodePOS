using Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppUI.UserControls
{
    public partial class ProductUserControl : UserControl
    {
        public Product _product;
        public event EventHandler ProductClick;

        public ProductUserControl(Product product)
        {
            InitializeComponent();

            _product = product;
        }

        private void ProductUserControl_Load(object sender, EventArgs e)
        {
            Name = _product.Name;
            Price = _product.Price;
            Image = _product.ImageURL;

            string[] backColorArgb = _product.BackColor.Split(',');
            string[] foreColorArgb = _product.ForeColor.Split(',');

            this.BackColor = Color.FromArgb(50, Convert.ToInt32(backColorArgb[0]), Convert.ToInt32(backColorArgb[1]), Convert.ToInt32(backColorArgb[2]));

            labelName.Parent = pictureBoxImage;
            labelName.BackColor = Color.FromArgb(50, Convert.ToInt32(backColorArgb[0]), Convert.ToInt32(backColorArgb[1]), Convert.ToInt32(backColorArgb[2]));
            labelName.ForeColor = Color.FromArgb(Convert.ToInt32(foreColorArgb[0]), Convert.ToInt32(foreColorArgb[1]), Convert.ToInt32(foreColorArgb[2]));
            labelName.Font = new Font("Microsoft Sans Serif", _product.FontSize);

            labelPrice.Parent = pictureBoxImage;
            labelPrice.BackColor = Color.FromArgb(50, Convert.ToInt32(backColorArgb[0]), Convert.ToInt32(backColorArgb[1]), Convert.ToInt32(backColorArgb[2]));
            labelPrice.ForeColor = Color.FromArgb(Convert.ToInt32(foreColorArgb[0]), Convert.ToInt32(foreColorArgb[1]), Convert.ToInt32(foreColorArgb[2]));         
            labelPrice.Font = new Font("Microsoft Sans Serif", _product.FontSize);
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                labelName.Text = value;
            }
        }

        private double _price;
        public double Price
        {
            get { return _price; }
            set
            {
                _price = value;
                labelPrice.Text = string.Format("{0:C}", value);
            }
        }

        private string _image;
        public string Image
        {
            get { return _image; }
            set
            {
                _image = value;
                pictureBoxImage.LoadAsync(value);
            }
        }

        private void labelPrice_Click(object sender, EventArgs e)
        {
            ProductClick?.Invoke(this, e);
        }
    }
}
