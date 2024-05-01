using System;
using System.Windows.Forms;
using WindowsFormsAppUI.Helpers;

namespace WindowsFormsAppUI.Forms.ManagementForms
{
    public partial class ManagementForm : Form
    {
        public ManagementForm()
        {
            InitializeComponent();
            UpdateUILanguage();
        }

        public void UpdateUILanguage()
        {
            accordionControlElement1.Text = GlobalVariables.CultureHelper.GetText("Settings");
            accordionControlElement2.Text = GlobalVariables.CultureHelper.GetText("Products");
            accordionControlElement3.Text = GlobalVariables.CultureHelper.GetText("Tickets");
            accordionControlElement4.Text = GlobalVariables.CultureHelper.GetText("Tables");
            accordionControlElement5.Text = GlobalVariables.CultureHelper.GetText("Users");

            accordionControlElementGeneral.Text = GlobalVariables.CultureHelper.GetText("General");
            accordionControlElementDatabaseBackups.Text = GlobalVariables.CultureHelper.GetText("DatabaseBackups");
            accordionControlElementDatabaseType.Text = GlobalVariables.CultureHelper.GetText("DatabaseType");
            accordionControlElementAbout.Text = GlobalVariables.CultureHelper.GetText("About");
            accordionControlElementMessageServer.Text = GlobalVariables.CultureHelper.GetText("MessageServer");
            accordionControlElementCategoryList.Text = GlobalVariables.CultureHelper.GetText("CategoryList");
            accordionControlElementProductList.Text = GlobalVariables.CultureHelper.GetText("ProductList");
            accordionControlElementPaymentTypeList.Text = GlobalVariables.CultureHelper.GetText("PaymentTypeList");
            accordionControlElementSectionList.Text = GlobalVariables.CultureHelper.GetText("SectionList");
            accordionControlElementTableList.Text = GlobalVariables.CultureHelper.GetText("TableList");
            accordionControlElementRoleList.Text = GlobalVariables.CultureHelper.GetText("RoleList");
            accordionControlElementUserList.Text = GlobalVariables.CultureHelper.GetText("UserList");
        }

        private void accordionControlElementGeneral_Click(object sender, EventArgs e)
        {
            NavigationManager.OpenForm(new ManagementGeneralForm(), DockStyle.Fill, panelMain);
        }

        private void accordionControlElementDatabaseBackups_Click(object sender, EventArgs e)
        {
            NavigationManager.OpenForm(new ManagementDatabaseBackupsForm(), DockStyle.Fill, panelMain);
        }

        private void accordionControlElementDatabaseType_Click(object sender, EventArgs e)
        {
            NavigationManager.OpenForm(new ManagementDatabaseTypeForm(), DockStyle.Fill, panelMain);
        }

        private void accordionControlElementAbout_Click(object sender, EventArgs e)
        {
            NavigationManager.OpenForm(new ManagementAboutForm(), DockStyle.Fill, panelMain);
        }

        private void accordionControlElementMessageServer_Click(object sender, EventArgs e)
        {
            NavigationManager.OpenForm(new ManagementMessageServerForm(), DockStyle.Fill, panelMain);
        }

        private void accordionControlElementCategoryList_Click(object sender, EventArgs e)
        {
            NavigationManager.OpenForm(new ManagementCategoryListForm(), DockStyle.Fill, panelMain);
        }

        private void accordionControlElementProductList_Click(object sender, EventArgs e)
        {
            NavigationManager.OpenForm(new ManagementProductListForm(), DockStyle.Fill, panelMain);
        }

        private void accordionControlElementPaymentTypeList_Click(object sender, EventArgs e)
        {
            NavigationManager.OpenForm(new ManagementPaymentTypeListForm(), DockStyle.Fill, panelMain);
        }

        private void accordionControlElementSectionList_Click(object sender, EventArgs e)
        {
            NavigationManager.OpenForm(new ManagementSectionListForm(), DockStyle.Fill, panelMain);
        }

        private void accordionControlElementTableList_Click(object sender, EventArgs e)
        {
            NavigationManager.OpenForm(new ManagementTableListForm(), DockStyle.Fill, panelMain);
        }

        private void accordionControlElementRoleList_Click(object sender, EventArgs e)
        {
            NavigationManager.OpenForm(new ManagementRoleListForm(), DockStyle.Fill, panelMain);
        }

        private void accordionControlElementUserList_Click(object sender, EventArgs e)
        {
            NavigationManager.OpenForm(new ManagementUserListForm(), DockStyle.Fill, panelMain);
        }       
    }
}
