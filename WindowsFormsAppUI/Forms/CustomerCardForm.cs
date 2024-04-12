using Database.Data;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsAppUI.Helpers;

namespace WindowsFormsAppUI.Forms
{
    public partial class CustomerCardForm : Form
    {
        private readonly GenericRepository<Ticket> _genericRepositoryTicket = new GenericRepository<Ticket>(GlobalVariables.SQLContext);
        private readonly GenericRepository<Product> _genericRepositoryProduct = new GenericRepository<Product>(GlobalVariables.SQLContext);

        private Ticket _ticket;
        private Customer _customer;

        public CustomerCardForm(Customer customer, Ticket ticket = null)
        {
            InitializeComponent();
            UpdateUILanguage();

            _ticket = ticket;
            _customer = customer;
        }

        private void CustomerCardForm_Load(object sender, EventArgs e)
        {
            if (_customer != null)
            {
                labelCustomer.Text = CustomerHelper.GetNameAndBalance(_customer.CustomerId);
                labelPhoneNumber.Text = _customer.PhoneNumber;
                labelAddress.Text = _customer.Address;
                labelNote.Text = _customer.Note;

                double totalSales = _genericRepositoryTicket.GetAll(x => x.CustomerId == _customer.CustomerId).Sum(x => x.TotalAmount);
                labelTotalSales.Text = string.Format("{0:C}", totalSales);

                Ticket ticket = _genericRepositoryTicket.GetAll(x => x.CustomerId == _customer.CustomerId).OrderByDescending(x => x.Date).FirstOrDefault();
                if (ticket != null)
                {
                    double total = 0;

                    labelLastOrderDate.Text = ticket.Date.ToString();

                    dataGridViewOrders.Rows.Clear();
                    foreach (Order order in ticket.Orders)
                    {
                        int productUnitOfMeasure = _genericRepositoryProduct.GetById(order.ProductId).UnitOfMeasure;
                        total += order.Price * order.Quantity;

                        dataGridViewOrders.Rows.Add(order.Quantity.ToString() + $" {UnitConvert.UnitOfMeasureToString(productUnitOfMeasure)}", order.ProductName, string.Format("{0:C}", order.Price * order.Quantity));
                    }
                    dataGridViewOrders.ClearSelection();

                    labelTotal.Text = string.Format("{0:C}", total);
                }
            }
        }

        public void UpdateUILanguage()
        {
            label1.Text = GlobalVariables.CultureHelper.GetText("CustomerName");
            label2.Text = GlobalVariables.CultureHelper.GetText("CustomerPhoneNumber");
            label3.Text = GlobalVariables.CultureHelper.GetText("CustomerAddress");
            label4.Text = GlobalVariables.CultureHelper.GetText("CustomerNote");
            label8.Text = GlobalVariables.CultureHelper.GetText("TotalSales");
            label9.Text = GlobalVariables.CultureHelper.GetText("LastOrderDate");
            label5.Text = GlobalVariables.CultureHelper.GetText("LastOrder");
            label10.Text = GlobalVariables.CultureHelper.GetText("Total");
            buttonClose.Text = GlobalVariables.CultureHelper.GetText("Close");
            buttonSelect.Text = GlobalVariables.CultureHelper.GetText("Select");
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            GoCustomersForm();
        }

        private void GoCustomersForm()
        {
            NavigationManager.OpenForm(new CustomersForm(_ticket), DockStyle.Fill, GlobalVariables.ShellForm.panelMain);
            GlobalVariables.ShellForm.buttonMainMenu.Enabled = true;

            if (_ticket != null)
                GlobalVariables.ShellForm.buttonMainMenu.Enabled = false;
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            NavigationManager.OpenForm(new POSForm(3, null, null, null, _customer), DockStyle.Fill, GlobalVariables.ShellForm.panelMain);
            GlobalVariables.ShellForm.buttonMainMenu.Enabled = true;
        }
    }
}
