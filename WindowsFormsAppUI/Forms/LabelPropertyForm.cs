using System.Windows.Forms;

namespace WindowsFormsAppUI.Forms
{
    public partial class LabelPropertyForm : Form
    {
        private Label _label;

        public LabelPropertyForm(Label label)
        {
            InitializeComponent();
            _label = label;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.Font = _label.Font;
            fontDialog.Color = _label.ForeColor;

            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                _label.Font = fontDialog.Font;
                _label.ForeColor = fontDialog.Color;
            }
        }
    }
}
