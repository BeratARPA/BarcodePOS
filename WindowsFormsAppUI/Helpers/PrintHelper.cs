using System.Drawing.Printing;
using System.Windows.Forms;

namespace WindowsFormsAppUI.Helpers
{
    public enum PrintType
    {
        MM80,
        MM58
    }

    public class PrintHelper
    {
        PrintDocument printDocument = new PrintDocument();
        PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();

        public PrintHelper(PrintType printType, string name)
        {
            printDocument.PrintPage += new PrintPageEventHandler(OnPrintPage);

            int size = UnitConvert.PrintTypeToMM(printType);

            PaperSize paperSize = new PaperSize(name, size, size);
            printDocument.DefaultPageSettings.PaperSize = paperSize;

            PrintController printController = new StandardPrintController();
            printDocument.PrintController = printController;

            // printDocument.Print();
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.ShowDialog();
        }

        private void OnPrintPage(object sender, PrintPageEventArgs e)
        {
           
        }
    }
}
