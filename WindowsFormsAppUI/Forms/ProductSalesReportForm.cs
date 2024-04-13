using Database.Data;
using Database.Models;
using System;
using System.IO;
using System.Windows.Forms;
using WindowsFormsAppUI.Helpers;

namespace WindowsFormsAppUI.Forms
{
    public partial class ProductSalesReportForm : Form
    {
        private readonly IGenericRepository<Order> _genericRepositoryOrder = new GenericRepository<Order>(GlobalVariables.SQLContext);

        private ReceiptTemplates receiptTemplates = new ReceiptTemplates();

        public ProductSalesReportForm()
        {
            InitializeComponent();
            UpdateUILanguage();
        }

        private void ProductSalesReportForm_Load(object sender, EventArgs e)
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
            string filePath = Path.Combine(FolderLocations.barcodePOSFolderPath, "ProductSalesReport.pdf");

            pdfViewer1.CloseDocument();

            if (File.Exists(filePath))
                File.Delete(filePath);

            DateTime startDate = dateTimePickerStart.DateTime.Date;
            DateTime endDate = dateTimePickerEnd.DateTime.Date;
            endDate = endDate.AddDays(1);

            var orders = _genericRepositoryOrder.GetAllAsNoTracking(x => x.CreatedDateTime >= startDate && x.CreatedDateTime <= endDate);
            var report = receiptTemplates.ProductSalesReport(orders);

            PdfConverter.ConvertToPdf(report, filePath);

            pdfViewer1.LoadDocument(filePath);
        }       
    }
}
