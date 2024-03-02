using Database.Data;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsAppUI.Helpers;

namespace WindowsFormsAppUI.Forms
{
    public partial class TicketsForm : Form
    {
        private readonly IGenericRepository<Ticket> _genericRepositoryTicket = new GenericRepository<Ticket>(GlobalVariables.SQLContext);

        public TicketsForm()
        {
            InitializeComponent();
            UpdateUILanguage();
        }

        private void TicketsForm_Load(object sender, EventArgs e)
        {
            AddTicketsDataGridView();

            dateTimePickerStart.DateTime = DateTime.Now;
            dateTimePickerEnd.DateTime = DateTime.Now;

            AddFilterComboBox();
            comboBoxFilter.SelectedItem = GlobalVariables.CultureHelper.GetText("AllTickets");
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

        public void AddFilterComboBox()
        {
            comboBoxFilter.Items.Add(GlobalVariables.CultureHelper.GetText("AllTickets"));
            comboBoxFilter.Items.Add(GlobalVariables.CultureHelper.GetText("OpenTickets"));
            comboBoxFilter.Items.Add(GlobalVariables.CultureHelper.GetText("ClosedTickets"));
        }

        public void AddTicketsDataGridView(int index = 0)
        {
            dataGridViewTickets.Rows.Clear();

            DateTime startDate = dateTimePickerStart.DateTime.Date;
            DateTime endDate = dateTimePickerEnd.DateTime.Date.Date;
            endDate = endDate.AddDays(1);

            double totalAmount = 0;

            List<Ticket> tickets = null;
            switch (index)
            {
                case 0:
                    tickets = _genericRepositoryTicket.GetAllAsNoTracking(x => x.Date >= startDate.Date && x.Date <= endDate.Date);
                    break;
                case 1:
                    tickets = _genericRepositoryTicket.GetAllAsNoTracking(x => x.Date >= startDate.Date && x.Date <= endDate.Date && x.IsOpened == true);
                    break;
                case 2:
                    tickets = _genericRepositoryTicket.GetAllAsNoTracking(x => x.Date >= startDate.Date && x.Date <= endDate.Date && x.IsOpened == false);
                    break;
                default:
                    tickets = _genericRepositoryTicket.GetAllAsNoTracking(x => x.Date >= startDate.Date && x.Date <= endDate.Date);
                    break;
            }

            if (tickets != null)
            {
                DataGridViewButtonColumn dataGridViewShowButtonColumn = new DataGridViewButtonColumn
                {
                    Text = GlobalVariables.CultureHelper.GetText("View"),
                    HeaderText = "",
                    SortMode = DataGridViewColumnSortMode.Automatic,
                    Resizable = DataGridViewTriState.True,
                    UseColumnTextForButtonValue = true,
                    Name = "Show",
                    FlatStyle = FlatStyle.Flat
                };

                DataGridViewButtonColumn dataGridViewPaymentButtonColumn = new DataGridViewButtonColumn
                {
                    Text = GlobalVariables.CultureHelper.GetText("Payments"),
                    HeaderText = "",
                    SortMode = DataGridViewColumnSortMode.Automatic,
                    Resizable = DataGridViewTriState.True,
                    UseColumnTextForButtonValue = true,
                    Name = "Payment",
                    FlatStyle = FlatStyle.Flat
                };

                dataGridViewTickets.Columns.Add(dataGridViewPaymentButtonColumn);
                dataGridViewTickets.Columns.Add(dataGridViewShowButtonColumn);
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
            if (dataGridViewTickets.Columns["Show"] != null && e.ColumnIndex == dataGridViewTickets.Columns["Show"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridViewTickets.Rows[e.RowIndex];

                Guid ticketGuid;
                Guid.TryParse(selectedRow.Cells["TicketGuid"].Value.ToString(), out ticketGuid);

                var ticket = _genericRepositoryTicket.GetAllAsNoTracking(x => x.TicketGuid == ticketGuid).FirstOrDefault();

                if (ticket != null)
                {
                    NavigationManager.OpenForm(new POSForm(2, ticket), DockStyle.Fill, GlobalVariables.ShellForm.panelMain);
                    GlobalVariables.ShellForm.buttonMainMenu.Enabled = false;                    
                }
            }

            if (dataGridViewTickets.Columns["Payment"] != null && e.ColumnIndex == dataGridViewTickets.Columns["Payment"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridViewTickets.Rows[e.RowIndex];

                PaymentsForm paymentsForm = new PaymentsForm(Convert.ToInt32(selectedRow.Cells["TicketId"].Value));
                paymentsForm.ShowDialog();
            }
        }

        private void dateTimePickerEnd_EditValueChanged(object sender, EventArgs e)
        {
            RemoveColumn();
            AddTicketsDataGridView(comboBoxFilter.SelectedIndex);
        }

        private void comboBoxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            RemoveColumn();
            AddTicketsDataGridView(comboBoxFilter.SelectedIndex);
        }

        public void RemoveColumn()
        {
            DataGridViewColumn showColumn = dataGridViewTickets.Columns["Show"];
            DataGridViewColumn paymentColumn = dataGridViewTickets.Columns["Payment"];
            dataGridViewTickets.Columns.Remove(showColumn);
            dataGridViewTickets.Columns.Remove(paymentColumn);
        }
    }
}
