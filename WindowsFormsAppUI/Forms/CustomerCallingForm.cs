using Database.Data;
using Database.Models;
using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsAppUI.Enums;
using WindowsFormsAppUI.Helpers;

namespace WindowsFormsAppUI.Forms
{
    public partial class CustomerCallingForm : Form
    {
        private readonly GenericRepository<Customer> _genericRepositoryCustomer = new GenericRepository<Customer>(GlobalVariables.SQLContext);

        private Customer _customer;
        private string _phoneNumber;

        public CustomerCallingForm()
        {
            InitializeComponent();
        }

        public CustomerCallingEnum action;
        private int x, y;

        private void CustomerCallingForm_Click(object sender, EventArgs e)
        {
            if (_customer != null)
            {
                NavigationManager.OpenForm(new CustomerCardForm(_customer), DockStyle.Fill, GlobalVariables.ShellForm.panelMain);
                GlobalVariables.ShellForm.buttonMainMenu.Enabled = false;
            }
            else
            {
                NavigationManager.OpenForm(new SaveCustomerForm("", _phoneNumber, null, null), DockStyle.Fill, GlobalVariables.ShellForm.panelMain);
                GlobalVariables.ShellForm.buttonMainMenu.Enabled = false;
            }

            action = CustomerCallingEnum.Close;
            this.timer.Interval = 1;
        }

        public void ShowAlert(string phoneNumber)
        {
            _phoneNumber = phoneNumber;

            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string formName;

            for (int i = 1; i < 10; i++)
            {
                formName = "CustomerCallingForm" + i.ToString();
                CustomerCallingForm frm = (CustomerCallingForm)Application.OpenForms[formName];

                if (frm == null)
                {
                    this.Name = formName;
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i - 5 * i;
                    this.Location = new Point(this.x, this.y);
                    break;
                }
            }

            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;

            _customer = _genericRepositoryCustomer.Get(x => x.PhoneNumber == phoneNumber);
            if (_customer != null)
            {
                labelPhoneNumber.Text = _customer.Name;
                labelDate.Text = DateTime.Now.ToString();
                labelDescription.Text = string.Format(GlobalVariables.CultureHelper.GetText("IsCalling"), _customer.Name);
            }
            else
            {
                labelPhoneNumber.Text = phoneNumber;
                labelDate.Text = DateTime.Now.ToString();
                labelDescription.Text = string.Format(GlobalVariables.CultureHelper.GetText("IsCalling"), phoneNumber);
            }

            this.Show();
            this.action = CustomerCallingEnum.Start;
            this.timer.Interval = 1;
            this.timer.Start();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            action = CustomerCallingEnum.Close;
            this.timer.Interval = 1;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.TopMost = true;

            switch (action)
            {
                case CustomerCallingEnum.Wait:

                    timer.Interval = 60000;
                    action = CustomerCallingEnum.Close;

                    break;

                case CustomerCallingEnum.Start:

                    timer.Interval = 1;
                    this.Opacity += 0.1;

                    if (this.x < this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        if (this.Opacity == 1.0)
                        {
                            action = CustomerCallingEnum.Wait;
                        }
                    }

                    break;

                case CustomerCallingEnum.Close:

                    timer.Interval = 1;
                    this.Opacity -= 0.1;

                    this.Left += 3;

                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                    }

                    break;
            }
        }
    }
}