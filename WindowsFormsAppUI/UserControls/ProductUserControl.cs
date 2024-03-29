﻿using Database.Models;
using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsAppUI.Helpers;

namespace WindowsFormsAppUI.UserControls
{
    public partial class ProductUserControl : UserControl
    {
        public int _index;
        public bool _quickMenu;
        public Product _product;
        private ContextMenuStrip _contextMenuStrip;

        public event EventHandler ProductClick;
        public event EventHandler SelectProductClick;
        public event EventHandler ProductRightClick;

        public ProductUserControl(Product product, int index, bool quickMenu = false)
        {
            InitializeComponent();

            _product = product;
            _index = index;
            _quickMenu = quickMenu;
        }

        private void ProductUserControl_Load(object sender, EventArgs e)
        {
            buttonSelectProduct.Text = GlobalVariables.CultureHelper.GetText("SelectProduct");
            labelPrice.Dock = DockStyle.None;
            labelName.Dock = DockStyle.None;

            if (_product != null)
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

                buttonSelectProduct.Dock = DockStyle.None;
                buttonSelectProduct.SendToBack();
                buttonSelectProduct.Visible = false;

                labelPrice.Dock = DockStyle.Top;
                labelName.Dock = DockStyle.Bottom;

                if (_quickMenu)
                {
                    _contextMenuStrip = new ContextMenuStrip();

                    ToolStripMenuItem removeMenuItem = new ToolStripMenuItem
                    {
                        Text = GlobalVariables.CultureHelper.GetText("Delete")
                    };
                    removeMenuItem.Click += MenuItemRemove_Click;
                    _contextMenuStrip.Items.Add(removeMenuItem);
                }
            }
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

                try
                {
                    pictureBoxImage.LoadAsync(value);
                }
                catch { }
            }
        }

        private void MenuItemRemove_Click(object sender, EventArgs e)
        {
            ProductRightClick?.Invoke(this, e);
        }

        private void labelPrice_Click(object sender, EventArgs e)
        {
            if (_quickMenu)
            {
                MouseEventArgs mouseEvent = e as MouseEventArgs;
                if (mouseEvent != null && mouseEvent.Button == MouseButtons.Right)
                {
                    _contextMenuStrip.Show(this, mouseEvent.Location);
                    return;
                }
            }

            ProductClick?.Invoke(this, e);
        }

        private void buttonSelectProduct_Click(object sender, EventArgs e)
        {
            SelectProductClick?.Invoke(this, e);
        }

        private void ProductUserControl_MouseEnter(object sender, EventArgs e)
        {
            this.Padding = new Padding(5, 5, 5, 5);
        }

        private void ProductUserControl_MouseLeave(object sender, EventArgs e)
        {
            this.Padding = new Padding(0, 0, 0, 0);
        }
    }
}
