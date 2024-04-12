using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsAppUI.Forms;

namespace WindowsFormsAppUI.Helpers
{
    public class NavigationManager
    {
        public static async Task OpenForm(Form form, DockStyle dockStyle, Panel parentPanel)
        {
            // LoadingScreenForm'u oluştur ve parentPanel'e ekle
            LoadingScreenForm loadingScreen = new LoadingScreenForm();
            loadingScreen.TopLevel = false;
            loadingScreen.Dock = DockStyle.Fill;
            parentPanel.Controls.Add(loadingScreen);
            loadingScreen.Show();

            // Form kapatma işlemleri
            FormCollection formCollection = Application.OpenForms;
            for (int i = formCollection.Count - 1; i >= 0; i--)
            {
                if (formCollection[i].Name != "ShellForm" && formCollection[i].Name != "DashboardForm" && formCollection[i].Name != "PersonalizationForm" && !formCollection[i].Name.Contains("CustomerCallingForm") && formCollection[i].Name != "ClientConsoleForm" && formCollection[i].Name != "OpenWindowsForm" && formCollection[i].Name != "ReportsForm")
                {
                    formCollection[i].Close();
                }
            }

            // ParentPanel'i temizle
            parentPanel.Controls.Clear();

            // Formu ara ve kontrol et
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
                // Formu ekle
                form.Dock = dockStyle;
                form.TopLevel = false;
                form.TopMost = true;

                // Formu yüklediğinde LoadingScreenForm'u kapat
                form.Load += (sender, e) =>
                {
                    loadingScreen.Close();
                };

                // Formu göster
                form.Show();
                parentPanel.Controls.Add(form);
            }
        }
    }
}
