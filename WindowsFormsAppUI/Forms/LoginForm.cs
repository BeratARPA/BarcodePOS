using Database.Data;
using Database.Models;
using System;
using System.Linq;
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

            labelTerminalName.Text = GlobalVariables.TerminalName;
        }

        private void pinPadUserControl1_PinEntered(object sender, string e)
        {
            var user = _genericRepository.GetAll(x => x.Password == e).FirstOrDefault();
            if (user is null)
            {
                GlobalVariables.MessageBoxForm.ShowMessage("Kullanıcı bulunamadı!", "Uyarı", MessageButton.OK, MessageIcon.Warning);
                return;
            }

            LoggedInUser.Login(user);
        }

        private void buttonShutdown_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
