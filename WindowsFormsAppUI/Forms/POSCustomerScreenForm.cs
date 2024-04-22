using Database.Data;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsAppUI.Helpers;
using WindowsFormsAppUI.UserControls;

namespace WindowsFormsAppUI.Forms
{
    public partial class POSCustomerScreenForm : Form
    {
        private readonly IGenericRepository<Product> _genericRepositoryProduct = new GenericRepository<Product>(GlobalVariables.SQLContext);

        public Ticket _ticket = new Ticket();

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000; //WS_EX_COMPOSITED
                return handleParam;
            }
        }

        public POSCustomerScreenForm(Ticket ticket = null)
        {
            InitializeComponent();
            UpdateUILanguage();

            _ticket = ticket;
        }

        private void POSCustomerScreenForm_Load(object sender, EventArgs e)
        {
            FormLocation();
            ContainerCollapsed();
        }

        public void UpdateUILanguage()
        {
            label4.Text = GlobalVariables.CultureHelper.GetText("TicketTotal");
            label1.Text = GlobalVariables.CultureHelper.GetText("Balance");
        }

        public void CreateNewProductOnCard(List<Order> orders)
        {
            flowLayoutPanelOrders.Controls.Clear();

            foreach (var order in orders)
            {
                var product = _genericRepositoryProduct.GetById(order.ProductId);
                ProductOnCardUserControl newProductOnCard = new ProductOnCardUserControl(order, product);
                flowLayoutPanelOrders.Controls.Add(newProductOnCard);
            }

            if (orders.Count == 0)
                tableLayoutPanel1.ColumnStyles[1].Width = 0;
            else
                tableLayoutPanel1.ColumnStyles[1].Width = 420;
        }

        public void CalculateTotalBalance(double totalBalance = 0, double discount = 0)
        {
            labelTicketTotal.Text = string.Format("{0:C}", totalBalance);

            //Discount
            if (discount != 0)
            {
                tableLayoutPanelLabels.RowStyles[1].Height = 33;
                tableLayoutPanelLabels.RowStyles[2].Height = 33;
                totalBalance = DiscountHelper.Calculate(totalBalance, discount);

                labelDiscountPercent.Text = string.Format(GlobalVariables.CultureHelper.GetText("Discount"), discount);
                labelDiscount.Text = string.Format("({0:C})", DiscountHelper.discountAmount);
            }
            else
            {
                tableLayoutPanelLabels.RowStyles[1].Height = 0;
                tableLayoutPanelLabels.RowStyles[2].Height = 0;
            }

            labelBalance.Text = string.Format("{0:C}", totalBalance);

            //Return
            if (totalBalance == 0)
            {
                tableLayoutPanelMiddle.RowStyles[1].Height = 0;
                tableLayoutPanel1.ColumnStyles[1].Width = 0;
                return;
            }

            tableLayoutPanelMiddle.RowStyles[1].Height = 85;
        }

        public void ContainerCollapsed()
        {
            if (_ticket != null)
            {
                tableLayoutPanel1.ColumnStyles[1].Width = 420;
            }
            else
            {
                tableLayoutPanel1.ColumnStyles[1].Width = 0;
            }
        }

        private void FormLocation()
        {
            var notPrimaryScreen = Screen.AllScreens.Where(x => x.Primary == false).FirstOrDefault();
            if (notPrimaryScreen != null)
            {
                this.Location = notPrimaryScreen.WorkingArea.Location;
                this.WindowState = FormWindowState.Maximized;
                this.TopMost = true;
                this.BringToFront();
            }
            else
            {
                this.Close();
            }
        }
    }
}
