using Database.Data;
using Database.Models;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WindowsFormsAppUI.Helpers;

namespace WindowsFormsAppUI.Forms
{
    public partial class TablesForm : Form
    {
        private readonly IGenericRepository<Section> _genericRepositorySection = new GenericRepository<Section>(GlobalVariables.SQLContext);
        private readonly IGenericRepository<Table> _genericRepositoryTable = new GenericRepository<Table>(GlobalVariables.SQLContext);

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

                tileItemTable.Text = table.Name;
                tileItemTable.ItemClick += tileItemSection_Click;

                tileGroupTables.Items.Add(tileItemTable);
            }
        }

        private void tileItemSection_Click(object sender, TileItemEventArgs e)
        {
            TileItem section = (TileItem)sender;
            CreateTables(Convert.ToInt32(section.Tag));
        }
    }
}
