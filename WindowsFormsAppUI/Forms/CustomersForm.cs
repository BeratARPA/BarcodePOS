using Database.Data;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsAppUI.Helpers;

namespace WindowsFormsAppUI.Forms
{
    public partial class CustomersForm : Form
    {
        private readonly GenericRepository<Customer> _genericRepositoryCustomer = new GenericRepository<Customer>(GlobalVariables.SQLContext);

        private Ticket _ticket;
        private List<Customer> _customers = new List<Customer>();

        public CustomersForm(Ticket ticket = null)
        {
            InitializeComponent();
            UpdateUILanguage();

            _ticket = ticket;
        }

        private void CustomersForm_Load(object sender, EventArgs e)
        {
            _customers = _genericRepositoryCustomer.GetAllAsNoTracking();

            GetCustomers();
            paginationUserControl1.TotalRecords = _customers.Count;

            Fill();
        }

        public void UpdateUILanguage()
        {
            dataGridViewCustomers.Columns[1].HeaderText = GlobalVariables.CultureHelper.GetText("CustomerName");
            dataGridViewCustomers.Columns[2].HeaderText = GlobalVariables.CultureHelper.GetText("CustomerPhoneNumber");
            dataGridViewCustomers.Columns[3].HeaderText = GlobalVariables.CultureHelper.GetText("CustomerAddress");
            dataGridViewCustomers.Columns[4].HeaderText = GlobalVariables.CultureHelper.GetText("CustomerNote");
            buttonSelect.Text = GlobalVariables.CultureHelper.GetText("Select");
            buttonUpdate.Text = GlobalVariables.CultureHelper.GetText("Update");
            buttonSave.Text = GlobalVariables.CultureHelper.GetText("Save");
            buttonSearch.Text = GlobalVariables.CultureHelper.GetText("Search");
            buttonAccountDetails.Text = GlobalVariables.CultureHelper.GetText("AccountDetails");
            buttonCustomerCard.Text = GlobalVariables.CultureHelper.GetText("CustomerCard");
        }

        public void AddCustomerDataGridView(List<Customer> customers)
        {
            dataGridViewCustomers.Rows.Clear();

            customers = customers.Skip(paginationUserControl1.PageSize * (paginationUserControl1.CurrentPage - 1)).Take(paginationUserControl1.PageSize).ToList();
            foreach (var customer in customers)
            {
                dataGridViewCustomers.Rows.Add(customer.CustomerId, customer.Name, customer.PhoneNumber, customer.Address, customer.Note);
            }

            dataGridViewCustomers.ClearSelection();
        }

        public List<Customer> GetCustomers()
        {
            _customers = _genericRepositoryCustomer.GetAllAsNoTracking();

            if (string.IsNullOrEmpty(textBoxSearchCustomer.Text))
                return _customers;

            _customers = _customers.Where(x => x.Name.ToLower().Contains(textBoxSearchCustomer.Text.ToLower()) || x.PhoneNumber.Contains(textBoxSearchCustomer.Text) || x.Address.ToLower().Contains(textBoxSearchCustomer.Text.ToLower())).ToList();
            return _customers;
        }

        public void Fill()
        {
            paginationUserControl1.TotalRecords = _customers.Count;
            paginationUserControl1.Update();
            AddCustomerDataGridView(_customers);
        }

        private void paginationUserControl1_GoFirst(object sender, EventArgs e)
        {
            Fill();
        }

        private void paginationUserControl1_GoLast(object sender, EventArgs e)
        {
            Fill();
        }

        private void paginationUserControl1_GoNext(object sender, EventArgs e)
        {
            Fill();
        }

        private void paginationUserControl1_GoPrevious(object sender, EventArgs e)
        {
            Fill();
        }

        private void paginationUserControl1_PageSizeChanged(object sender, EventArgs e)
        {
            Fill();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            GetCustomers();
            Fill();
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
          await  NavigationManager.OpenForm(new SaveCustomerForm(textBoxSearchCustomer.Text, "", null, _ticket == null ? null : _ticket), DockStyle.Fill, GlobalVariables.ShellForm.panelMain);
            GlobalVariables.ShellForm.buttonMainMenu.Enabled = false;
        }

        private async void buttonSelect_Click(object sender, EventArgs e)
        {
            if (dataGridViewCustomers.SelectedRows.Count <= 0)
            {
                return;
            }

            int customerId = Convert.ToInt32(dataGridViewCustomers.CurrentRow.Cells[0].Value);
            var customer = _genericRepositoryCustomer.Get(x => x.CustomerId == customerId);
            if (customer != null)
            {
                if (_ticket != null)
                    _ticket.CustomerId = customerId;

               await NavigationManager.OpenForm(new POSForm(3, _ticket == null ? null : _ticket, null, null, customer), DockStyle.Fill, GlobalVariables.ShellForm.panelMain);
                GlobalVariables.ShellForm.buttonMainMenu.Enabled = false;
            }
        }

        private async void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewCustomers.SelectedRows.Count <= 0)
            {
                return;
            }

            int customerId = Convert.ToInt32(dataGridViewCustomers.CurrentRow.Cells[0].Value);
            var customer = _genericRepositoryCustomer.Get(x => x.CustomerId == customerId);
            if (customer != null)
            {
               await NavigationManager.OpenForm(new SaveCustomerForm("", "", customer, _ticket == null ? null : _ticket), DockStyle.Fill, GlobalVariables.ShellForm.panelMain);
                GlobalVariables.ShellForm.buttonMainMenu.Enabled = false;
            }
        }

        private async void buttonAccountDetails_Click(object sender, EventArgs e)
        {
            if (dataGridViewCustomers.SelectedRows.Count <= 0)
            {
                return;
            }

            int customerId = Convert.ToInt32(dataGridViewCustomers.CurrentRow.Cells[0].Value);
            var customer = _genericRepositoryCustomer.Get(x => x.CustomerId == customerId);
            if (customer.IsAccount)
            {
              await  NavigationManager.OpenForm(new CustomerAccountDetailsForm(customer, _ticket == null ? null : _ticket), DockStyle.Fill, GlobalVariables.ShellForm.panelMain);
                GlobalVariables.ShellForm.buttonMainMenu.Enabled = false;
            }
        }

        private async void buttonCustomerCard_Click(object sender, EventArgs e)
        {
            if (dataGridViewCustomers.SelectedRows.Count <= 0)
            {
                return;
            }

            int customerId = Convert.ToInt32(dataGridViewCustomers.CurrentRow.Cells[0].Value);
            var customer = _genericRepositoryCustomer.Get(x => x.CustomerId == customerId);
            if (customer != null)
            {
               await NavigationManager.OpenForm(new CustomerCardForm(customer, _ticket == null ? null : _ticket), DockStyle.Fill, GlobalVariables.ShellForm.panelMain);
                GlobalVariables.ShellForm.buttonMainMenu.Enabled = false;
            }
        }
    }
}
