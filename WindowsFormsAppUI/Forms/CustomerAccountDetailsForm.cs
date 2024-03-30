using Database.Data;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WindowsFormsAppUI.Helpers;

namespace WindowsFormsAppUI.Forms
{
    public partial class CustomerAccountDetailsForm : Form
    {
        private readonly IGenericRepository<Ticket> _genericRepositoryTicket = new GenericRepository<Ticket>(GlobalVariables.SQLContext);
        private readonly GenericRepository<Account> _genericRepositoryAccount = new GenericRepository<Account>(GlobalVariables.SQLContext);

        private Ticket _ticket;
        private Customer _customer;

        public CustomerAccountDetailsForm(Customer customer = null, Ticket ticket = null)
        {
            InitializeComponent();
            UpdateUILanguage();

            _ticket = ticket;
            _customer = customer;
        }

        private void CustomerAccountDetailsForm_Load(object sender, EventArgs e)
        {
            AddAccountsDataGridView();

            dateTimePickerStart.DateTime = DateTime.Now;
            dateTimePickerEnd.DateTime = DateTime.Now;

            labelCustomer.Text = CustomerHelper.GetNameAndBalance(_customer.CustomerId);
            labelTotalAmount.Text = _customer.Balance.ToString();
        }

        public void UpdateUILanguage()
        {
            buttonClose.Text = GlobalVariables.CultureHelper.GetText("Close");
        }

        public void AddAccountsDataGridView()
        {
            dataGridViewAccounts.Rows.Clear();

            DateTime startDate = dateTimePickerStart.DateTime.Date;
            DateTime endDate = dateTimePickerEnd.DateTime.Date.Date;
            endDate = endDate.AddDays(1);

            List<Account> accounts = _genericRepositoryAccount.GetAllAsNoTracking(x => x.Date >= startDate.Date && x.Date <= endDate.Date && x.CustomerId == _customer.CustomerId);
            foreach (Account account in accounts)
            {
                dataGridViewAccounts.Rows.Add(account.AccountId, account.CustomerId, account.TicketId, account.Date, account.Name, string.Format("{0:C}", account.Amount));
            }

            dataGridViewAccounts.ClearSelection();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            GoCustomersForm();
        }

        private void buttonFindTicket_Click(object sender, EventArgs e)
        {
            if (_ticket == null)
            {
                if (dataGridViewAccounts.SelectedRows.Count <= 0)
                {
                    return;
                }

                int ticketId = Convert.ToInt32(dataGridViewAccounts.CurrentRow.Cells[2].Value);
                if (ticketId != 0)
                {
                    var ticket = _genericRepositoryTicket.Get(x => x.TicketId == ticketId);
                    if (ticket != null)
                    {
                        NavigationManager.OpenForm(new POSForm(3, ticket, null, null, _customer), DockStyle.Fill, GlobalVariables.ShellForm.panelMain);
                        GlobalVariables.ShellForm.buttonMainMenu.Enabled = false;
                    }
                }
            }
        }

        private void GoCustomersForm()
        {
            NavigationManager.OpenForm(new CustomersForm(_ticket), DockStyle.Fill, GlobalVariables.ShellForm.panelMain);
            GlobalVariables.ShellForm.buttonMainMenu.Enabled = true;

            if (_ticket != null)
                GlobalVariables.ShellForm.buttonMainMenu.Enabled = false;
        }

        private void dateTimePickerStart_EditValueChanged(object sender, EventArgs e)
        {
            AddAccountsDataGridView();
        }
    }
}
