using System;
using System.IO;
using System.IO.Packaging;
using System.Windows.Documents;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;

namespace WindowsFormsAppUI.Helpers
{
    public static class XpsConverter
    {
        public static void ConvertToXps<T>(T content, string filePath) where T : IDocumentPaginatorSource
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content), "Content cannot be null.");
            }

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                using (Package package = Package.Open(fileStream, FileMode.Create))
                {
                    XpsDocument xpsDocument = new XpsDocument(package);
                    XpsDocumentWriter writer = XpsDocument.CreateXpsDocumentWriter(xpsDocument);
                    writer.Write(content.DocumentPaginator);
                    xpsDocument.Close();                   
                }
            }
        }
    }
}
