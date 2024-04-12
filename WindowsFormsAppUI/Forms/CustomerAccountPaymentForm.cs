using Database.Data;
using Database.Models;
using System;
using System.Windows.Forms;
using WindowsFormsAppUI.Helpers;

namespace WindowsFormsAppUI.Forms
{
    public partial class CustomerAccountPaymentForm : Form
    {
        private readonly GenericRepository<Account> _genericRepositoryAccount = new GenericRepository<Account>(GlobalVariables.SQLContext);
        private readonly IGenericRepository<Payment> _genericRepositoryPayment = new GenericRepository<Payment>(GlobalVariables.SQLContext);

        private Ticket _ticket;
        private PaymentType _paymentType;
        private Customer _customer;

        public CustomerAccountPaymentForm(PaymentType paymentType = null, Customer customer = null, Ticket ticket = null)
        {
            InitializeComponent();
            UpdateUILanguage();

            _ticket = ticket;
            _paymentType = paymentType;
            _customer = customer;
        }

        private void CustomerAccountPaymentForm_Load(object sender, EventArgs e)
        {
            labelCustomer.Text = CustomerHelper.GetNameAndBalance(_customer.CustomerId);
        }

        public void UpdateUILanguage()
        {
            buttonClose.Text = GlobalVariables.CultureHelper.GetText("Close");
            buttonSave.Text = GlobalVariables.CultureHelper.GetText("Save");
            label1.Text = GlobalVariables.CultureHelper.GetText("Amount");
            label4.Text = GlobalVariables.CultureHelper.GetText("AccountName");
        }

        private async void GoCustomerAccountDetailsForm()
        {
           await NavigationManager.OpenForm(new CustomerAccountDetailsForm(_customer, _ticket), DockStyle.Fill, GlobalVariables.ShellForm.panelMain);
            GlobalVariables.ShellForm.buttonMainMenu.Enabled = false;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            GoCustomerAccountDetailsForm();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxAmount.Text))
            {
                return;
            }

            Account account = new Account
            {
                CustomerId = _customer.CustomerId,
                TicketId = 0,
                Name = $"Ödeme İşlemi [{_paymentType.Name} / {CustomerHelper.GetNameAndPhoneNumber(_customer.CustomerId)}]",
                Amount = Convert.ToDouble(textBoxAmount.Text),
                Date = DateTime.Now
            };

            _genericRepositoryAccount.Add(account);

            CustomerHelper.UpdateBalance(_customer.CustomerId, Convert.ToDouble(textBoxAmount.Text), true);

            Payment payment = new Payment
            {
                PaymentTypeId = _paymentType.PaymentTypeId,
                Name = _paymentType.Name,
                Description = CustomerHelper.GetNameAndPhoneNumber(_customer.CustomerId),
                Date = DateTime.Now,
                Amount = 0,
                TenderedAmount = Convert.ToDouble(textBoxAmount.Text),
                UserId = LoggedInUser.CurrentUser.UserId,
                TerminalName = GlobalVariables.TerminalName
            };

            _genericRepositoryPayment.Add(payment);

            GoCustomerAccountDetailsForm();
        }

        private void textBoxAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            char comma = Convert.ToChar(GlobalVariables.CultureHelper.GetText("Comma"));
            //Only allow digits (0-9) or comma (,) characters
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != comma && e.KeyChar != '\b')
            {
                e.Handled = true; //Handle (ignore) the event
            }
        }
    }
}
