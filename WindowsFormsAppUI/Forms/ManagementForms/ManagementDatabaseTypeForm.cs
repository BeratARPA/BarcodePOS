using Database.Helpers;
using System;
using System.Windows.Forms;
using WindowsFormsAppUI.Helpers;

namespace WindowsFormsAppUI.Forms.ManagementForms
{
    public partial class ManagementDatabaseTypeForm : Form
    {
        public ManagementDatabaseTypeForm()
        {
            InitializeComponent();
            UpdateUILanguage();

            comboBoxDatabaseTypes.SelectedIndex = DatabaseTypeSettingHelper.Get();
        }

        public void UpdateUILanguage()
        {
            groupBox1.Text = GlobalVariables.CultureHelper.GetText("DatabaseTypes");
            label1.Text = GlobalVariables.CultureHelper.GetText("DatabaseType");
            buttonSave.Text = GlobalVariables.CultureHelper.GetText("Save");
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (DatabaseTypeSettingHelper.Get() != comboBoxDatabaseTypes.SelectedIndex)
            {
                if (GlobalVariables.MessageBoxForm.ShowMessage(GlobalVariables.CultureHelper.GetText("TheDatabaseWillBeBackedUpTheApplicationWillBeClosedAndTheDatabaseTypeWillBeChangedDoYouWantToContinue?"), GlobalVariables.CultureHelper.GetText("Information"), MessageButton.YesNo, MessageIcon.Information) == DialogResult.Yes)
                {
                    DatabaseHelper.Backup();
                    DatabaseTypeSettingHelper.Set(comboBoxDatabaseTypes.SelectedIndex);

                    Application.Exit();
                }
            }
        }
    }
}