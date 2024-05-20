using Database.Models;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
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

        private void PaymentTypeUserControl_Resize(object sender, EventArgs e)
        {
            int divide = 20;

            var controls = new List<Control> { labelName };
            for (int i = 0; i < controls.Count; i++)
            {
                int controlSize = controls[i].Height + controls[i].Width;
                controls[i].Font = new Font("Microsoft Sans Serif", controlSize / divide);
            }
        }
    }
}
