using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsAppUI.Forms;

namespace WindowsFormsAppUI.Helpers
{
    public class NavigationManager
    {
        public static async Task OpenForm(Form form, DockStyle dockStyle, Panel parentPanel, bool loadingForm = true)
        {
            parentPanel.Controls.Clear();

            FormCollection formCollection = Application.OpenForms;
            for (int i = formCollection.Count - 1; i >= 0; i--)
            {
                if (formCollection[i].Name != "ShellForm" && formCollection[i].Name != "DashboardForm" && formCollection[i].Name != "PersonalizationForm" && !formCollection[i].Name.Contains("CustomerCallingForm") && formCollection[i].Name != "ClientConsoleForm" && formCollection[i].Name != "OpenWindowsForm" && formCollection[i].Name != "ReportsForm")
                {
                    formCollection[i].Close();
                }
            }

            LoadingScreenForm loadingScreen = null;
            if (loadingForm)
            {
                loadingScreen = new LoadingScreenForm();
                loadingScreen.Dock = dockStyle;
                loadingScreen.TopLevel = false;
                loadingScreen.TopMost = true;
                loadingScreen.Show();

                parentPanel.Controls.Add(loadingScreen);
            }

            Form formSearch = Application.OpenForms[form.Name];
            if (formSearch != null)
            {
                formSearch.Dock = dockStyle;
                formSearch.TopLevel = false;
                formSearch.TopMost = true;

                if (loadingForm)
                {
                    formSearch.Load += (sender, e) =>
                    {
                        loadingScreen.Close();
                        loadingScreen.Dispose();
                    };
                }

                formSearch.Show();

                parentPanel.Controls.Add(formSearch);
            }
            else
            {
                form.Dock = dockStyle;
                form.TopLevel = false;
                form.TopMost = true;

                if (loadingForm)
                {
                    form.Load += (sender, e) =>
                    {
                        loadingScreen.Close();
                        loadingScreen.Dispose();
                    };
                }

                form.Show();

                parentPanel.Controls.Add(form);
            }
        }
    }
}
