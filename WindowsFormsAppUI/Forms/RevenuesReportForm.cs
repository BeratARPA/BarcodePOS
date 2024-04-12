using Database.Data;
using Database.Models;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsAppUI.Helpers;

namespace WindowsFormsAppUI.Forms
{
    public partial class RevenuesReportForm : Form
    {
        private readonly IGenericRepository<Payment> _genericRepositoryPayment = new GenericRepository<Payment>(GlobalVariables.SQLContext);

        private ReceiptTemplates receiptTemplates = new ReceiptTemplates();

        public RevenuesReportForm()
        {
            InitializeComponent();
            UpdateUILanguage();
        }

        private void RevenuesReportForm_Load(object sender, EventArgs e)
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

            var payments = _genericRepositoryPayment.GetAllAsNoTracking(x => x.Date >= startDate && x.Date <= endDate);
            var report = receiptTemplates.RevenuesReport(payments);

            PdfConverter.ConvertToPdf(report, filePath);

            pdfViewer1.LoadDocument(filePath);
        }
    }
}
