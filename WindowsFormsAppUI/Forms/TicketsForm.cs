using Database.Data;
using Database.Models;
using System;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsAppUI.Helpers;

namespace WindowsFormsAppUI.Forms
{
    public partial class TicketsForm : Form
    {
        private readonly IGenericRepository<Ticket> _genericRepositoryTicket = new GenericRepository<Ticket>(GlobalVariables.SQLContext);
        private readonly IGenericRepository<Order> _genericRepositoryOrder = new GenericRepository<Order>(GlobalVariables.SQLContext);
        private readonly IGenericRepository<Payment> _genericRepositoryPayment = new GenericRepository<Payment>(GlobalVariables.SQLContext);

        public TicketsForm()
        {
            InitializeComponent();
            UpdateUILanguage();
        }

        private void TicketsForm_Load(object sender, EventArgs e)
        {
            AddTicketsDataGridView();
        }

        public void UpdateUILanguage()
        {
            label1.Text = GlobalVariables.CultureHelper.GetText("Start");
            label2.Text = GlobalVariables.CultureHelper.GetText("End");
            dataGridViewTickets.Columns[3].HeaderText = GlobalVariables.CultureHelper.GetText("TicketNumber");
            dataGridViewTickets.Columns[4].HeaderText = GlobalVariables.CultureHelper.GetText("Date");
            dataGridViewTickets.Columns[5].HeaderText = GlobalVariables.CultureHelper.GetText("OpeningClosing");
            dataGridViewTickets.Columns[6].HeaderText = GlobalVariables.CultureHelper.GetText("User");
            dataGridViewTickets.Columns[7].HeaderText = GlobalVariables.CultureHelper.GetText("Total");
            label3.Text = GlobalVariables.CultureHelper.GetText("TotalTicket");
            label5.Text = GlobalVariables.CultureHelper.GetText("TotalBalance");
        }

        public void AddTicketsDataGridView()
        {
            dataGridViewTickets.Rows.Clear();

            DateTime startDate = dateTimePickerStart.Value;
            DateTime endDate = dateTimePickerEnd.Value;
            endDate = endDate.AddDays(1);

            double totalAmount = 0;
            var tickets = _genericRepositoryTicket.GetAll(x => x.Date >= startDate.Date && x.Date <= endDate.Date);
            if (tickets != null)
            {              
                DataGridViewButtonColumn dataGridViewButtonColumn = new DataGridViewButtonColumn
                {
                    Text = GlobalVariables.CultureHelper.GetText("View"),
                    HeaderText = "",
                    SortMode = DataGridViewColumnSortMode.Automatic,
                    Resizable = DataGridViewTriState.True,
                    UseColumnTextForButtonValue = true,
                    Name = "Show",
                    FlatStyle = FlatStyle.Flat
                };

                dataGridViewTickets.Columns.Add(dataGridViewButtonColumn);
            }

            foreach (Ticket ticket in tickets)
            {
                string openedClosed = ticket.Date.ToString("HH:mm");
                if (!ticket.IsOpened)
                {
                    openedClosed += "-" + ticket.LastPaymentDate.ToString("HH:mm");
                }

                dataGridViewTickets.Rows.Add(ticket.TicketId, ticket.TicketGuid, ticket.Date, ticket.TicketNumber, ticket.Date.ToString("dd/MM/yyyy"), openedClosed, ticket.CreatedUserName, string.Format("{0:C}", ticket.TotalAmount));
                totalAmount += ticket.TotalAmount;
            }

            dataGridViewTickets.ClearSelection();

            labelTotalTicket.Text = tickets.Count.ToString();
            labelTotalAmount.Text = string.Format("{0:C}", totalAmount);
        }

        private void dataGridViewTickets_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewTickets.Columns["Show"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridViewTickets.Rows[e.RowIndex];

                Guid ticketGuid;
                Guid.TryParse(selectedRow.Cells["TicketGuid"].Value.ToString(), out ticketGuid);

                var ticket = _genericRepositoryTicket.GetAll(x => x.TicketGuid == ticketGuid).FirstOrDefault();
                var orders = _genericRepositoryOrder.GetAll(x => x.TicketId == ticket.TicketId);
                var payments = _genericRepositoryPayment.GetAll(x => x.TicketId == ticket.TicketId);
                ticket.Orders = orders;
                ticket.Payments = payments;

                if (ticket != null)
                {
                    NavigationManager.OpenForm(new POSForm(ticket), DockStyle.Fill, GlobalVariables.ShellForm.panelMain);
                    GlobalVariables.ShellForm.buttonMainMenu.Enabled = false;
                }
            }
        }

        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            DataGridViewColumn column = dataGridViewTickets.Columns["Show"];
            dataGridViewTickets.Columns.Remove(column); 
            AddTicketsDataGridView();
        }
    }
}
