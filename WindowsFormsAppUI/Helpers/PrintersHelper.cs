using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Xps;

namespace WindowsFormsAppUI.Helpers
{
    public enum PrintType
    {
        MM80,
        MM58
    }

    internal static class PrintersHelper
    {
        private static LocalPrintServer _printServer;
        internal static LocalPrintServer PrintServer
        {
            get { return _printServer ?? (_printServer = new LocalPrintServer()); }
        }

        private static PrintQueueCollection _printers;
        internal static PrintQueueCollection Printers
        {
            get
            {
                return _printers ?? (_printers = PrintServer.GetPrintQueues(new[]
                                                                            {
                                                                                EnumeratedPrintQueueTypes.Local,
                                                                                EnumeratedPrintQueueTypes.Connections
                                                                            }));
            }
        }

        public static PrintQueue GetPrinter(string shareName)
        {
            var result = FindPrinterByName(shareName);
            if (result == null) result = FindPrinterByShareName(shareName);
            return result;
        }

        public static PrintQueue FindPrinterByShareName(string shareName)
        {
            return Printers.FirstOrDefault(x => x.HostingPrintServer.Name + "\\" + x.ShareName == shareName);
        }

        internal static PrintQueue FindPrinterByName(string printerName)
        {
            return Printers.FirstOrDefault(x => x.FullName == printerName);
        }

        public static IEnumerable<string> GetPrinterNames()
        {
            return Printers.Select(printer => printer.FullName).ToList();
        }

        public static void ResetCache()
        {
            _printServer = null;
        }

        internal static void PrintFlowDocument(PrintQueue pq, FlowDocument document)
        {
            // Clone the source document's content into a new FlowDocument.
            // This is because the pagination for the printer needs to be
            // done differently than the pagination for the displayed page.
            // We print the copy, rather that the original FlowDocument.
            System.IO.MemoryStream s = new System.IO.MemoryStream();
            TextRange source = new TextRange(document.ContentStart, document.ContentEnd);
            source.Save(s, DataFormats.Xaml);
            FlowDocument copy = new FlowDocument();
            TextRange dest = new TextRange(copy.ContentStart, copy.ContentEnd);
            dest.Load(s, DataFormats.Xaml);

            // Create a XpsDocumentWriter object, implicitly opening a Windows common print dialog,
            // and allowing the user to select a printer.

            // get information about the dimensions of the seleted printer+media.
            XpsDocumentWriter docWriter = PrintQueue.CreateXpsDocumentWriter(pq);
            PageImageableArea ia = pq.GetPrintCapabilities().PageImageableArea;
            PrintTicket pt = pq.UserPrintTicket;

            if (docWriter != null && ia != null)
            {
                DocumentPaginator paginator = ((IDocumentPaginatorSource)copy).DocumentPaginator;

                // Change the PageSize and PagePadding for the document to match the CanvasSize for the printer device.
                paginator.PageSize = new Size((double)pt.PageMediaSize.Width, (double)pt.PageMediaSize.Height);
                Thickness t = new Thickness(3);  // copy.PagePadding;
                copy.PagePadding = new Thickness(
                                 Math.Max(ia.OriginWidth, t.Left),
                                   Math.Max(ia.OriginHeight, t.Top),
                                   Math.Max((double)pt.PageMediaSize.Width - (ia.OriginWidth + ia.ExtentWidth), t.Right),
                                   Math.Max((double)pt.PageMediaSize.Height - (ia.OriginHeight + ia.ExtentHeight), t.Bottom));

                copy.ColumnWidth = double.PositiveInfinity;
                copy.FontFamily = new System.Windows.Media.FontFamily("Segoe UI Semibold");
                //copy.PageWidth = 528; // allow the page to be the natural with of the output device

                // Send content to the printer.
                docWriter.Write(paginator);
            }
        }
    }
}
