using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppUI.UserControls
{
    public partial class PinPadUserControl : UserControl
    {
        private string pinDisplay = string.Empty;
        public event EventHandler<string> PinEntered;

        public PinPadUserControl()
        {
            InitializeComponent();
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
            PinDisplay += button.Text;
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            PinEntered?.Invoke(this, PinDisplay);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxPin.Clear();
            PinDisplay = string.Empty;
        }
    }
}
