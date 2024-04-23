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
            UpdateUILanguage();

            _ticket = ticket;
        }

        private void TablesForm_Load(object sender, EventArgs e)
        {
            _sections = _genericRepositorySection.GetAllAsNoTracking();
            _tables = _genericRepositoryTable.GetAllAsNoTracking();

            CreateSections();
            CreateTables(1);
        }

        public void UpdateUILanguage()
        {
            buttonOpenTables.Text = GlobalVariables.CultureHelper.GetText("OpenTables");
            buttonCloseTables.Text = GlobalVariables.CultureHelper.GetText("ClosedTables");
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
                        Ticket = _genericRepositoryTicket.GetAsNoTracking(x => x.TableId == table.TableId && x.IsOpened == true)
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

        public void CreateTables(int sectionId, bool isOpen = false)
        {
            if (sectionId == 0)
                return;

            tileGroupTables.Items.Clear();
            List<Table> tables;

            if (sectionId == -1)
                tables = _tables;
            else
                tables = _tables.FindAll(x => x.SectionId == sectionId);

            TileItem tileItemTable = null;
            foreach (var table in tables)
            {
                if (sectionId == -1 && isOpen)
                    tileItemTable = CreateTileItemForOpenTable(table);
                else if (sectionId == -1 && !isOpen)
                    tileItemTable = CreateTileItemForCloseTable(table);
                else
                    tileItemTable = CreateTileItemForTable(table);

                if (tileItemTable != null)
                    tileGroupTables.Items.Add(tileItemTable);
            }
        }

        private TileItem CreateTileItemForTable(Table table)
        {
            TileItem tileItemTable = new TileItem();

            // Set table properties
            SetTableAppearance(tileItemTable);

            tileItemTable.Tag = table.TableId;
            tileItemTable.Text = TableName.GetName(table.TableId);
            tileItemTable.ItemClick += tileItemTable_Click;

            var ticket = _genericRepositoryTicket.GetAsNoTracking(x => x.TableId == table.TableId && x.IsOpened == true);
            if (ticket != null)
            {
                // Printed Table appearance settings
                SetPrintedTableAppearance(tileItemTable, ticket);

                // Add customer information if available
                if (ticket.CustomerId != 0)
                {
                    AddCustomerElement(tileItemTable, ticket.CustomerId);
                }

                // Add total amount element
                AddTotalAmountElement(tileItemTable, ticket.TotalAmount);

                // Add date-time element
                AddDateTimeElement(tileItemTable, ticket.Date);
            }

            return tileItemTable;
        }

        private TileItem CreateTileItemForOpenTable(Table table)
        {
            var ticket = _genericRepositoryTicket.GetAsNoTracking(x => x.TableId == table.TableId && x.IsOpened == true);
            if (ticket != null)
            {
                TileItem tileItemTable = new TileItem();

                // Set table properties
                SetTableAppearance(tileItemTable);

                tileItemTable.Tag = table.TableId;
                tileItemTable.Text = TableName.GetName(table.TableId);
                tileItemTable.ItemClick += tileItemTable_Click;

                // Printed Table appearance settings
                SetPrintedTableAppearance(tileItemTable, ticket);

                // Add customer information if available
                if (ticket.CustomerId != 0)
                {
                    AddCustomerElement(tileItemTable, ticket.CustomerId);
                }

                // Add total amount element
                AddTotalAmountElement(tileItemTable, ticket.TotalAmount);

                // Add date-time element
                AddDateTimeElement(tileItemTable, ticket.Date);

                return tileItemTable;
            }

            return null;
        }

        private TileItem CreateTileItemForCloseTable(Table table)
        {
            var ticket = _genericRepositoryTicket.GetAsNoTracking(x => x.TableId == table.TableId && x.IsOpened == true);
            if (ticket != null)
            {
                return null;
            }

            TileItem tileItemTable = new TileItem();

            // Set table properties
            SetTableAppearance(tileItemTable);

            tileItemTable.Tag = table.TableId;
            tileItemTable.Text = TableName.GetName(table.TableId);
            tileItemTable.ItemClick += tileItemTable_Click;

            return tileItemTable;
        }

        private void SetTableAppearance(TileItem tileItemTable)
        {
            tileItemTable.AppearanceItem.Normal.BackColor = Color.FromArgb(157, 156, 161);
            tileItemTable.AppearanceItem.Normal.BorderColor = Color.FromArgb(255, 202, 10);
            tileItemTable.AppearanceItem.Hovered.BackColor = Color.FromArgb(255, 202, 10);
            tileItemTable.AppearanceItem.Normal.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            tileItemTable.TextAlignment = TileItemContentAlignment.MiddleCenter;
        }

        private void SetPrintedTableAppearance(TileItem tileItemTable, Ticket ticket)
        {
            tileItemTable.AppearanceItem.Normal.BackColor = ticket.IsPrinted ? Color.IndianRed : Color.Orange;
        }

        private void AddCustomerElement(TileItem tileItemTable, int customerId)
        {
            TileItemElement customerElement = new TileItemElement();
            customerElement.Text = CustomerHelper.GetName(customerId);
            customerElement.TextAlignment = TileItemContentAlignment.TopLeft;
            tileItemTable.Elements.Add(customerElement);
        }

        private void AddTotalAmountElement(TileItem tileItemTable, double totalAmount)
        {
            TileItemElement totalAmountElement = new TileItemElement();
            totalAmountElement.Text = string.Format("{0:C}", totalAmount);
            totalAmountElement.TextAlignment = TileItemContentAlignment.BottomRight;
            tileItemTable.Elements.Add(totalAmountElement);
        }

        private void AddDateTimeElement(TileItem tileItemTable, DateTime date)
        {
            TimeSpan difference = date - DateTime.Now;
            difference = TimeSpan.FromTicks(Math.Abs(difference.Ticks));
            string timeDifference = $"{date.ToString("HH:mm")}\n{difference.Days:00}:{difference.Hours:00}:{difference.Minutes:00}:{difference.Seconds:00}";

            TileItemElement dateTimeElement = new TileItemElement();
            dateTimeElement.Text = timeDifference;
            dateTimeElement.TextAlignment = TileItemContentAlignment.BottomLeft;
            tileItemTable.Elements.Add(dateTimeElement);
        }

        private async void tileItemTable_Click(object sender, TileItemEventArgs e)
        {
            TileItem tableItem = (TileItem)sender;

            int tableId = Convert.ToInt32(tableItem.Tag);
            var table = _genericRepositoryTable.GetAsNoTracking(x => x.TableId == tableId);
            var section = _genericRepositorySection.GetAsNoTracking(x => x.SectionId == table.SectionId);
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
                        UserId = LoggedInUser.CurrentUser.UserId
                    };

                    newTicket = _genericRepositoryTicket.Add(newTicket);

                    List<Order> newOrders = _ticket.Orders
                        .Concat(openTicket.Orders)
                        .GroupBy(order => order.ProductId)
                        .Select(groupedOrders => new Order
                        {
                            TicketId = newTicket.TicketId,
                            ProductId = groupedOrders.Key,
                            UserId = LoggedInUser.CurrentUser.UserId,
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

        private void buttonOpenTables_Click(object sender, EventArgs e)
        {
            CreateTables(-1, true);
        }

        private void buttonCloseTables_Click(object sender, EventArgs e)
        {
            CreateTables(-1, false);
        }
    }
}
