using Database.Data;
using Database.Models;
using System;
using System.IO;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Forms;
using WindowsFormsAppUI.Helpers;

namespace WindowsFormsAppUI.Forms
{
    public partial class RevenuesReportForm : Form
    {
        private readonly IGenericRepository<Ticket> _genericRepositoryTicket = new GenericRepository<Ticket>(GlobalVariables.SQLContext);

        private ReceiptTemplates receiptTemplates = new ReceiptTemplates();

        public RevenuesReportForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ticket = _genericRepositoryTicket.GetById(18);

            var report = receiptTemplates.TicketReceipt(ticket.Orders.ToList(), ticket);
            XpsConverter.ConvertToXps<FlowDocument>(report, Path.Combine(FolderLocations.barcodePOSFolderPath, "RevenuesReport.xps"));

            webBrowser1.Navigate(Path.Combine(FolderLocations.barcodePOSFolderPath, "RevenuesReport.xps"));
        }
    }
}
