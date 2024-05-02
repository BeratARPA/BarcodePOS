using System;
using System.Windows.Forms;
using WindowsFormsAppUI.Helpers;

namespace WindowsFormsAppUI.Forms.ManagementForms
{
    public partial class ManagementMessageServerForm : Form
    {
        public ManagementMessageServerForm()
        {
            InitializeComponent();
            UpdateUILanguage();

            textBoxServerName.Text = Properties.Settings.Default.ServerName;
            textBoxServerPort.Text = Properties.Settings.Default.Port.ToString();
        }

        public void UpdateUILanguage()
        {
            label1.Text = GlobalVariables.CultureHelper.GetText("MessageServerName");
            label2.Text = GlobalVariables.CultureHelper.GetText("MessageServerPort");
            buttonSave.Text = GlobalVariables.CultureHelper.GetText("Save");
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxServerName.Text) || string.IsNullOrEmpty(textBoxServerPort.Text))
            {
                return;
            }

            Properties.Settings.Default.ServerName = textBoxServerName.Text;
            Properties.Settings.Default.Port = Convert.ToInt32(textBoxServerPort.Text);
            Properties.Settings.Default.Save();
        }

        private void textBoxServerPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true; //Handle (ignore) the event
            }
        }
    }
}
