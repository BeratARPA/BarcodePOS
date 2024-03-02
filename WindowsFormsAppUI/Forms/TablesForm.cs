using Database.Data;
using Database.Models;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsAppUI.Enums;
using WindowsFormsAppUI.Helpers;

namespace WindowsFormsAppUI.Forms
{
    public partial class TablesForm : Form
    {
        private readonly IGenericRepository<Section> _genericRepositorySection = new GenericRepository<Section>(GlobalVariables.SQLContext);
        private readonly IGenericRepository<Table> _genericRepositoryTable = new GenericRepository<Table>(GlobalVariables.SQLContext);
        private readonly IGenericRepository<Ticket> _genericRepositoryTicket = new GenericRepository<Ticket>(GlobalVariables.SQLContext);
        private readonly IGenericRepository<Order> _genericRepositoryOrder = new GenericRepository<Order>(GlobalVariables.SQLContext);
        private readonly IGenericRepository<Payment> _genericRepositoryPayment = new GenericRepository<Payment>(GlobalVariables.SQLContext);

        private List<Section> _sections = new List<Section>();
        private List<Table> _tables = new List<Table>();

        private Ticket _ticket;

        public TablesForm(Ticket ticket = null)
        {
            InitializeComponent();

            _ticket = ticket;
        }

        private void TablesForm_Load(object sender, EventArgs e)
        {
            _sections = _genericRepositorySection.GetAll();
            _tables = _genericRepositoryTable.GetAll();

            CreateSections();
            CreateTables(1);
        }

        public void CreateSections()
        {
            tileGroupSections.Items.Clear();

            foreach (var section in _sections)
            {
                TileItem tileItemSection = new TileItem();

                tileItemSection.AppearanceItem.Normal.BackColor = Color.FromArgb(157, 156, 161);
                tileItemSection.AppearanceItem.Normal.BorderColor = Color.FromArgb(255, 202, 10);
                tileItemSection.AppearanceItem.Hovered.BackColor = Color.FromArgb(255, 202, 10);
                tileItemSection.AppearanceItem.Normal.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                tileItemSection.TextAlignment = TileItemContentAlignment.MiddleCenter;

                tileItemSection.Tag = section.SectionId;
                tileItemSection.Text = section.Title;
                tileItemSection.ItemClick += tileItemSection_Click;

                var openTablesInSection = _tables
                    .Where(table => table.SectionId == section.SectionId)
                    .Select(table => new
                    {
                        Table = table,
                        Ticket = _genericRepositoryTicket.Get(x => x.TableId == table.TableId && x.IsOpened == true)
                    })
                    .Where(x => x.Ticket != null)
                    .Count();
                if (openTablesInSection != 0)
                {
                    TileItemElement middleElement = new TileItemElement();

                    middleElement.Text = openTablesInSection.ToString();
                    middleElement.TextAlignment = TileItemContentAlignment.TopLeft;
                    tileItemSection.Elements.Add(middleElement);
                }

                tileGroupSections.Items.Add(tileItemSection);
            }
        }

        public void CreateTables(int sectionId)
        {
            if (sectionId != 0)
            {
                tileGroupTables.Items.Clear();

                foreach (var table in _tables.FindAll(x => x.SectionId == sectionId))
                {
                    TileItem tileItemTable = new TileItem();

                    tileItemTable.AppearanceItem.Normal.BackColor = Color.FromArgb(157, 156, 161);
                    tileItemTable.AppearanceItem.Normal.BorderColor = Color.FromArgb(255, 202, 10);
                    tileItemTable.AppearanceItem.Hovered.BackColor = Color.FromArgb(255, 202, 10);
                    tileItemTable.AppearanceItem.Normal.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                    tileItemTable.TextAlignment = TileItemContentAlignment.MiddleCenter;

                    tileItemTable.Tag = table.TableId;
                    tileItemTable.Text = TableName.GetName(table.TableId);
                    tileItemTable.ItemClick += tileItemTable_Click;

                    var ticket = _genericRepositoryTicket.Get(x => x.TableId == table.TableId && x.IsOpened == true);
                    if (ticket != null)
                    {
                        //TableColor
                        tileItemTable.AppearanceItem.Normal.BackColor = Color.Orange;

                        //TotalAmount
                        TileItemElement middleElement = new TileItemElement();

                        middleElement.Text = string.Format("{0:C}", ticket.TotalAmount);
                        middleElement.TextAlignment = TileItemContentAlignment.BottomRight;
                        tileItemTable.Elements.Add(middleElement);
                    }

                    tileGroupTables.Items.Add(tileItemTable);
                }
            }
        }

        private async void tileItemTable_Click(object sender, TileItemEventArgs e)
        {
            TileItem tableItem = (TileItem)sender;

            int tableId = Convert.ToInt32(tableItem.Tag);
            var table = _genericRepositoryTable.Get(x => x.TableId == tableId);
            var section = _genericRepositorySection.Get(x => x.SectionId == table.SectionId);
            var ticket = _genericRepositoryTicket.Get(x => x.TableId == table.TableId && x.IsOpened == true);

            #region ChangeTable
            if (_ticket != null && _ticket.TableId != tableId)
            {
                #region MargeTable
                var openTicket = _genericRepositoryTicket.Get(x => x.TableId == tableId && x.IsOpened == true);
                if (openTicket != null)
                {

                    Ticket newTicket = new Ticket
                    {
                        TicketGuid = Guid.NewGuid(),
                        TableId = tableId,
                        LastUpdateDate = DateTime.Now,
                        TicketNumber = TicketNumberHelper.GetNumber().ToString(),
                        Date = DateTime.Now,
                        LastOrderDate = DateTime.Now,
                        LastPaymentDate = DateTime.Now,
                        IsOpened = true,
                        RemainingAmount = _ticket.TotalAmount + openTicket.TotalAmount,
                        TotalAmount = _ticket.TotalAmount + openTicket.TotalAmount,
                        Discount = 0,
                        TerminalName = GlobalVariables.TerminalName,
                        Note = "",
                        LastModifiedUserName = LoggedInUser.CurrentUser.Fullname,
                        CreatedUserName = LoggedInUser.CurrentUser.Fullname,
                    };

                    _genericRepositoryTicket.Add(newTicket);
                    newTicket = _genericRepositoryTicket.Get(x => x.TicketGuid == newTicket.TicketGuid);

                    List<Order> newOrders = _ticket.Orders
                        .Concat(openTicket.Orders)
                        .GroupBy(order => order.ProductId)
                        .Select(groupedOrders => new Order
                        {
                            TicketId = newTicket.TicketId,
                            ProductId = groupedOrders.Key,
                            ProductName = groupedOrders.First().ProductName,
                            Price = groupedOrders.First().Price,
                            Quantity = groupedOrders.Sum(order => order.Quantity),
                            TerminalName = GlobalVariables.TerminalName,
                            CreatingUserName = LoggedInUser.CurrentUser.Fullname,
                            CreatedDateTime = DateTime.Now,
                            LastUpdateDateTime = DateTime.Now,
                        })
                        .ToList();

                    _genericRepositoryOrder.AddAll(newOrders);

                    _genericRepositoryOrder.DeleteAll(_ticket.Orders.ToList());
                    _genericRepositoryOrder.DeleteAll(openTicket.Orders.ToList());
                    if (_ticket.Payments != null && openTicket.Payments != null)
                    {
                        _genericRepositoryPayment.DeleteAll(_ticket.Payments.ToList());
                        _genericRepositoryPayment.DeleteAll(openTicket.Payments.ToList());
                    }
                    _genericRepositoryTicket.Delete(_ticket);
                    _genericRepositoryTicket.Delete(openTicket);
                }
                #endregion

                _genericRepositoryTicket.UpdateColumn(_ticket, x => x.TableId, tableId);
                GlobalVariables.ShellForm.buttonMainMenu.Enabled = true;

                CreateSections();
                CreateTables(section.SectionId);
                _ticket = null;

                await GlobalVariables.webSocketClient.Send(ClientCommandsEnum.REFRESH.ToString());
                return;
            }
            #endregion

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
