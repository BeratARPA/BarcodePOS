using System.IO;
using System.IO.Packaging;
using System.Windows.Documents;
using System.Windows.Xps.Packaging;

namespace WindowsFormsAppUI.Helpers
{
    public static class PdfConverter
    {
        public static void ConvertToPdf(FlowDocument flowDocument, string filePath)
        {
            var stream = new MemoryStream();
            using (var package = Package.Open(stream, FileMode.Create))
            using (var xpsDoc = new XpsDocument(package))
            {
                var xpsDocWriter = XpsDocument.CreateXpsDocumentWriter(xpsDoc);
                xpsDocWriter.Write(((IDocumentPaginatorSource)flowDocument).DocumentPaginator);
            }

            var pdfXpsDoc = PdfSharp.Xps.XpsModel.XpsDocument.Open(stream);
            PdfSharp.Xps.XpsConverter.Convert(pdfXpsDoc, filePath, 0);
        }        
    }
}
