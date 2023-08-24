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
    public partial class NumeratorUserControl : UserControl
    {
        private string numeratorDisplay = string.Empty;
        public event EventHandler<string> NumeratorEntered;

        public NumeratorUserControl()
        {
            InitializeComponent();
        }

        public string NumeratorDisplay
        {
            get { return numeratorDisplay; }
            set
            {
                numeratorDisplay = value;
            }
        }

        private void ButtonNumber(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            textBoxPin.Text += button.Text;
            NumeratorDisplay += button.Text;
        }

        public void Clear()
        {
            textBoxPin.Clear();
            NumeratorDisplay = string.Empty;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
