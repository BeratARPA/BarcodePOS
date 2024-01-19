using Database.Data;
using Database.Models;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsAppUI.Helpers;

namespace WindowsFormsAppUI.Forms
{
    public partial class TablesForm : Form
    {
        private readonly IGenericRepository<Section> _genericRepositorySection = new GenericRepository<Section>(GlobalVariables.SQLContext);
        private readonly IGenericRepository<Table> _genericRepositoryTable = new GenericRepository<Table>(GlobalVariables.SQLContext);
        private readonly IGenericRepository<Ticket> _genericRepositoryTicket = new GenericRepository<Ticket>(GlobalVariables.SQLContext);

        private List<Section> _sections = new List<Section>();
        private List<Table> _tables = new List<Table>();

        public TablesForm()
        {
            InitializeComponent();
        }

        private void TablesForm_Load(object sender, EventArgs e)
        {
            _sections = _genericRepositorySection.GetAll();
            _tables = _genericRepositoryTable.GetAll();

            CreateSections();
        }

        public void CreateSections()
        {
            foreach (var section in _sections)
            {
                TileItem tileItemSection = new TileItem();

                tileItemSection.AppearanceItem.Normal.BackColor = Color.FromArgb(157, 156, 161);
                tileItemSection.AppearanceItem.Normal.BorderColor = Color.FromArgb(255, 202, 10);
                tileItemSection.AppearanceItem.Hovered.BackColor = Color.FromArgb(255, 202, 10);

                tileItemSection.Tag = section.SectionId;
                tileItemSection.Text = section.Title;
                tileItemSection.ItemClick += tileItemSection_Click;

                tileGroupSections.Items.Add(tileItemSection);
            }
        }

        public void CreateTables(int sectionId)
        {
            tileGroupTables.Items.Clear();

            foreach (var table in _tables.FindAll(x => x.SectionId == sectionId))
            {
                TileItem tileItemTable = new TileItem();

                tileItemTable.AppearanceItem.Normal.BackColor = Color.FromArgb(157, 156, 161);
                tileItemTable.AppearanceItem.Normal.BorderColor = Color.FromArgb(255, 202, 10);
                tileItemTable.AppearanceItem.Hovered.BackColor = Color.FromArgb(255, 202, 10);

                tileItemTable.Tag = table.TableId;
                tileItemTable.Text = table.Name;
                tileItemTable.ItemClick += tileItemTable_Click;

                var ticket = _genericRepositoryTicket.Get(x => x.TableId == table.TableId && x.IsOpened == true);
                if (ticket != null)
                {
                    tileItemTable.AppearanceItem.Normal.BackColor = Color.CadetBlue;
                }

                tileGroupTables.Items.Add(tileItemTable);
            }
        }

        private void tileItemTable_Click(object sender, TileItemEventArgs e)
        {
            TileItem tableItem = (TileItem)sender;

            int tableId = Convert.ToInt32(tableItem.Tag);
            Table table = _genericRepositoryTable.Get(x => x.TableId == tableId);
            Section section = _genericRepositorySection.Get(x => x.SectionId == table.SectionId);

            var ticket = _genericRepositoryTicket.Get(x => x.TableId == table.TableId && x.IsOpened == true);
            NavigationManager.OpenForm(new POSForm(1, ticket == null ? null : ticket, section, table), DockStyle.Fill, GlobalVariables.ShellForm.panelMain);
            GlobalVariables.ShellForm.buttonMainMenu.Enabled = false;
        }

        private void tileItemSection_Click(object sender, TileItemEventArgs e)
        {
            TileItem sectionItem = (TileItem)sender;
            CreateTables(Convert.ToInt32(sectionItem.Tag));
        }
    }
}
