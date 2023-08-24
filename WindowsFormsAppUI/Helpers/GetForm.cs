using System.Windows.Forms;

namespace WindowsFormsAppUI.Helpers
{
    public class GetForm
    {
        public static Form Get(string formName)
        {
            Form form = Application.OpenForms[formName];
            if (form != null)
            {
                return form;
            }

            return null;
        }
    }
}
