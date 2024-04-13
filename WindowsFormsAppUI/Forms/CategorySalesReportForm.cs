using Database.Data;
using Database.Models;
using System;
using System.IO;
using System.Windows.Forms;
using WindowsFormsAppUI.Helpers;

namespace WindowsFormsAppUI.Forms
{
    public partial class CategorySalesReportForm : Form
    {
        private readonly IGenericRepository<Order> _genericRepositoryOrder = new GenericRepository<Order>(GlobalVariables.SQLContext);
        private readonly IGenericRepository<Ticket> _genericRepositoryTicket = new GenericRepository<Ticket>(GlobalVariables.SQLContext);
        private readonly IGenericRepository<Product> _genericRepositoryProduct = new GenericRepository<Product>(GlobalVariables.SQLContext);
        private readonly IGenericRepository<Category> _genericRepositoryCategory = new GenericRepository<Category>(GlobalVariables.SQLContext);

        private ReceiptTemplates receiptTemplates = new ReceiptTemplates();

        public CategorySalesReportForm()
        {
            InitializeComponent();
        }

        private void CategorySalesReportForm_Load(object sender, EventArgs e)
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
            string filePath = Path.Combine(FolderLocations.barcodePOSFolderPath, "CategorySalesReport.pdf");

            pdfViewer1.CloseDocument();

            if (File.Exists(filePath))
                File.Delete(filePath);

            DateTime startDate = dateTimePickerStart.DateTime.Date;
            DateTime endDate = dateTimePickerEnd.DateTime.Date;
            endDate = endDate.AddDays(1);

            var tickets = _genericRepositoryTicket.GetAllAsNoTracking(x => x.Date >= startDate && x.Date <= endDate);
            var orders = _genericRepositoryOrder.GetAllAsNoTracking();
            var products = _genericRepositoryProduct.GetAllAsNoTracking();
            var categories = _genericRepositoryCategory.GetAllAsNoTracking();
            var report = receiptTemplates.CategorySalesReport(tickets, orders, products, categories);

            PdfConverter.ConvertToPdf(report, filePath);

            pdfViewer1.LoadDocument(filePath);
        }
    }
}
