using Database.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsAppUI.UserControls
{
    public partial class PaymentTypeUserControl : UserControl
    {
        public PaymentType _paymentType;
        public event EventHandler PaymentTypeClick;

        public PaymentTypeUserControl(PaymentType paymentType)
        {
            InitializeComponent();

            _paymentType = paymentType;
        }

        private void PaymentUserControl_Load(object sender, EventArgs e)
        {
            Name = _paymentType.Name;

            string[] backColorArgb = _paymentType.BackColor.Split(',');
            string[] foreColorArgb = _paymentType.ForeColor.Split(',');

            this.BackColor = Color.FromArgb(50, Convert.ToInt32(backColorArgb[0]), Convert.ToInt32(backColorArgb[1]), Convert.ToInt32(backColorArgb[2]));

            labelName.ForeColor = Color.FromArgb(Convert.ToInt32(foreColorArgb[0]), Convert.ToInt32(foreColorArgb[1]), Convert.ToInt32(foreColorArgb[2]));
            labelName.Font = new Font("Microsoft Sans Serif", _paymentType.FontSize);
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                labelName.Text = value;
            }
        }

        private void PaymentUserControl_Click(object sender, EventArgs e)
        {
            PaymentTypeClick?.Invoke(this, e);
        }
    }
}
