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
            buttonCategories.Text = GlobalVariables.CultureHelper.GetText("Categories");
            buttonProducts.Text = GlobalVariables.CultureHelper.GetText("Products");
            buttonPaymentTypes.Text = GlobalVariables.CultureHelper.GetText("PaymentTypes");          
        }

        private void buttonCategories_Click(object sender, EventArgs e)
        {
            NavigationManager.OpenForm(new CategoryPersonalizationForm(), DockStyle.Fill, panelMain);
        }

        private void buttonProducts_Click(object sender, EventArgs e)
        {
            NavigationManager.OpenForm(new ProductPersonalizationForm(), DockStyle.Fill, panelMain);
        }

        private void buttonPaymentTypes_Click(object sender, EventArgs e)
        {
            NavigationManager.OpenForm(new PaymentTypePersonalizationForm(), DockStyle.Fill, panelMain);
        }
    }
}
