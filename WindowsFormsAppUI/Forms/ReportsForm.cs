using System.Windows.Forms;
using WindowsFormsAppUI.Helpers;

namespace WindowsFormsAppUI.Forms
{
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();
            UpdateUILanguage();
        }

        public void UpdateUILanguage()
        {
            accordionControlElementEndOfTheDay.Text = GlobalVariables.CultureHelper.GetText("EndOfTheDay");
            accordionControlElementRevenues.Text = GlobalVariables.CultureHelper.GetText("Revenues");
            accordionControlElementCategorySales.Text = GlobalVariables.CultureHelper.GetText("CategorySales");
            accordionControlElementProductSales.Text = GlobalVariables.CultureHelper.GetText("ProductSales");
            accordionControlElementCancelledProducts.Text = GlobalVariables.CultureHelper.GetText("CancelledProducts");
            accordionControlElementTickets.Text = GlobalVariables.CultureHelper.GetText("Tickets");
            accordionControlElementSalesTypes.Text = GlobalVariables.CultureHelper.GetText("SalesTypes");
            accordionControlElementUsers.Text = GlobalVariables.CultureHelper.GetText("Users");
        }

        private void accordionControlElementRevenues_Click(object sender, System.EventArgs e)
        {
            NavigationManager.OpenForm(new RevenuesReportForm(), DockStyle.Fill, panelMain);
        }
    }
}
