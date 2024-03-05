using Database.Data;
using Database.Models;
using System;
using System.Windows.Forms;
using WindowsFormsAppUI.Helpers;

namespace WindowsFormsAppUI.Forms
{
    public partial class SaveCustomerForm : Form
    {
        private readonly GenericRepository<Customer> _genericRepositoryCustomer = new GenericRepository<Customer>(GlobalVariables.SQLContext);

        private Ticket _ticket;
        private Customer _customer;

        public SaveCustomerForm(string name = "", Customer customer = null, Ticket ticket = null)
        {
            InitializeComponent();
            UpdateUILanguage();

            _ticket = ticket;
            _customer = customer;
            textBoxName.Text = name;
        }

        private void SaveCustomerForm_Load(object sender, EventArgs e)
        {
            if (_customer != null)
            {
                textBoxName.Text = _customer.Name;
                textBoxPhoneNumber.Text = _customer.PhoneNumber;
                textBoxAddress.Text = _customer.Address;
                textBoxNote.Text = _customer.Note;
            }
        }

        public void UpdateUILanguage()
        {
            label1.Text = GlobalVariables.CultureHelper.GetText("CustomerName");
            label2.Text = GlobalVariables.CultureHelper.GetText("CustomerPhoneNumber");
            label3.Text = GlobalVariables.CultureHelper.GetText("CustomerAddress");
            label4.Text = GlobalVariables.CultureHelper.GetText("CustomerNote");
            buttonClose.Text = GlobalVariables.CultureHelper.GetText("Close");
            buttonSave.Text = GlobalVariables.CultureHelper.GetText("Save");
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            GoCustomersForm();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxName.Text) && String.IsNullOrEmpty(textBoxPhoneNumber.Text) && String.IsNullOrEmpty(textBoxAddress.Text))
            {
                GoCustomersForm();
                return;
            }

            if (_customer != null)
            {
                _customer.Name = textBoxName.Text;
                _customer.PhoneNumber = textBoxPhoneNumber.Text;
                _customer.Address = textBoxAddress.Text;
                _customer.Note = textBoxNote.Text;
                _customer.LastUpdateDateTime = DateTime.Now;

                _genericRepositoryCustomer.Update(_customer);

                GoCustomersForm();
            }

            var customerExist = _genericRepositoryCustomer.GetAsNoTracking(x => x.PhoneNumber == textBoxPhoneNumber.Text);
            if (customerExist != null)
            {
                GlobalVariables.MessageBoxForm.ShowMessage(string.Format(GlobalVariables.CultureHelper.GetText("ThereIsACustomerRegisteredAt"), customerExist.PhoneNumber), GlobalVariables.CultureHelper.GetText("Warning"), MessageButton.OK, MessageIcon.Warning);
                return;
            }

            if (!String.IsNullOrEmpty(textBoxPhoneNumber.Text))
            {
                Customer customer = new Customer
                {
                    Name = textBoxName.Text,
                    PhoneNumber = textBoxPhoneNumber.Text,
                    Address = textBoxAddress.Text,
                    Note = textBoxNote.Text,
                    CreatedDateTime = DateTime.Now,
                    LastUpdateDateTime = DateTime.Now,
                };

                _genericRepositoryCustomer.Add(customer);

                GoCustomersForm();
            }
        }

        private void GoCustomersForm()
        {
            NavigationManager.OpenForm(new CustomersForm(_ticket), DockStyle.Fill, GlobalVariables.ShellForm.panelMain);
            GlobalVariables.ShellForm.buttonMainMenu.Enabled = true;

            if (_ticket != null)
                GlobalVariables.ShellForm.buttonMainMenu.Enabled = false;
        }
    }
}
