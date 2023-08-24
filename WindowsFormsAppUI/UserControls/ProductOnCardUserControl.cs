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
using WindowsFormsAppUI.Helpers;

namespace WindowsFormsAppUI.UserControls
{
    public partial class ProductOnCardUserControl : UserControl
    {
        public event EventHandler Delete;
        public Order _order;
        public Product _product;

        public ProductOnCardUserControl(Order order, Product product)
        {
            InitializeComponent();

            _order = order;
            _product = product;
        }

        private void ProductOnCardUserControl_Load(object sender, EventArgs e)
        {
            Name = _order.ProductName;
            Price = _order.Price;
            Quantity = _order.Quantity;
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

        private double _quantity;
        public double Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                labelQuantity.Text = string.Format("{0:0.###}", value) + $" {UnitConvert.UnitOfMeasureToString(_product.UnitOfMeasure)}";
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Delete?.Invoke(this, e);
        }
    }
}
