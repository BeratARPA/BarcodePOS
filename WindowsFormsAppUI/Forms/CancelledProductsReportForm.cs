using Database.Data;
using Database.Models;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsAppUI.Helpers;

namespace WindowsFormsAppUI.Forms
{
    public partial class CancelledProductsReportForm : Form
    {
        private readonly IGenericRepository<Ticket> _genericRepositoryTicket = new GenericRepository<Ticket>(GlobalVariables.SQLContext);

        private ReceiptTemplates receiptTemplates = new ReceiptTemplates();

        public CancelledProductsReportForm()
        {
            InitializeComponent();
            UpdateUILanguage();
        }

        private void CancelledProductsReportForm_Load(object sender, EventArgs e)
        {
            dateTimePickerStart.DateTime = DateTime.Now;
            dateTimePickerEnd.DateTime = DateTime.Now;
        }

        public void UpdateUILanguage()
        {
            buttonPrint.Text = GlobalVariables.CultureHelper.GetText("Print");
            buttonRefresh.Text = GlobalVariables.CultureHelper.GetText("Refresh");
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            string filePath = Path.Combine(FolderLocations.barcodePOSFolderPath, "RevenuesReport.pdf");

            pdfViewer1.CloseDocument();

            if (File.Exists(filePath))
                File.Delete(filePath);

            var ticket = _genericRepositoryTicket.GetById(18);
          //  var report = receiptTemplates.KitchenTemplate(ticket.Orders.ToList(), ticket, "PDF24");
            //PdfConverter.ConvertToPdf(report, filePath);

            pdfViewer1.LoadDocument(filePath);
        }
    }
}
