using System;
using System.Windows.Forms;
using WindowsFormsAppUI.Helpers;

namespace WindowsFormsAppUI.UserControls
{
    public partial class PinPadUserControl : UserControl
    {
        private string pinDisplay = string.Empty;
        public event EventHandler<string> PinEntered;

        public PinPadUserControl()
        {
            InitializeComponent();
            UpdateUILanguage();
        }

        public void UpdateUILanguage()
        {
            buttonClear.Text = GlobalVariables.CultureHelper.GetText("Clear");
            buttonSubmit.Text = GlobalVariables.CultureHelper.GetText("Ok");
        }

        public string PinDisplay
        {
            get { return pinDisplay; }
            set
            {
                pinDisplay = value;
            }
        }

        private void ButtonNumber(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            textBoxPin.Text += button.Text;
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            PinDisplay += textBoxPin.Text;
            PinEntered?.Invoke(this, PinDisplay);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxPin.Clear();
            PinDisplay = string.Empty;
        }
    }
}
