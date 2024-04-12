using Database.Data;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WindowsFormsAppUI.Helpers;
using WindowsFormsAppUI.UserControls;

namespace WindowsFormsAppUI.Forms
{
    public partial class CustomerAccountDetailsForm : Form
    {
        private readonly IGenericRepository<Ticket> _genericRepositoryTicket = new GenericRepository<Ticket>(GlobalVariables.SQLContext);
        private readonly GenericRepository<Account> _genericRepositoryAccount = new GenericRepository<Account>(GlobalVariables.SQLContext);
        private readonly IGenericRepository<PaymentType> _genericRepositoryPaymentType = new GenericRepository<PaymentType>(GlobalVariables.SQLContext);

        private Ticket _ticket;
        private Customer _customer;
        private List<PaymentType> _paymentTypes = new List<PaymentType>();

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

            _paymentTypes = _genericRepositoryPaymentType.GetAll();
            CreatePayments(_paymentTypes);
        }

        public void UpdateUILanguage()
        {
            label1.Text = GlobalVariables.CultureHelper.GetText("Start");
            label2.Text = GlobalVariables.CultureHelper.GetText("End");
            buttonClose.Text = GlobalVariables.CultureHelper.GetText("Close");
            buttonFindTicket.Text = GlobalVariables.CultureHelper.GetText("FindTicket");
            dataGridViewAccounts.Columns[3].HeaderText = GlobalVariables.CultureHelper.GetText("Date");
            dataGridViewAccounts.Columns[4].HeaderText = GlobalVariables.CultureHelper.GetText("Description");
            dataGridViewAccounts.Columns[5].HeaderText = GlobalVariables.CultureHelper.GetText("Total");
            label5.Text = GlobalVariables.CultureHelper.GetText("TotalBalance");
        }

        public void CreatePayments(List<PaymentType> paymentTypes)
        {
            flowLayoutPanelPayment.Controls.Clear();

            foreach (PaymentType paymentType in paymentTypes)
            {
                PaymentTypeUserControl paymentTypeUserControl = new PaymentTypeUserControl(paymentType)
                {
                    Width = 125,
                    Height = 100
                };

                paymentTypeUserControl.PaymentTypeClick += PaymentTypeUserControl_Click;

                flowLayoutPanelPayment.Controls.Add(paymentTypeUserControl);
            }
        }

        private async void PaymentTypeUserControl_Click(object sender, EventArgs e)
        {
            PaymentTypeUserControl paymentTypeUserControl = (PaymentTypeUserControl)sender;

           await NavigationManager.OpenForm(new CustomerAccountPaymentForm(paymentTypeUserControl._paymentType, _customer == null ? null : _customer, _ticket == null ? null : _ticket), DockStyle.Fill, GlobalVariables.ShellForm.panelMain);
            GlobalVariables.ShellForm.buttonMainMenu.Enabled = false;
        }

        public void AddAccountsDataGridView()
        {
            dataGridViewAccounts.Rows.Clear();

            DateTime startDate = dateTimePickerStart.DateTime.Date;
            DateTime endDate = dateTimePickerEnd.DateTime.Date;
            endDate = endDate.AddDays(1);

            List<Account> accounts = _genericRepositoryAccount.GetAllAsNoTracking(x => x.Date >= startDate && x.Date <= endDate && x.CustomerId == _customer.CustomerId);
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

        private async void buttonFindTicket_Click(object sender, EventArgs e)
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
                       await NavigationManager.OpenForm(new POSForm(3, ticket, null, null, _customer), DockStyle.Fill, GlobalVariables.ShellForm.panelMain);
                        GlobalVariables.ShellForm.buttonMainMenu.Enabled = false;
                    }
                }
            }
        }

        private async void GoCustomersForm()
        {
          await  NavigationManager.OpenForm(new CustomersForm(_ticket), DockStyle.Fill, GlobalVariables.ShellForm.panelMain);
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
