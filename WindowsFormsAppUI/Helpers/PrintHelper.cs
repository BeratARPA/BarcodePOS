using System;
using System.Collections.Generic;
using System.Drawing;
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
        string name;
        int paperWidth;
        int paperHeight=100;
        PrintType printType;

        public PrintHelper(PrintType printType, string name)
        {
            this.printType = printType;
            this.name = name;

            printDocument.PrintPage += PrintDocument_PrintPage;

            paperWidth = UnitConvert.MmToPixel(UnitConvert.PrintTypeToMM(printType));

            PrintController printController = new StandardPrintController();
            printDocument.PrintController = printController;

            // printDocument.Print();
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.ShowDialog();
            printDocument.Dispose();
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            List<List<string>> tableData = new List<List<string>>
            {
                new List<string> { "Ürün 1", "2", "10", "20"},
                new List<string> { "Ürün 2", "4", "15", "60" },
                new List<string> { "Ürün 3", "4", "15", "60" },
                new List<string> { "Ürün 4", "4", "15", "60" },
            };
            List<string> headers = new List<string> { "Ürün", "Birim", "Ölçü", "Fiyat" };

            SimpleReport simpleReport = new SimpleReport(e, paperWidth, printType);

            simpleReport.DrawText("POS Receipt", true, StringAlignment.Center);
            simpleReport.DrawLine();
            simpleReport.DrawText("Date: " + DateTime.Now.ToString());
            simpleReport.DrawLine();
            simpleReport.DrawTable(tableData, headers);
            simpleReport.DrawLine();
            simpleReport.DrawText("Total:", "$30.00");
        }
    }
}
