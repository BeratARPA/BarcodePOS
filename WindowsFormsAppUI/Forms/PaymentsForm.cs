using Database.Data;
using Database.Models;
using System;
using System.Windows.Forms;
using WindowsFormsAppUI.Helpers;

namespace WindowsFormsAppUI.Forms
{
    public partial class PaymentsForm : Form
    {
        private readonly IGenericRepository<Payment> _genericRepositoryPayment = new GenericRepository<Payment>(GlobalVariables.SQLContext);
        private readonly IGenericRepository<User> _genericRepositoryUser = new GenericRepository<User>(GlobalVariables.SQLContext);

        private int _ticketId;

        public PaymentsForm(int ticketId)
        {
            InitializeComponent();
            UpdateUILanguage();

            _ticketId = ticketId;

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

        private void PaymentsForm_Load(object sender, EventArgs e)
        {
            AddPaymentDataGridView();
        }

        public void UpdateUILanguage()
        {
            this.Text = GlobalVariables.CultureHelper.GetText("Payments");
            dataGridViewPayments.Columns[0].HeaderText = GlobalVariables.CultureHelper.GetText("Payment");
            dataGridViewPayments.Columns[1].HeaderText = GlobalVariables.CultureHelper.GetText("Date");
            dataGridViewPayments.Columns[2].HeaderText = GlobalVariables.CultureHelper.GetText("Amount");
            dataGridViewPayments.Columns[3].HeaderText = GlobalVariables.CultureHelper.GetText("User");
        }

        public void AddPaymentDataGridView()
        {
            dataGridViewPayments.Rows.Clear();

            var payments = _genericRepositoryPayment.GetAll(x => x.TicketId == _ticketId);
            foreach (var payment in payments)
            {
                var user = _genericRepositoryUser.GetById(payment.UserId);

                dataGridViewPayments.Rows.Add(payment.Name, payment.Date.ToString("dd/MM/yyyy HH:mm"), string.Format("{0:C}", payment.TenderedAmount), user.Fullname);
            }

            dataGridViewPayments.ClearSelection();
        }
    }
}
