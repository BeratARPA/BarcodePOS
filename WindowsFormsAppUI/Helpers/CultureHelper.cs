using System.Globalization;
using System.Resources;
using System.Threading;

namespace WindowsFormsAppUI.Helpers
{
    public class CultureHelper
    {
        private ResourceManager _resourceManager;

        public CultureHelper()
        {
            _resourceManager = new ResourceManager(typeof(Localization.Properties.Resources));
        }

        public void ChangeCulture(string language)
        {
            CultureInfo cultureInfo = CultureInfo.GetCultureInfo(language);
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }

        public string GetText(string name)
        {
            return _resourceManager.GetString(name);
        }
    }
}
