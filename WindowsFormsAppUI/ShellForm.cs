using Database.Data;
using Database.Models;
using System;
using System.Runtime.InteropServices;
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

            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;

            GlobalVariables.CultureHelper.ChangeCulture(Properties.Settings.Default.CurrentLanguage);
            UpdateUILanguage();

            GlobalVariables.ShellForm = this;

            ResizeLayout.CloseFooter();
            NavigationManager.OpenForm(new LoginForm(), DockStyle.Fill, panelMain);

            _timer = new Timer();
            _timer.Tick += TimerTick;

            _timer_CallerID = new Timer();
            _timer_CallerID.Tick += CallerID;

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

        private async void ShellForm_Load(object sender, EventArgs e)
        {
            _timer.Interval = 1000;
            _timer.Start();

            #region CallerID           
            try
            {
                _timer_CallerID.Interval = 1000;
                _timer_CallerID.Start();
                CidStart();
            }
            catch
            {
                _timer_CallerID.Stop();
            }
            #endregion

            if (Properties.Settings.Default.OpenWindows)
            {
                OpenWindowsForm openWindowsForm = new OpenWindowsForm();
                openWindowsForm.Show();
            }

            if (Properties.Settings.Default.CustomerScreen)
            {
                POSCustomerScreenForm posCustomerScreenForm = new POSCustomerScreenForm();
                posCustomerScreenForm.Show();
            }

            await GlobalVariables.webSocketClient.Connect(Properties.Settings.Default.ServerName, Properties.Settings.Default.Port);
        }

        #region CallerID
        private readonly GenericRepository<OldCalling> _genericRepositoryOldCalling = new GenericRepository<OldCalling>(GlobalVariables.SQLContext);

        private readonly Timer _timer_CallerID;

        [DllImport("cid.dll", EntryPoint = "CidData", CharSet = CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ConstCharPtrMarshaler))]
        public static extern string CidData();

        [DllImport("cid.dll", EntryPoint = "CidStart")]
        public static extern string CidStart();

        public class ConstCharPtrMarshaler : ICustomMarshaler
        {
            public object MarshalNativeToManaged(IntPtr pNativeData)
            {
                return Marshal.PtrToStringAnsi(pNativeData);
            }

            public IntPtr MarshalManagedToNative(object ManagedObj)
            {
                return IntPtr.Zero;
            }

            public void CleanUpNativeData(IntPtr pNativeData)
            {
            }

            public void CleanUpManagedData(object ManagedObj)
            {
            }

            public int GetNativeDataSize()
            {
                return IntPtr.Size;
            }

            static readonly ConstCharPtrMarshaler instance = new ConstCharPtrMarshaler();

            public static ICustomMarshaler GetInstance(string cookie)
            {
                return instance;
            }
        }


        private void CallerID(object sender, EventArgs e)
        {
            string data = CidData();
            if (data != "")
            {
                string[] words = data.Split(',');
                string serial = words[0];
                string line = words[1];
                string phoneNumber = words[2];

                _genericRepositoryOldCalling.Add(new OldCalling { Serial = serial, Line = line, PhoneNumber = phoneNumber, CallingDateTime = DateTime.Now });

                if (LoggedInUser.CurrentUser != null)
                {
                    CustomerCallingForm customerCallingForm = new CustomerCallingForm();
                    customerCallingForm.ShowAlert(phoneNumber);
                }
            }
        }
        #endregion

        public void UpdateUILanguage()
        {
            buttonMainMenu.Text = GlobalVariables.CultureHelper.GetText("MainMenu");
            buttonKeyboard.Text = GlobalVariables.CultureHelper.GetText("Keyboard");
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

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            if (FormBorderStyle == FormBorderStyle.Sizable)
            {
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
            }
        }

        private async void ShellForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            await GlobalVariables.webSocketClient.Disconnect();
        }

        private void buttonKeyboard_Click(object sender, EventArgs e)
        {
            VirtualKeyboardHelper.Run();
        }

        private void ShellForm_Resize(object sender, EventArgs e)
        {
            this.Text = $"({this.Width})X({this.Height})";
        }
    }
}
