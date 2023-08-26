using Database.Data;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsAppUI.Helpers;
using WindowsFormsAppUI.UserControls;

namespace WindowsFormsAppUI.Forms
{
    public partial class PaymentForm : Form
    {
        private readonly IGenericRepository<Ticket> _genericRepositoryTicket = new GenericRepository<Ticket>(GlobalVariables.SQLContext);
        private readonly IGenericRepository<PaymentType> _genericRepositoryPaymentType = new GenericRepository<PaymentType>(GlobalVariables.SQLContext);
        private readonly IGenericRepository<Payment> _genericRepositoryPayment = new GenericRepository<Payment>(GlobalVariables.SQLContext);

        private List<PaymentType> _paymentTypes = new List<PaymentType>();
        private Ticket _ticket = null;
        private POSForm _posForm = null;

        public PaymentForm(Ticket ticket)
        {
            InitializeComponent();
            UpdateUILanguage();

            _ticket = ticket;
            _posForm = (POSForm)GetForm.Get("POSForm");

            numeratorUserControl.textBoxPin.KeyPress += new KeyPressEventHandler(NumeratorTextBoxPin_KeyPress);
            numeratorUserControl.textBoxPin.TextChanged += NumeratorUserControl_TextChanged;

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

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            labelBalance.Text = string.Format("{0:C}", _ticket.RemainingAmount);

            _paymentTypes = _genericRepositoryPaymentType.GetAll();
            CreatePayments(_paymentTypes);

            tableLayoutPanelMain.RowStyles[1].Height = 0;
            tableLayoutPanelMain.RowStyles[2].Height = 0;

            CheckToTenderedAmount();
        }

        public void UpdateUILanguage()
        {
            this.Text = GlobalVariables.CultureHelper.GetText("MultiplePayments");
            label1.Text = GlobalVariables.CultureHelper.GetText("Balance");
            label4.Text = GlobalVariables.CultureHelper.GetText("BalancePaid");
            label5.Text = GlobalVariables.CultureHelper.GetText("RemainderOfMoney");
        }

        public double CheckToNumerator()
        {
            try
            {
                if (string.IsNullOrEmpty(numeratorUserControl.textBoxPin.Text))
                {
                    return 0;
                }

                return Convert.ToDouble(numeratorUserControl.textBoxPin.Text);
            }
            catch
            {
                return 0;
            }
        }

        private void NumeratorUserControl_TextChanged(object sender, EventArgs e)
        {
            CheckToMoneyChange();
        }

        private void NumeratorTextBoxPin_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sadece rakam (0-9) veya virgül (,) karakterlerine izin verme
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '\b') // '\b' BACKSPACE karakteridir
            {
                e.Handled = true; // Olayı işleme (yoksayma)
            }
        }

        public void CreatePayments(List<PaymentType> paymentTypes)
        {
            tableLayoutPanelPaymentTypes.Controls.Clear();

            int rowCount = 1;
            foreach (PaymentType paymentType in paymentTypes)
            {
                PaymentTypeUserControl paymentTypeUserControl = new PaymentTypeUserControl(paymentType)
                {
                    Dock = DockStyle.Fill
                };

                tableLayoutPanelPaymentTypes.RowStyles.Add(new ColumnStyle(SizeType.Percent, 100));
                tableLayoutPanelPaymentTypes.RowCount = rowCount;
                tableLayoutPanelPaymentTypes.ColumnCount = 1;

                paymentTypeUserControl.PaymentTypeClick += PaymentTypeUserControl_Click;

                tableLayoutPanelPaymentTypes.Controls.Add(paymentTypeUserControl);

                rowCount++;
            }
        }

        public void CheckToTenderedAmount()
        {
            double tenderedAmount = 0;

            if (_ticket.Payments != null)
            {
                foreach (Payment payment in _ticket.Payments)
                {
                    tenderedAmount += payment.TenderedAmount;
                }
            }

            if (tenderedAmount != 0)
            {
                labelTenderedAmount.Text = string.Format("{0:C}", tenderedAmount);
                tableLayoutPanelMain.RowStyles[1].Height = 33.33f;
            }
            else
            {
                labelTenderedAmount.Text = string.Format("{0:C}", 0);
                tableLayoutPanelMain.RowStyles[1].Height = 0;
            }
        }

        public void CheckToMoneyChange()
        {
            if (CheckToNumerator() > _ticket.RemainingAmount)
            {
                double moneyChange = Convert.ToDouble(numeratorUserControl.textBoxPin.Text) - _ticket.RemainingAmount;
                labelMoneyChange.Text = string.Format("{0:C}", moneyChange);
                tableLayoutPanelMain.RowStyles[2].Height = 33.33f;
            }
            else
            {
                labelMoneyChange.Text = string.Format("{0:C}", 0);
                tableLayoutPanelMain.RowStyles[2].Height = 0;
            }
        }

        private void PaymentTypeUserControl_Click(object sender, EventArgs e)
        {
            double tenderedAmount = CheckToNumerator();
            if (tenderedAmount != 0)
            {
                PaymentTypeUserControl paymentTypeUserControl = (PaymentTypeUserControl)sender;

                if (GlobalVariables.MessageBoxForm.ShowMessage(string.Format(GlobalVariables.CultureHelper.GetText("PaymentWillBeMadeInDoYouConfirm?"), paymentTypeUserControl._paymentType.Name), GlobalVariables.CultureHelper.GetText("Information"), MessageButton.YesNo, MessageIcon.Information) != DialogResult.Yes)
                {
                    return;
                }

                if (tenderedAmount >= _ticket.RemainingAmount)
                {
                    Ticket ticket = null;
                    ticket = _genericRepositoryTicket.GetAll(x => x.TicketGuid == _ticket.TicketGuid).FirstOrDefault();
                    if (ticket == null)
                    {
                        _posForm.SaveTicket();
                        ticket = _genericRepositoryTicket.GetAll(x => x.TicketGuid == _ticket.TicketGuid).FirstOrDefault();
                    }

                    Payment payment = new Payment
                    {
                        TicketId = ticket.TicketId,
                        PaymentTypeId = paymentTypeUserControl._paymentType.PaymentTypeId,
                        Name = paymentTypeUserControl._paymentType.Name,
                        Description = "",
                        Date = DateTime.Now,
                        TenderedAmount = ticket.RemainingAmount,
                        UserId = LoggedInUser.CurrentUser.UserId,
                        TerminalName = GlobalVariables.TerminalName
                    };

                    double remainingAmount = ticket.RemainingAmount - tenderedAmount;
                    _genericRepositoryTicket.UpdateColumn(ticket, x => x.RemainingAmount, remainingAmount < 0 ? 0 : remainingAmount);
                    _genericRepositoryTicket.UpdateColumn(ticket, x => x.LastPaymentDate, DateTime.Now);

                    payment.Amount = ticket.RemainingAmount;

                    _genericRepositoryPayment.Add(payment);
                    _genericRepositoryTicket.UpdateColumn(ticket, x => x.IsOpened, false);

                    _posForm.ClearTicket();

                    this.Close();
                }
                else if (tenderedAmount < _ticket.RemainingAmount)
                {
                    Ticket ticket = null;
                    ticket = _genericRepositoryTicket.GetAll(x => x.TicketGuid == _ticket.TicketGuid).FirstOrDefault();
                    if (ticket == null)
                    {
                        _posForm.SaveTicket();
                        ticket = _genericRepositoryTicket.GetAll(x => x.TicketGuid == _ticket.TicketGuid).FirstOrDefault();
                    }

                    double remainingAmount = ticket.RemainingAmount - tenderedAmount;
                    _genericRepositoryTicket.UpdateColumn(ticket, x => x.RemainingAmount, remainingAmount);
                    _genericRepositoryTicket.UpdateColumn(ticket, x => x.LastPaymentDate, DateTime.Now);

                    Payment payment = new Payment
                    {
                        TicketId = ticket.TicketId,
                        PaymentTypeId = paymentTypeUserControl._paymentType.PaymentTypeId,
                        Name = paymentTypeUserControl._paymentType.Name,
                        Description = "",
                        Date = DateTime.Now,
                        Amount = ticket.RemainingAmount,
                        TenderedAmount = tenderedAmount,
                        UserId = LoggedInUser.CurrentUser.UserId,
                        TerminalName = GlobalVariables.TerminalName
                    };

                    _genericRepositoryPayment.Add(payment);

                    _ticket = ticket;
                    labelBalance.Text = string.Format("{0:C}", _ticket.RemainingAmount);
                }

                CheckToMoneyChange();
                CheckToTenderedAmount();
                numeratorUserControl.Clear();
            }
        }

        private void Moneys(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            double tenderedAmount = CheckToNumerator();
            tenderedAmount += Convert.ToDouble(button.Text);
            numeratorUserControl.textBoxPin.Text = tenderedAmount.ToString();
        }
    }
}
