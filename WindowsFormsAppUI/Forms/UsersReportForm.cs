using Database.Data;
using Database.Models;
using System;
using System.IO;
using System.Windows.Forms;
using WindowsFormsAppUI.Helpers;

namespace WindowsFormsAppUI.Forms
{
    public partial class UsersReportForm : Form
    {
        private readonly IGenericRepository<User> _genericRepositoryUser = new GenericRepository<User>(GlobalVariables.SQLContext);
        private readonly IGenericRepository<Order> _genericRepositoryOrder = new GenericRepository<Order>(GlobalVariables.SQLContext);
        private readonly IGenericRepository<Ticket> _genericRepositoryTicket = new GenericRepository<Ticket>(GlobalVariables.SQLContext);

        private ReceiptTemplates receiptTemplates = new ReceiptTemplates();

        public UsersReportForm()
        {
            InitializeComponent();
            UpdateUILanguage();
        }

        private void UsersReportForm_Load(object sender, EventArgs e)
        {
            dateTimePickerStart.DateTime = DateTime.Now;
            dateTimePickerEnd.DateTime = DateTime.Now;

            ShowReport();
        }

        public void UpdateUILanguage()
        {
            buttonPrint.Text = GlobalVariables.CultureHelper.GetText("Print");
            buttonRefresh.Text = GlobalVariables.CultureHelper.GetText("Refresh");
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            pdfViewer1.Print();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            ShowReport();
        }

        public void ShowReport()
        {
            string filePath = Path.Combine(FolderLocations.barcodePOSFolderPath, "RevenuesReport.pdf");

            pdfViewer1.CloseDocument();

            if (File.Exists(filePath))
                File.Delete(filePath);

            DateTime startDate = dateTimePickerStart.DateTime.Date;
            DateTime endDate = dateTimePickerEnd.DateTime.Date;
            endDate = endDate.AddDays(1);

            var tickets = _genericRepositoryTicket.GetAllAsNoTracking(x => x.Date >= startDate && x.Date <= endDate);
            var orders = _genericRepositoryOrder.GetAllAsNoTracking(x => x.CreatedDateTime >= startDate && x.CreatedDateTime <= endDate);
            var users = _genericRepositoryUser.GetAllAsNoTracking();
            var report = receiptTemplates.UserReport(tickets, orders, users);

            PdfConverter.ConvertToPdf(report, filePath);

            pdfViewer1.LoadDocument(filePath);
        }
    }
}
