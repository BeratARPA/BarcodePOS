using System.Drawing;
using ZXing;

namespace WindowsFormsAppUI.Helpers
{
    public class BarcodeHelper
    {
        public static Bitmap GenerateEAN13Barcode(string text)
        {
            var writer = new BarcodeWriter
            {               
                Format = BarcodeFormat.CODE_128,
                Options = new ZXing.Common.EncodingOptions
                {                
                    Height = 50,
                    
                }                
            };

            return writer.Write(text);
        }
    }
}
