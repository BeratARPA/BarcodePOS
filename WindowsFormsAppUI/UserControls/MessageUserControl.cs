using System.Windows.Forms;

namespace WindowsFormsAppUI.UserControls
{
    public partial class MessageUserControl : UserControl
    {
        public FlowLayoutPanel _parentFlowLayoutPanel;

        public MessageUserControl(FlowLayoutPanel parentFlowLayoutPanel)
        {
            InitializeComponent();

            _parentFlowLayoutPanel = parentFlowLayoutPanel;
            _parentFlowLayoutPanel.SizeChanged += _parentFlowLayoutPanel_SizeChanged;
        }

        private void _parentFlowLayoutPanel_SizeChanged(object sender, System.EventArgs e)
        {
            this.Width = _parentFlowLayoutPanel.Width - 20;
        }

        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                labelUserName.Text = _userName;
            }
        }

        private string _message;

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                textBoxMessage.Text = _message;
            }
        }

        private bool _isSender;

        public bool IsSender
        {
            get { return _isSender; }
            set
            {
                _isSender = value;
                this.RightToLeft = value ? RightToLeft.Yes : RightToLeft.No;
            }
        }
    }
}
