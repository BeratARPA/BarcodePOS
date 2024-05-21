using Database.Data;
using Database.Models;
using System;
using System.Windows.Forms;
using WindowsFormsAppUI.Helpers;

namespace WindowsFormsAppUI.Forms
{
    public partial class LoginForm : Form
    {
        private readonly IGenericRepository<User> _genericRepository = new GenericRepository<User>(GlobalVariables.SQLContext);

        public LoginForm()
        {
            InitializeComponent();

            UpdateUILanguage();

            labelTerminalName.Text = GlobalVariables.TerminalName;
        }

        public void UpdateUILanguage()
        {
            buttonShutdown.Text = GlobalVariables.CultureHelper.GetText("Close");
        }

        private void pinPadUserControl1_PinEntered(object sender, string e)
        {
            var user = _genericRepository.Get(x => x.Password == e);
            if (user is null)
            {
                GlobalVariables.MessageBoxForm.ShowMessage(GlobalVariables.CultureHelper.GetText("UserNotFound!"), GlobalVariables.CultureHelper.GetText("Warning"), MessageButton.OK, MessageIcon.Warning);
                return;
            }

           LoggedInUser.Login(user);        
        }

        private async void buttonShutdown_Click(object sender, EventArgs e)
        {
            await GlobalVariables.webSocketClient.Disconnect();

            Environment.Exit(0);
        }
    }
}
