using System.Windows.Forms;

namespace WindowsFormsAppUI.Helpers
{
    public class NavigationManager
    {
        public static void OpenForm(Form form, DockStyle dockStyle, Panel parentPanel)
        {
            FormCollection formCollection = Application.OpenForms;
            for (int i = formCollection.Count - 1; i >= 0; i--)
            {
                if (formCollection[i].Name != "ShellForm" && formCollection[i].Name != "DashboardForm" && formCollection[i].Name != "PersonalizationForm" && !formCollection[i].Name.Contains("CustomerCallingForm") && formCollection[i].Name != "ClientConsoleForm" && formCollection[i].Name != "OpenWindowsForm")
                {
                    formCollection[i].Close();
                }
            }

            parentPanel.Controls.Clear();

            Form formSearch = Application.OpenForms[form.Name];
            if (formSearch != null)
            {
                formSearch.Dock = dockStyle;
                formSearch.TopLevel = false;
                formSearch.TopMost = true;
                formSearch.Show();

                parentPanel.Controls.Add(formSearch);
            }
            else
            {
                form.Dock = dockStyle;
                form.TopLevel = false;
                form.TopMost = true;
                form.Show();

                parentPanel.Controls.Add(form);
            }
        }
    }
}
