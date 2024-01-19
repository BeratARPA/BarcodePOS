using DevExpress.XtraEditors;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsAppUI.Helpers;

namespace WindowsFormsAppUI.Forms
{
    public partial class DashboardForm : Form
    {
        TileItem tileItem;
        private bool editMode = false;
        string navigationLayoutPath = Path.Combine(FolderLocations.barcodePOSFolderPath, "NavigationLayouts.xml");

        public DashboardForm()
        {
            InitializeComponent();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            LoadNavigationLayout();
            UpdateUILanguage();
        }

        public void UpdateUILanguage()
        {
            simpleButtonLarge.Text = GlobalVariables.CultureHelper.GetText("Large");
            simpleButtonWide.Text = GlobalVariables.CultureHelper.GetText("Wide");
            simpleButtonMedium.Text = GlobalVariables.CultureHelper.GetText("Medium");
            simpleButtonSmall.Text = GlobalVariables.CultureHelper.GetText("Small");
            simpleButtonEditMode.Text = GlobalVariables.CultureHelper.GetText("EditMode");
            simpleButtonSave.Text = GlobalVariables.CultureHelper.GetText("Save");
            tileItemReports.Text = GlobalVariables.CultureHelper.GetText("Reports");
            tileItemStocks.Text = GlobalVariables.CultureHelper.GetText("Stocks");
            tileItemCreateProductLabel.Text = GlobalVariables.CultureHelper.GetText("CreateProductLabel");
            tileItemPOS.Text = GlobalVariables.CultureHelper.GetText("POS");
            tileItemTickets.Text = GlobalVariables.CultureHelper.GetText("Tickets");
            tileItemTechnicalSupport.Text = GlobalVariables.CultureHelper.GetText("TechnicalSupport");
            tileItemManagement.Text = GlobalVariables.CultureHelper.GetText("Management");
            tileItemPersonalization.Text = GlobalVariables.CultureHelper.GetText("Personalization");
            tileItemLogout.Text = GlobalVariables.CultureHelper.GetText("Logout");
            tileItemTables.Text = GlobalVariables.CultureHelper.GetText("Tables");
        }

        private void tileItemManagement_ItemClick(object sender, TileItemEventArgs e)
        {
            if (!editMode)
            {
                NavigationManager.OpenForm(new ManagementForm(), DockStyle.Fill, GlobalVariables.ShellForm.panelMain);
                GlobalVariables.ShellForm.buttonMainMenu.Enabled = true;
            }
        }

        private void tileItemTickets_ItemClick(object sender, TileItemEventArgs e)
        {
            if (!editMode)
            {
                NavigationManager.OpenForm(new TicketsForm(), DockStyle.Fill, GlobalVariables.ShellForm.panelMain);
                GlobalVariables.ShellForm.buttonMainMenu.Enabled = true;
            }
        }

        private void tileItemPersonalization_ItemClick(object sender, TileItemEventArgs e)
        {
            if (!editMode)
            {
                NavigationManager.OpenForm(new PersonalizationForm(), DockStyle.Fill, GlobalVariables.ShellForm.panelMain);
                GlobalVariables.ShellForm.buttonMainMenu.Enabled = true;
            }
        }

        private void tileItemPOS_ItemClick(object sender, TileItemEventArgs e)
        {
            if (!editMode)
            {
                NavigationManager.OpenForm(new POSForm(), DockStyle.Fill, GlobalVariables.ShellForm.panelMain);
            }
        }

        private void tileItemReports_ItemClick(object sender, TileItemEventArgs e)
        {
            if (!editMode)
            {
                NavigationManager.OpenForm(new ReportsForm(), DockStyle.Fill, GlobalVariables.ShellForm.panelMain);
                GlobalVariables.ShellForm.buttonMainMenu.Enabled = true;
            }
        }

        private void tileItemLogout_ItemClick(object sender, TileItemEventArgs e)
        {
            if (!editMode)
            {
                LoggedInUser.Logout();
            }
        }

        private void tileItemStocks_ItemClick(object sender, TileItemEventArgs e)
        {
            if (!editMode)
            {

            }
        }

        private void tileItemCreateProductLabel_ItemClick(object sender, TileItemEventArgs e)
        {
            if (!editMode)
            {
                NavigationManager.OpenForm(new ProductLabelDesignForm(), DockStyle.Fill, GlobalVariables.ShellForm.panelMain);
                GlobalVariables.ShellForm.buttonMainMenu.Enabled = true;
            }
        }

        private void tileItemTechnicalSupport_ItemClick(object sender, TileItemEventArgs e)
        {
            if (!editMode)
            {
                NavigationManager.OpenForm(new TechnicalSupportForm(), DockStyle.Fill, GlobalVariables.ShellForm.panelMain);
                GlobalVariables.ShellForm.buttonMainMenu.Enabled = true;
            }
        }

        private void tileItemTables_ItemClick(object sender, TileItemEventArgs e)
        {
            if (!editMode)
            {
                NavigationManager.OpenForm(new TablesForm(), DockStyle.Fill, GlobalVariables.ShellForm.panelMain);
                GlobalVariables.ShellForm.buttonMainMenu.Enabled = true;
            }
        }

        private void simpleButtonEditMode_Click(object sender, EventArgs e)
        {
            if (!editMode)
            {
                editMode = true;
                tileControl.AllowDrag = true;
                simpleButtonSave.Visible = true;
            }
            else
            {
                editMode = false;
                tileControl.AllowDrag = false;
                simpleButtonSave.Visible = false;

                simpleButtonSmall.Visible = false;
                simpleButtonMedium.Visible = false;
                simpleButtonWide.Visible = false;
                simpleButtonLarge.Visible = false;
            }
        }

        public void LoadNavigationLayout()
        {
            try
            {
                if (File.Exists(navigationLayoutPath))
                {
                    tileControl.RestoreLayoutFromXml(navigationLayoutPath);

                    var tileGroups = tileControl.Groups.ToList();
                    for (int i = 0; i < tileGroups.Count; i++)
                    {
                        var tileItems = tileGroups[i].Items.ToList();
                        for (int j = 0; j < tileItems.Count; j++)
                        {
                            ItemSize((int)tileGroups[i].Items[j].ItemSize, tileGroups[i].Items[j]);
                        }
                    }
                }
            }
            catch { }
        }

        public void ItemSize(int itemSize, TileItem tileItem)
        {
            switch (itemSize)
            {
                case 1:
                    #region Small
                    tileItem.ItemSize = (TileItemSize)itemSize;
                    tileItem.ImageToTextAlignment = TileControlImageToTextAlignment.Top;
                    tileItem.ImageAlignment = TileItemContentAlignment.MiddleCenter;
                    tileItem.ImageScaleMode = TileItemImageScaleMode.Stretch;
                    tileItem.Elements[0].ImageOptions.ImageSize = new Size(32, 32);
                    tileItem.AppearanceItem.Normal.ForeColor = Color.FromArgb(157, 156, 161);
                    tileItem.AppearanceItem.Normal.Font = new Font("Microsoft Sans Serif", 1);
                    tileItem.Elements[0].ImageOptions.ImageToTextIndent = 0;
                    #endregion
                    break;
                case 2:
                    #region Medium
                    tileItem.ItemSize = (TileItemSize)itemSize;
                    tileItem.ImageToTextAlignment = TileControlImageToTextAlignment.Top;
                    tileItem.ImageAlignment = TileItemContentAlignment.MiddleCenter;
                    tileItem.ImageScaleMode = TileItemImageScaleMode.Stretch;
                    tileItem.Elements[0].ImageOptions.ImageSize = new Size(42, 42);
                    tileItem.AppearanceItem.Normal.ForeColor = Color.White;
                    tileItem.AppearanceItem.Normal.Font = new Font("Microsoft Sans Serif", 10);
                    tileItem.Elements[0].ImageOptions.ImageToTextIndent = 25;
                    #endregion
                    break;
                case 3:
                    #region Wide
                    tileItem.ItemSize = (TileItemSize)itemSize;
                    tileItem.ImageToTextAlignment = TileControlImageToTextAlignment.Left;
                    tileItem.ImageAlignment = TileItemContentAlignment.MiddleCenter;
                    tileItem.ImageScaleMode = TileItemImageScaleMode.Stretch;
                    tileItem.Elements[0].ImageOptions.ImageSize = new Size(82, 82);
                    tileItem.AppearanceItem.Normal.ForeColor = Color.White;
                    tileItem.AppearanceItem.Normal.Font = new Font("Microsoft Sans Serif", 15);
                    tileItem.Elements[0].ImageOptions.ImageToTextIndent = 25;
                    #endregion
                    break;
                case 4:
                    #region Large
                    tileItem.ItemSize = (TileItemSize)itemSize;
                    tileItem.ImageToTextAlignment = TileControlImageToTextAlignment.Top;
                    tileItem.ImageAlignment = TileItemContentAlignment.MiddleCenter;
                    tileItem.ImageScaleMode = TileItemImageScaleMode.Stretch;
                    tileItem.Elements[0].ImageOptions.ImageSize = new Size(82, 82);
                    tileItem.AppearanceItem.Normal.ForeColor = Color.White;
                    tileItem.AppearanceItem.Normal.Font = new Font("Microsoft Sans Serif", 15);
                    tileItem.Elements[0].ImageOptions.ImageToTextIndent = 25;
                    #endregion
                    break;
                default:
                    #region Default
                    tileItem.ItemSize = TileItemSize.Medium;
                    tileItem.ImageToTextAlignment = TileControlImageToTextAlignment.Top;
                    tileItem.ImageAlignment = TileItemContentAlignment.MiddleCenter;
                    tileItem.ImageScaleMode = TileItemImageScaleMode.Stretch;
                    tileItem.Elements[0].ImageOptions.ImageSize = new Size(42, 42);
                    tileItem.AppearanceItem.Normal.ForeColor = Color.White;
                    tileItem.AppearanceItem.Normal.Font = new Font("Microsoft Sans Serif", 10);
                    tileItem.Elements[0].ImageOptions.ImageToTextIndent = 25;
                    #endregion
                    break;
            }
        }

        private void simpleButtonSave_Click(object sender, EventArgs e)
        {
            try { File.Delete(navigationLayoutPath); } catch { }

            FileStream fileStream = new FileStream(navigationLayoutPath, FileMode.OpenOrCreate, FileAccess.Write);
            tileControl.SaveLayoutToStream(fileStream);
            fileStream.Close();

            editMode = false;
            tileControl.AllowDrag = false;
            simpleButtonSave.Visible = false;

            simpleButtonSmall.Visible = false;
            simpleButtonMedium.Visible = false;
            simpleButtonWide.Visible = false;
            simpleButtonLarge.Visible = false;

            GlobalVariables.MessageBoxForm.ShowMessage(GlobalVariables.CultureHelper.GetText("TheChangesHaveBeenSaved."), GlobalVariables.CultureHelper.GetText("Information"), MessageButton.OK, MessageIcon.Information);
        }

        private void tileItemReports_RightItemClick(object sender, TileItemEventArgs e)
        {
            tileItem = sender as TileItem;

            if (editMode)
            {
                simpleButtonSmall.Visible = true;
                simpleButtonMedium.Visible = true;
                simpleButtonWide.Visible = true;
                simpleButtonLarge.Visible = true;
            }
        }

        private void simpleButtonLarge_Click(object sender, EventArgs e)
        {
            SimpleButton button = sender as SimpleButton;
            int itemSize = Convert.ToInt32(button.Tag);

            ItemSize(itemSize, tileItem);
        }
    }
}
