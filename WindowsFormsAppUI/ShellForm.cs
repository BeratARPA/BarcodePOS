using System;
using System.CodeDom;
using System.Windows.Forms;
using WindowsFormsAppUI.Forms;
using WindowsFormsAppUI.Helpers;

namespace WindowsFormsAppUI
{
    public partial class ShellForm : Form
    {
        private readonly Timer _timer;

        public ShellForm()
        {
            InitializeComponent();

            GlobalVariables.CultureHelper.ChangeCulture(Properties.Settings.Default.CurrentLanguage);
            UpdateUILanguage();

            GlobalVariables.ShellForm = this;

            ResizeLayout.CloseFooter();
            NavigationManager.OpenForm(new LoginForm(), DockStyle.Fill, panelMain);

            _timer = new Timer();
            _timer.Tick += TimerTick;
            labelTime.Text = "...";

            this.ResizeBegin += (s, e) =>
            {
                this.Opacity = 0.50;
                this.SuspendLayout();
            };

            this.ResizeEnd += (s, e) =>
            {
                this.Opacity = 1;
                this.ResumeLayout(true);
            };
        }

        private void ShellForm_Load(object sender, EventArgs e)
        {
            _timer.Interval = 1000;
            _timer.Start();
        }

        public void UpdateUILanguage()
        {
            buttonMainMenu.Text = GlobalVariables.CultureHelper.GetText("MainMenu");
        }

        private void TimerTick(object sender, EventArgs e)
        {
            var time = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
            labelTime.Text = labelTime.Text.Contains(":") ? time.Replace(":", ".") : time;
        }

        private void buttonMainMenu_Click(object sender, EventArgs e)
        {
            NavigationManager.OpenForm(new DashboardForm(), DockStyle.Fill, GlobalVariables.ShellForm.panelMain);
            buttonMainMenu.Enabled = false;
        }
    }
}
