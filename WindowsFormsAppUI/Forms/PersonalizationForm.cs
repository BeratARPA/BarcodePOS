using System;
using System.Windows.Forms;
using WindowsFormsAppUI.Helpers;

namespace WindowsFormsAppUI.Forms
{
    public partial class PersonalizationForm : Form
    {
        public PersonalizationForm()
        {
            InitializeComponent();
            UpdateUILanguage();
        }

        public void UpdateUILanguage()
        {
            accordionControlElementCategories.Text = GlobalVariables.CultureHelper.GetText("Categories");
            accordionControlElementProducts.Text = GlobalVariables.CultureHelper.GetText("Products");
            accordionControlElementPaymentTypes.Text = GlobalVariables.CultureHelper.GetText("PaymentTypes");          
        }

        private void accordionControlElementCategories_Click(object sender, EventArgs e)
        {
            NavigationManager.OpenForm(new CategoryPersonalizationForm(), DockStyle.Fill, panelMain);
        }

        private void accordionControlElementProducts_Click(object sender, EventArgs e)
        {
            NavigationManager.OpenForm(new ProductPersonalizationForm(), DockStyle.Fill, panelMain);
        }

        private void accordionControlElementPaymentTypes_Click(object sender, EventArgs e)
        {
            NavigationManager.OpenForm(new PaymentTypePersonalizationForm(), DockStyle.Fill, panelMain);
        }
    }
}
