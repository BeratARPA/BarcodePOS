using System;
using System.Windows.Forms;
using WindowsFormsAppUI.Helpers;

namespace WindowsFormsAppUI.Forms.ManagementForms
{
    public partial class ManagementGeneralForm : Form
    {
        public ManagementGeneralForm()
        {
            InitializeComponent();
            UpdateUILanguage();

            checkBoxClientConsole.Checked = Properties.Settings.Default.ClientConsole;
            checkBoxCustomerScreen.Checked = Properties.Settings.Default.CustomerScreen;
            checkBoxOpenWindowConsole.Checked = Properties.Settings.Default.OpenWindows;
        }

        public void UpdateUILanguage()
        {
            groupBox1.Text = GlobalVariables.CultureHelper.GetText("Languages");
            label1.Text = GlobalVariables.CultureHelper.GetText("Language");
            buttonSave.Text = GlobalVariables.CultureHelper.GetText("Save");
            checkBoxClientConsole.Text = GlobalVariables.CultureHelper.GetText("ClientConsole");
            checkBoxCustomerScreen.Text = GlobalVariables.CultureHelper.GetText("CustomerScreen");
            checkBoxOpenWindowConsole.Text = GlobalVariables.CultureHelper.GetText("CurrentWindowConsole");
        }

        private string GetLanguage()
        {
            switch (comboBoxLanguages.SelectedItem)
            {
                case "Türkçe":
                    return "tr-TR";
                case "English":
                    return "en-US";
                default:
                    return "tr-TR";
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.CurrentLanguage = GetLanguage();

            Properties.Settings.Default.ClientConsole = checkBoxClientConsole.Checked;
            Properties.Settings.Default.CustomerScreen = checkBoxCustomerScreen.Checked;
            Properties.Settings.Default.OpenWindows = checkBoxOpenWindowConsole.Checked;

            Properties.Settings.Default.Save();

            GlobalVariables.CultureHelper.ChangeCulture(Properties.Settings.Default.CurrentLanguage);
            UpdateUILanguage();

            ShellForm shellForm = (ShellForm)GetForm.Get("ShellForm");
            shellForm.UpdateUILanguage();
            DashboardForm dashboardForm = (DashboardForm)GetForm.Get("DashboardForm");
            dashboardForm.UpdateUILanguage();
            ManagementForm managementForm = (ManagementForm)GetForm.Get("ManagementForm");
            managementForm.UpdateUILanguage();

            GlobalVariables.MessageBoxForm.ShowMessage(GlobalVariables.CultureHelper.GetText("RestartForTheChangesToApply."), GlobalVariables.CultureHelper.GetText("Information"), MessageButton.OK, MessageIcon.Information);
        }
    }
}
