using Database.Data;
using Database.Models;
using System;
using System.Windows.Forms;
using WindowsFormsAppUI.Helpers;

namespace WindowsFormsAppUI.Forms.ManagementForms
{
    public partial class ManagementCompanyInformationForm : Form
    {
        private readonly GenericRepository<CompanyInformation> _genericRepositoryCompanyInformation = new GenericRepository<CompanyInformation>(GlobalVariables.SQLContext);

        public ManagementCompanyInformationForm()
        {
            InitializeComponent();
            UpdateUILanguage();

            var companyInformationExist = _genericRepositoryCompanyInformation.GetFirst();
            if (companyInformationExist != null)
            {
                textBoxCompanyName.Text = companyInformationExist.Name;
                textBoxAdress.Text = companyInformationExist.Address;
                textBoxPhoneNumber.Text = companyInformationExist.Phone;
                textBoxEmail.Text = companyInformationExist.EMail;
            }
        }

        public void UpdateUILanguage()
        {
            label1.Text = GlobalVariables.CultureHelper.GetText("CompanyName");
            label2.Text = GlobalVariables.CultureHelper.GetText("CustomerAddress");
            label3.Text = GlobalVariables.CultureHelper.GetText("CustomerPhoneNumber");
            label4.Text = GlobalVariables.CultureHelper.GetText("Email");
            buttonSave.Text = GlobalVariables.CultureHelper.GetText("Save");
        }

        private void textBoxPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true; //Handle (ignore) the event
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCompanyName.Text) || string.IsNullOrEmpty(textBoxAdress.Text) || string.IsNullOrEmpty(textBoxPhoneNumber.Text) || string.IsNullOrEmpty(textBoxEmail.Text))
            {
                return;
            }

            var companyInformationExist = _genericRepositoryCompanyInformation.GetFirst();
            if (companyInformationExist != null)
            {
                companyInformationExist.Name = textBoxCompanyName.Text;
                companyInformationExist.Address = textBoxAdress.Text;
                companyInformationExist.Phone = textBoxPhoneNumber.Text;
                companyInformationExist.EMail = textBoxEmail.Text;

                _genericRepositoryCompanyInformation.Update(companyInformationExist);
            }
            else
            {
                CompanyInformation companyInformation = new CompanyInformation
                {
                    Name = textBoxCompanyName.Text,
                    Address = textBoxAdress.Text,
                    Phone = textBoxPhoneNumber.Text,
                    EMail = textBoxEmail.Text
                };

                _genericRepositoryCompanyInformation.Add(companyInformation);
            }

            GlobalVariables.MessageBoxForm.ShowMessage(GlobalVariables.CultureHelper.GetText("TheChangesAreSaved."), GlobalVariables.CultureHelper.GetText("Information"), MessageButton.OK, MessageIcon.Information);
        }
    }
}