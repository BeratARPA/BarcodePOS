using System.Globalization;

namespace WindowsFormsAppUI.Helpers
{
    public static class StringExtensions
    {
        public static string ToTitleCase(this string text)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text);
        }
    }    
}
