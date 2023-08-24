using Database.Models;
using System.Windows.Forms;
using WindowsFormsAppUI.Forms;

namespace WindowsFormsAppUI.Helpers
{
    public class LoggedInUser
    {
        public static User CurrentUser { get; set; }

        public static void Login(User user)
        {
            CurrentUser = user;
            ResizeLayout.OpenFooter();
            GlobalVariables.ShellForm.labelUserFullname.Visible = true;
            GlobalVariables.ShellForm.labelUserFullname.Text = user.Fullname;
            GlobalVariables.ShellForm.buttonMainMenu.Visible = true;
            NavigationManager.OpenForm(new DashboardForm(), DockStyle.Fill, GlobalVariables.ShellForm.panelMain);
        }

        public static void Logout()
        {
            CurrentUser = null;
            ResizeLayout.CloseFooter();
            GlobalVariables.ShellForm.labelUserFullname.Visible = false;
            GlobalVariables.ShellForm.labelUserFullname.Text = "";
            GlobalVariables.ShellForm.buttonMainMenu.Visible = false;
            NavigationManager.OpenForm(new LoginForm(), DockStyle.Fill, GlobalVariables.ShellForm.panelMain);
        }
    }
}
