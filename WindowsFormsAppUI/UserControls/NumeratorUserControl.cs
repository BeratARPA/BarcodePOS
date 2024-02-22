using System;
using System.Windows.Forms;
using WindowsFormsAppUI.Helpers;

namespace WindowsFormsAppUI.UserControls
{
    public partial class NumeratorUserControl : UserControl
    {
        private string numeratorDisplay = string.Empty;
        public event EventHandler<string> NumeratorEntered;

        public NumeratorUserControl()
        {
            InitializeComponent();
            UpdateUILanguage();
        }

        public void UpdateUILanguage()
        {
            buttonClear.Text = GlobalVariables.CultureHelper.GetText("Clear");          
            buttonComma.Text = GlobalVariables.CultureHelper.GetText("Comma");          
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
