using Database.Data;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsAppUI.Enums;
using WindowsFormsAppUI.Helpers;
using WindowsFormsAppUI.UserControls;

namespace WindowsFormsAppUI.Forms
{
    public partial class POSForm : Form
    {
        private readonly IGenericRepository<Order> _genericRepositoryOrder = new GenericRepository<Order>(GlobalVariables.SQLContext);
        private readonly IGenericRepository<Table> _genericRepositoryTable = new GenericRepository<Table>(GlobalVariables.SQLContext);
        private readonly IGenericRepository<Ticket> _genericRepositoryTicket = new GenericRepository<Ticket>(GlobalVariables.SQLContext);
        private readonly IGenericRepository<Payment> _genericRepositoryPayment = new GenericRepository<Payment>(GlobalVariables.SQLContext);
        private readonly IGenericRepository<Product> _genericRepositoryProduct = new GenericRepository<Product>(GlobalVariables.SQLContext);
        private readonly IGenericRepository<Section> _genericRepositorySection = new GenericRepository<Section>(GlobalVariables.SQLContext);
        private readonly IGenericRepository<Customer> _genericRepositoryCustomer = new GenericRepository<Customer>(GlobalVariables.SQLContext);
        private readonly IGenericRepository<Category> _genericRepositoryCategory = new GenericRepository<Category>(GlobalVariables.SQLContext);
        private readonly IGenericRepository<PaymentType> _genericRepositoryPaymentType = new GenericRepository<PaymentType>(GlobalVariables.SQLContext);

        private Table _table = new Table();
        private Ticket _ticket = new Ticket();
        private Section _section = new Section();
        private Customer _customer = new Customer();
        private List<Order> _orders = new List<Order>();
        private List<Product> _products = new List<Product>();
        private List<Category> _category = new List<Category>();
        private List<Order> _productsSentToKitchen = new List<Order>();
        private List<PaymentType> _paymentTypes = new List<PaymentType>();
        private ReceiptTemplates receiptTemplates = new ReceiptTemplates();

        private readonly FileOperations<string> fileOperations = new FileOperations<string>(FolderLocations.barcodePOSFolderPath + "QuickMenu.txt");

        private int _previousFormIndex;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000; //WS_EX_COMPOSITED
                return handleParam;
            }
        }

        public POSForm(int previousFormIndex = 0, Ticket ticket = null, Section section = null, Table table = null, Customer customer = null)
        {
            InitializeComponent();
            UpdateUILanguage();

            numeratorUserControl.textBoxPin.KeyPress += new KeyPressEventHandler(NumeratorTextBoxPin_KeyPress);

            _table = table;
            _ticket = ticket;
            _section = section;
            _customer = customer;
            _previousFormIndex = previousFormIndex;
        }

        private void POSForm_Load(object sender, EventArgs e)
        {
            CreateTicket();

            IsTable();
            CustomerAvailable();
            NoteAvailable();

            CloseAndOpenTicket();

            _products = _genericRepositoryProduct.GetAll();
            _category = _genericRepositoryCategory.GetAll();
            _paymentTypes = _genericRepositoryPaymentType.GetAll();
            CreateProducts(_products);
            CreateCategories(_category);
            CreatePayments(_paymentTypes);
            CalculateTotalBalance();
        }

        public void UpdateUILanguage()
        {
            buttonProductsWitoutBarcode.Text = GlobalVariables.CultureHelper.GetText("ProductsWithoutBarcode");
            buttonProductsWithBarcode.Text = GlobalVariables.CultureHelper.GetText("BarcodeProducts");
            buttonQuickMenu.Text = GlobalVariables.CultureHelper.GetText("QuickMenu");
            buttonMultiplePayment.Text = GlobalVariables.CultureHelper.GetText("MultiplePayments");
            buttonNewTicket.Text = GlobalVariables.CultureHelper.GetText("NewTicket");
            buttonClose.Text = GlobalVariables.CultureHelper.GetText("Close");
            buttonTickets.Text = GlobalVariables.CultureHelper.GetText("Tickets");
            buttonPrint.Text = GlobalVariables.CultureHelper.GetText("Print");
            buttonDiscount.Text = GlobalVariables.CultureHelper.GetText("PercentDiscount");
            buttonTicketDelete.Text = GlobalVariables.CultureHelper.GetText("TicketCancellation");
            buttonOpenTheDrawer.Text = GlobalVariables.CultureHelper.GetText("OpenDrawer");
            buttonChangeTable.Text = GlobalVariables.CultureHelper.GetText("ChangeTable");
            buttonSendToKitchen.Text = GlobalVariables.CultureHelper.GetText("SendToKitchen");
            buttonSearch.Text = GlobalVariables.CultureHelper.GetText("Search");
            buttonSelectCustomer.Text = GlobalVariables.CultureHelper.GetText("SelectCustomer");
            label4.Text = GlobalVariables.CultureHelper.GetText("TicketTotal");
            label1.Text = GlobalVariables.CultureHelper.GetText("Balance");
            buttonNote.Text = GlobalVariables.CultureHelper.GetText("AddNote");
        }

        public void CloseAndOpenTicket()
        {
            bool isOpened = _ticket.IsOpened;
            tableLayoutPanelProducts.Enabled = isOpened;
            tableLayoutPanelPaymentTypes.Enabled = isOpened;
            tableLayoutPanelSearch.Enabled = isOpened;
            numeratorUserControl.Enabled = isOpened;
            tableLayoutPanelCategories.Enabled = isOpened;
            flowLayoutPanelOrders.Enabled = isOpened;
            buttonDiscount.Enabled = isOpened;
            buttonMultiplePayment.Enabled = isOpened;
            buttonSendToKitchen.Enabled = isOpened;
            buttonChangeTable.Enabled = isOpened;
            buttonSelectCustomer.Enabled = isOpened;
            buttonNote.Enabled = isOpened;
            buttonClose.Enabled = true;
        }

        public void CreateTicket()
        {
            if (_ticket != null)
            {
                _ticket.Orders = _genericRepositoryOrder.GetAll(x => x.TicketId == _ticket.TicketId);
                _ticket.Payments = _genericRepositoryPayment.GetAll(x => x.TicketId == _ticket.TicketId);
                foreach (Order order in _ticket.Orders)
                {
                    var product = _genericRepositoryProduct.Get(x => x.ProductId == order.ProductId);
                    ProductUserControl productUserControl = new ProductUserControl(product, product.Index);

                    ProductOnCardUserControl newProductOnCard = CreateNewProductOnCard(productUserControl, order);
                    flowLayoutPanelOrders.Controls.Add(newProductOnCard);

                    _orders.Add(order);
                }

                CalculateTotalBalance();

                return;
            }

            Ticket ticket = new Ticket
            {
                TicketGuid = Guid.NewGuid(),
                LastUpdateDate = DateTime.Now,
                TicketNumber = TicketNumberHelper.GetNumber().ToString(),
                Date = DateTime.Now,
                LastOrderDate = DateTime.Now,
                LastPaymentDate = DateTime.Now,
                IsOpened = true,
                RemainingAmount = 0,
                TotalAmount = 0,
                Discount = 0,
                TerminalName = GlobalVariables.TerminalName,
                Note = "",
                LastModifiedUserName = LoggedInUser.CurrentUser.Fullname,
                CreatedUserName = LoggedInUser.CurrentUser.Fullname,
            };

            _ticket = ticket;
        }

        public void CustomerAvailable()
        {
            if (_ticket.CustomerId != 0)
            {
                _customer = _genericRepositoryCustomer.Get(x => x.CustomerId == _ticket.CustomerId);
            }

            if (_customer != null)
            {
                _ticket.CustomerId = _customer.CustomerId;
                labelCustomer.Text = string.Format(GlobalVariables.CultureHelper.GetText("POSCustomer"), CustomerHelper.GetName(_customer.CustomerId));
                tableLayoutPanelMiddle.RowStyles[1].Height = 50;
                buttonNewTicket.Enabled = false;
            }
            else
            {
                _ticket.CustomerId = 0;
                tableLayoutPanelMiddle.RowStyles[1].Height = 0;
            }
        }

        public void NoteAvailable()
        {
            if (!string.IsNullOrEmpty(_ticket.Note))
            {
                labelNote.Text = string.Format(GlobalVariables.CultureHelper.GetText("POSNote"), _ticket.Note);
                tableLayoutPanelMiddle.RowStyles[2].Height = 50;
            }
            else
            {
                _ticket.Note = "";
                tableLayoutPanelMiddle.RowStyles[2].Height = 0;
            }
        }

        public void IsTable()
        {
            if (_ticket.TableId != 0)
            {
                _table = _genericRepositoryTable.Get(x => x.TableId == _ticket.TableId);
                _section = _genericRepositorySection.Get(x => x.SectionId == _table.SectionId);
            }

            if (_section != null)
            {
                _ticket.TableId = _table.TableId;
                labelTable.Text = string.Format(GlobalVariables.CultureHelper.GetText("POSTable"), TableName.GetName(_table.TableId));
                tableLayoutPanelMiddle.RowStyles[0].Height = 50;
                buttonNewTicket.Enabled = false;
            }
            else
            {
                _ticket.TableId = 0;
                tableLayoutPanelMiddle.RowStyles[0].Height = 0;
            }
        }

        public void CreateCategories(List<Category> categories)
        {
            tableLayoutPanelDynamicCategories.Controls.Clear();

            int rowCount = 1;
            foreach (Category category in categories)
            {
                CategoryUserControl categoryUserControl = new CategoryUserControl(category)
                {
                    Dock = DockStyle.Fill
                };

                tableLayoutPanelDynamicCategories.RowStyles.Add(new ColumnStyle(SizeType.Percent, 100));
                tableLayoutPanelDynamicCategories.RowCount = rowCount;
                tableLayoutPanelDynamicCategories.ColumnCount = 1;

                categoryUserControl.CategoryTypeClick += CategoryUserControl_Click;

                tableLayoutPanelDynamicCategories.Controls.Add(categoryUserControl);

                rowCount++;
            }
        }

        public Order CreateOrder(Product product, double quantity)
        {
            Order order = new Order
            {
                TicketId = _ticket.TicketId,
                ProductId = product.ProductId,
                ProductName = product.Name,
                Price = product.Price,
                Quantity = quantity,
                CalculatePrice = true,
                TerminalName = GlobalVariables.TerminalName,
                CreatingUserName = LoggedInUser.CurrentUser.Fullname,
                CreatedDateTime = DateTime.Now,
                LastUpdateDateTime = DateTime.Now
            };

            _orders.Add(order);
            AddProductSentToKitchen(order.ProductId, quantity);

            return order;
        }

        public void CreatePayments(List<PaymentType> paymentTypes)
        {
            tableLayoutPanelPaymentTypes.Controls.Clear();

            int columnCount = 1;
            foreach (PaymentType paymentType in paymentTypes)
            {
                PaymentTypeUserControl paymentTypeUserControl = new PaymentTypeUserControl(paymentType)
                {
                    Dock = DockStyle.Fill
                };

                tableLayoutPanelPaymentTypes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
                tableLayoutPanelPaymentTypes.ColumnCount = columnCount;
                tableLayoutPanelPaymentTypes.RowCount = 1;

                paymentTypeUserControl.PaymentTypeClick += PaymentTypeUserControl_Click;

                tableLayoutPanelPaymentTypes.Controls.Add(paymentTypeUserControl);

                columnCount++;
            }
        }

        public void CreateProducts(List<Product> products)
        {
            tableLayoutPanelProducts.SuspendLayout();

            int columnCount = 0, rowCount = 0, productIndex = 0, productCount = products.Count;

            int c = 1;
            for (int i = 1; i <= productCount; i++)
            {
                for (int j = productCount; j >= i; j--)
                {
                    c = i * j;
                    if (c == productCount)
                    {
                        rowCount = i;
                        columnCount = j;
                        break;
                    }
                    break;
                }
                break;
            }

            tableLayoutPanelProducts.Controls.Clear();
            tableLayoutPanelProducts.ColumnStyles.Clear();
            tableLayoutPanelProducts.RowStyles.Clear();
            tableLayoutPanelProducts.RowCount = 0;
            tableLayoutPanelProducts.ColumnCount = 0;
            for (int column = 1; column <= 5; column++)
            {
                tableLayoutPanelProducts.ColumnCount = column;
                tableLayoutPanelProducts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

                for (int row = 1; row <= rowCount; row++)
                {
                    tableLayoutPanelProducts.RowCount = row;
                    tableLayoutPanelProducts.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
                }
            }
            tableLayoutPanelProducts.RowCount++;
            tableLayoutPanelProducts.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            tableLayoutPanelProducts.RowCount++;
            tableLayoutPanelProducts.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            tableLayoutPanelProducts.RowCount++;
            tableLayoutPanelProducts.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            for (int i = 0; i < columnCount * rowCount; i++)
            {
                if (productIndex < products.Count)
                {
                    ProductUserControl productUserControl = new ProductUserControl(products[productIndex], productIndex)
                    {
                        Dock = DockStyle.Fill
                    };

                    productUserControl.ProductClick += ProductUserControl_Click;

                    tableLayoutPanelProducts.Controls.Add(productUserControl);

                    productIndex++;
                }
            }

            tableLayoutPanelProducts.ResumeLayout();
        }

        private void AddOrUpdateProductToOrder(ProductUserControl productUserControl)
        {
            ProductOnCardUserControl existingProductOnCard = FindProductOnCard(productUserControl._product.ProductId);

            if (existingProductOnCard != null)
            {
                UpdateProductOnCard(existingProductOnCard, CheckToNumerator());
            }
            else
            {
                ProductOnCardUserControl newProductOnCard = CreateNewProductOnCard(productUserControl);
                flowLayoutPanelOrders.Controls.Add(newProductOnCard);
            }

            CalculateTotalBalance();
        }

        private ProductOnCardUserControl FindProductOnCard(int productId)
        {
            return flowLayoutPanelOrders.Controls.OfType<ProductOnCardUserControl>().FirstOrDefault(p => p._product.ProductId == productId);
        }

        private void UpdateProductOnCard(ProductOnCardUserControl productOnCardUserControl, double quantity)
        {
            double totalQuantity = productOnCardUserControl.Quantity + quantity;
            double totalPrice = (double)(totalQuantity * productOnCardUserControl._product.Price);

            productOnCardUserControl.Quantity = totalQuantity;
            productOnCardUserControl.Price = totalPrice;

            var order = _orders.Find(x => x.ProductId == productOnCardUserControl._order.ProductId);
            order.Quantity = totalQuantity;
            order.Price = productOnCardUserControl._product.Price;
            order.LastUpdateDateTime = DateTime.Now;

            AddProductSentToKitchen(order.ProductId, quantity);

            _ticket.LastOrderDate = DateTime.Now;
        }

        public void AddProductSentToKitchen(int productId, double quantity)
        {
            var existingOrder = _productsSentToKitchen.Find(x => x.ProductId == productId);
            if (existingOrder != null)
            {
                existingOrder.Quantity += quantity;
            }
            else
            {
                var product = _genericRepositoryProduct.GetById(productId);
                Order order = new Order
                {
                    TicketId = _ticket.TicketId,
                    ProductId = product.ProductId,
                    ProductName = product.Name,
                    Price = product.Price,
                    Quantity = quantity,
                    TerminalName = GlobalVariables.TerminalName,
                    CreatingUserName = LoggedInUser.CurrentUser.Fullname,
                    CreatedDateTime = DateTime.Now,
                    LastUpdateDateTime = DateTime.Now
                };

                _productsSentToKitchen.Add(order);
            }
        }

        public void DeleteProductSentToKitchen(int productId, double quantity)
        {
            var existingOrder = _productsSentToKitchen.Find(x => x.ProductId == productId);
            if (existingOrder != null)
            {
                if (existingOrder.Quantity == 1)
                {
                    _productsSentToKitchen.Remove(existingOrder);
                }
                else if (existingOrder.Quantity > 1)
                {
                    existingOrder.Quantity -= quantity;
                }
            }
        }

        public double CheckToNumerator()
        {
            try
            {
                if (string.IsNullOrEmpty(numeratorUserControl.NumeratorDisplay) || Convert.ToDouble(numeratorUserControl.NumeratorDisplay) == 0)
                {
                    return 1;
                }

                return Convert.ToDouble(numeratorUserControl.NumeratorDisplay);
            }
            catch
            {
                return 1;
            }
        }

        public double CheckToNumeratorDiscount()
        {
            try
            {
                if (string.IsNullOrEmpty(numeratorUserControl.NumeratorDisplay))
                {
                    return 0;
                }

                return Convert.ToDouble(numeratorUserControl.NumeratorDisplay);
            }
            catch
            {
                return 0;
            }
        }

        private ProductOnCardUserControl CreateNewProductOnCard(ProductUserControl productUserControl, Order loadOrder = null)
        {
            Order order;

            if (loadOrder != null)
            {
                order = loadOrder;
            }
            else
            {
                order = CreateOrder(productUserControl._product, CheckToNumerator());
            }

            ProductOnCardUserControl newProductOnCard = new ProductOnCardUserControl(order, productUserControl._product);
            newProductOnCard.Delete += ProductOnCardUserControl_Delete;

            return newProductOnCard;
        }

        public double CalculateTotalBalance()
        {
            double totalBalance = 0;

            foreach (Order order in _orders)
            {
                totalBalance += order.Price * order.Quantity;
            }

            labelTicketTotal.Text = string.Format("{0:C}", totalBalance);

            //Discount
            if (_ticket.Discount != 0)
            {
                tableLayoutPanelLabels.RowStyles[1].Height = 33;
                tableLayoutPanelLabels.RowStyles[2].Height = 33;
                totalBalance = DiscountHelper.Calculate(totalBalance, _ticket.Discount);

                labelDiscountPercent.Text = string.Format(GlobalVariables.CultureHelper.GetText("Discount"), _ticket.Discount);
                labelDiscount.Text = string.Format("({0:C})", DiscountHelper.discountAmount);
            }
            else
            {
                tableLayoutPanelLabels.RowStyles[1].Height = 0;
                tableLayoutPanelLabels.RowStyles[2].Height = 0;
            }

            labelBalance.Text = string.Format("{0:C}", totalBalance);

            //Return
            if (totalBalance == 0)
            {
                tableLayoutPanelMiddle.RowStyles[5].Height = 0;
                return 0;
            }

            _ticket.TotalAmount = totalBalance;

            //Payments
            if (_ticket.Payments != null)
            {
                foreach (Payment payment in _ticket.Payments)
                {
                    totalBalance -= payment.TenderedAmount;
                }
            }

            _ticket.RemainingAmount = totalBalance;

            tableLayoutPanelMiddle.RowStyles[5].Height = 100;

            return totalBalance;
        }

        public void SaveTicket(bool sendToKitchen)
        {
            Ticket ticket = _genericRepositoryTicket.Get(x => x.TicketGuid == _ticket.TicketGuid);

            if (_orders.Count == 0 && ticket != null)
            {
                DeleteTicket();
            }

            if (_orders.Count != 0)
            {
                if (ticket != null)
                {
                    _genericRepositoryTicket.Update(ticket);
                }
                else
                {
                    _genericRepositoryTicket.Add(_ticket);
                    ticket = _genericRepositoryTicket.Get(x => x.TicketGuid == _ticket.TicketGuid);
                }

                foreach (Order order in _orders)
                {
                    var existingOrder = _genericRepositoryOrder.Get(x => x.TicketId == ticket.TicketId && x.ProductId == order.ProductId);
                    if (existingOrder != null)
                    {
                        existingOrder.LastUpdateDateTime = order.LastUpdateDateTime;
                        existingOrder.Quantity = order.Quantity;

                        _genericRepositoryOrder.Update(existingOrder);
                    }
                    else
                    {
                        order.TicketId = ticket.TicketId;
                        _genericRepositoryOrder.Add(order);
                    }
                }

                if (_productsSentToKitchen.Count > 0 && sendToKitchen)
                {
                    receiptTemplates.KitchenReceipt(_productsSentToKitchen, _ticket);
                }

                var ordersInDatabase = _genericRepositoryOrder.GetAll(x => x.TicketId == ticket.TicketId);
                var ordersToRemove = ordersInDatabase.Where(dbOrder => !_orders.Any(order => order.ProductId == dbOrder.ProductId)).ToList();
                _genericRepositoryOrder.DeleteAll(ordersToRemove);
            }
        }

        public void ClearTicket()
        {
            _ticket = null;
            _orders.Clear();
            _productsSentToKitchen.Clear();
            flowLayoutPanelOrders.Controls.Clear();

            CreateTicket();
            IsTable();
            CalculateTotalBalance();
            CloseAndOpenTicket();
            IsTable();
            CustomerAvailable();
        }

        private void CategoryUserControl_Click(object sender, EventArgs e)
        {
            CategoryUserControl categoryUserControl = (CategoryUserControl)sender;
            var products = _products.Where(x => x.CategoryId == categoryUserControl._category.CategoryId).ToList();
            CreateProducts(products);
        }

        private void ProductOnCardUserControl_Delete(object sender, EventArgs e)
        {
            ProductOnCardUserControl productOnCardUserControl = (ProductOnCardUserControl)sender;

            int index = flowLayoutPanelOrders.Controls.GetChildIndex(productOnCardUserControl);

            if (index >= 0)
            {
                var order = _orders.Find(x => x.ProductId == productOnCardUserControl._order.ProductId);

                DeleteProductSentToKitchen(order.ProductId, CheckToNumerator());

                if (productOnCardUserControl.Quantity == 1 || CheckToNumerator() > productOnCardUserControl.Quantity)
                {
                    flowLayoutPanelOrders.Controls.RemoveAt(index);
                    _orders.Remove(order);
                }
                else if (productOnCardUserControl.Quantity > 1)
                {
                    double totalQuantity = productOnCardUserControl.Quantity - CheckToNumerator();
                    double totalPrice = (double)(totalQuantity * productOnCardUserControl._product.Price);

                    productOnCardUserControl.Quantity = totalQuantity;
                    productOnCardUserControl.Price = totalPrice;

                    order.Quantity = totalQuantity;
                    order.Price = productOnCardUserControl._product.Price;
                }

                if (productOnCardUserControl.Quantity == 0)
                {
                    flowLayoutPanelOrders.Controls.RemoveAt(index);
                    _orders.Remove(order);
                }

                CalculateTotalBalance();

                numeratorUserControl.Clear();
            }
        }

        private async void PaymentTypeUserControl_Click(object sender, EventArgs e)
        {
            if (_orders.Count != 0)
            {
                PaymentTypeUserControl paymentTypeUserControl = (PaymentTypeUserControl)sender;

                if (GlobalVariables.MessageBoxForm.ShowMessage(string.Format(GlobalVariables.CultureHelper.GetText("PaymentWillBeMadeInDoYouConfirm?"), paymentTypeUserControl._paymentType.Name), GlobalVariables.CultureHelper.GetText("Information"), MessageButton.YesNo, MessageIcon.Information) != DialogResult.Yes)
                {
                    return;
                }

                Ticket ticket = _genericRepositoryTicket.Get(x => x.TicketGuid == _ticket.TicketGuid);
                if (ticket == null)
                {
                    SaveTicket(true);
                    ticket = _genericRepositoryTicket.Get(x => x.TicketGuid == _ticket.TicketGuid);
                }

                Payment payment = new Payment
                {
                    TicketId = ticket.TicketId,
                    PaymentTypeId = paymentTypeUserControl._paymentType.PaymentTypeId,
                    Name = paymentTypeUserControl._paymentType.Name,
                    Description = "",
                    Date = DateTime.Now,
                    Amount = 0,
                    TenderedAmount = ticket.RemainingAmount,
                    UserId = LoggedInUser.CurrentUser.UserId,
                    TerminalName = GlobalVariables.TerminalName
                };

                _genericRepositoryTicket.UpdateColumn(ticket, x => x.LastPaymentDate, DateTime.Now);
                _genericRepositoryTicket.UpdateColumn(ticket, x => x.RemainingAmount, 0);

                _genericRepositoryPayment.Add(payment);
                _genericRepositoryTicket.UpdateColumn(ticket, x => x.IsOpened, false);

                ClearTicket();

                await GlobalVariables.webSocketClient.Send(ClientCommandsEnum.REFRESH.ToString());
            }
        }

        private void ProductUserControl_Click(object sender, EventArgs e)
        {
            ProductUserControl productUserControl = (ProductUserControl)sender;

            AddOrUpdateProductToOrder(productUserControl);

            numeratorUserControl.Clear();
        }

        private async void buttonClose_Click(object sender, EventArgs e)
        {
            if (!_ticket.IsOpened)
            {
                ClearTicket();
                Navigate();

                return;
            }

            SaveTicket(true);

            if (_orders.Count > 0)
            {
                await GlobalVariables.webSocketClient.Send(ClientCommandsEnum.REFRESH.ToString());
            }

            ClearTicket();
            Navigate();
        }

        private async void buttonNewTicket_Click(object sender, EventArgs e)
        {
            SaveTicket(true);

            if (_orders.Count > 0)
            {
                await GlobalVariables.webSocketClient.Send(ClientCommandsEnum.REFRESH.ToString());
            }

            ClearTicket();
        }

        public void Navigate()
        {
            switch (_previousFormIndex)
            {
                case 0:
                    NavigationManager.OpenForm(new DashboardForm(), DockStyle.Fill, GlobalVariables.ShellForm.panelMain);
                    break;
                case 1:
                    NavigationManager.OpenForm(new TablesForm(), DockStyle.Fill, GlobalVariables.ShellForm.panelMain);
                    GlobalVariables.ShellForm.buttonMainMenu.Enabled = true;
                    break;
                case 2:
                    NavigationManager.OpenForm(new TicketsForm(), DockStyle.Fill, GlobalVariables.ShellForm.panelMain);
                    GlobalVariables.ShellForm.buttonMainMenu.Enabled = true;
                    break;
                case 3:
                    NavigationManager.OpenForm(new CustomersForm(), DockStyle.Fill, GlobalVariables.ShellForm.panelMain);
                    GlobalVariables.ShellForm.buttonMainMenu.Enabled = true;
                    break;
                default:
                    NavigationManager.OpenForm(new DashboardForm(), DockStyle.Fill, GlobalVariables.ShellForm.panelMain);
                    GlobalVariables.ShellForm.buttonMainMenu.Enabled = false;
                    break;
            }
        }

        private void buttonPayment_Click(object sender, EventArgs e)
        {
            if (_orders.Count != 0)
            {
                PaymentForm paymentForm = new PaymentForm(_ticket);
                paymentForm.ShowDialog();
            }
        }

        private void buttonProductsWitoutBarcode_Click(object sender, EventArgs e)
        {
            var products = _products.Where(x => x.Barcode == "").ToList();
            CreateProducts(products);
        }

        private void buttonProductsWithBarcode_Click(object sender, EventArgs e)
        {
            var products = _products.Where(x => x.Barcode != "").ToList();
            CreateProducts(products);
        }

        private void NumeratorTextBoxPin_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Only allow digits (0-9) or comma (,) characters
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '\b')
            {
                e.Handled = true; //Handle (ignore) the event
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                string barcode = numeratorUserControl.textBoxPin.Text;
                if (string.IsNullOrEmpty(barcode))
                {
                    return;
                }

                var productWithBarcode = _genericRepositoryProduct.Get(x => x.Barcode == barcode);
                if (productWithBarcode != null)
                {
                    ProductUserControl productUserControl = new ProductUserControl(productWithBarcode, productWithBarcode.Index);

                    AddOrUpdateProductToOrder(productUserControl);

                    numeratorUserControl.Clear();
                }
                else
                {
                    //If there is no product, add it.
                }
            }
        }

        private void buttonDiscount_Click(object sender, EventArgs e)
        {
            if (_orders.Count != 0)
            {
                if (_ticket.Payments == null || _ticket.Payments.Count == 0)
                {
                    double discount = CheckToNumeratorDiscount();
                    _ticket.Discount = discount;

                    CalculateTotalBalance();

                    numeratorUserControl.Clear();
                }
            }

            numeratorUserControl.Clear();
        }

        public async void DeleteTicket()
        {
            if (GlobalVariables.MessageBoxForm.ShowMessage(GlobalVariables.CultureHelper.GetText("ReceiptWillBeDeleted(Cancel)DoYouWantToContinue?"), GlobalVariables.CultureHelper.GetText("Warning"), MessageButton.YesNo, MessageIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            var ticket = _genericRepositoryTicket.Get(x => x.TicketGuid == _ticket.TicketGuid);
            if (ticket != null)
            {
                var payments = _genericRepositoryPayment.GetAll(x => x.TicketId == ticket.TicketId);
                _genericRepositoryPayment.DeleteAll(payments);

                var orders = _genericRepositoryOrder.GetAll(x => x.TicketId == ticket.TicketId);
                _genericRepositoryOrder.DeleteAll(orders);

                if (ticket != null)
                {
                    _genericRepositoryTicket.Delete(ticket);
                }
            }

            ClearTicket();

            await GlobalVariables.webSocketClient.Send(ClientCommandsEnum.REFRESH.ToString());
        }

        private void buttonTicketDelete_Click(object sender, EventArgs e)
        {
            DeleteTicket();
        }

        private async void buttonTickets_Click(object sender, EventArgs e)
        {
            SaveTicket(true);

            if (_orders.Count > 0)
            {
                await GlobalVariables.webSocketClient.Send(ClientCommandsEnum.REFRESH.ToString());
            }

            ClearTicket();

            NavigationManager.OpenForm(new TicketsForm(), DockStyle.Fill, GlobalVariables.ShellForm.panelMain);
            GlobalVariables.ShellForm.buttonMainMenu.Enabled = true;
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            if (_orders.Count != 0)
            {
                receiptTemplates.TicketReceipt(_orders, _ticket);
            }
        }

        private void buttonChangeTable_Click(object sender, EventArgs e)
        {
            if (_orders.Count != 0)
            {
                SaveTicket(true);

                NavigationManager.OpenForm(new TablesForm(_ticket), DockStyle.Fill, GlobalVariables.ShellForm.panelMain);
            }
        }

        private void buttonSendToKitchen_Click(object sender, EventArgs e)
        {
            if (_orders.Count != 0)
            {
                if (_productsSentToKitchen.Count > 0)
                {
                    receiptTemplates.KitchenReceipt(_productsSentToKitchen, _ticket);
                    return;
                }
                else
                {
                    if (GlobalVariables.MessageBoxForm.ShowMessage(GlobalVariables.CultureHelper.GetText("SendAllProductsToTheKitchen?"), GlobalVariables.CultureHelper.GetText("Information"), MessageButton.YesNo, MessageIcon.Information) != DialogResult.Yes)
                    {
                        return;
                    }

                    receiptTemplates.KitchenReceipt(_orders, _ticket);
                }
            }
        }

        private void buttonOpenTheDrawer_Click(object sender, EventArgs e)
        {
            CashDrawer.OpenCashdrawer();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            var products = _products.Where(x => x.Name.ToLower().Contains(textBoxSearchProduct.Text.ToLower())).ToList();
            CreateProducts(products);
        }

        private void buttonSelectCustomer_Click(object sender, EventArgs e)
        {
            if (_orders.Count != 0)
            {
                SaveTicket(true);

                NavigationManager.OpenForm(new CustomersForm(_ticket), DockStyle.Fill, GlobalVariables.ShellForm.panelMain);
            }
        }

        public void CreateQuickMenu(List<Product> products)
        {
            tableLayoutPanelProducts.SuspendLayout();

            int columnCount = 0, rowCount = 0, productIndex = 0, productCount = 20;

            int c = 1;
            for (int i = 1; i <= productCount; i++)
            {
                for (int j = productCount; j >= i; j--)
                {
                    c = i * j;
                    if (c == productCount)
                    {
                        rowCount = i;
                        columnCount = j;
                        break;
                    }
                    break;
                }
                break;
            }

            tableLayoutPanelProducts.Controls.Clear();
            tableLayoutPanelProducts.ColumnStyles.Clear();
            tableLayoutPanelProducts.RowStyles.Clear();
            tableLayoutPanelProducts.RowCount = 0;
            tableLayoutPanelProducts.ColumnCount = 0;
            for (int column = 1; column <= 5; column++)
            {
                tableLayoutPanelProducts.ColumnCount = column;
                tableLayoutPanelProducts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

                for (int row = 1; row <= rowCount; row++)
                {
                    tableLayoutPanelProducts.RowCount = row;
                    tableLayoutPanelProducts.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
                }
            }
            tableLayoutPanelProducts.RowCount++;
            tableLayoutPanelProducts.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            tableLayoutPanelProducts.RowCount++;
            tableLayoutPanelProducts.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            tableLayoutPanelProducts.RowCount++;
            tableLayoutPanelProducts.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            for (int i = 0; i < columnCount * rowCount; i++)
            {
                if (productIndex < productCount)
                {
                    var product = products.Where(x => x.Index == productIndex).FirstOrDefault();

                    ProductUserControl productUserControl = new ProductUserControl(product == null ? null : product, productIndex)
                    {
                        Dock = DockStyle.Fill
                    };

                    productUserControl.ProductClick += ProductUserControl_Click;
                    productUserControl.SelectProductClick += ProductUserControl_SelectProductClick;

                    tableLayoutPanelProducts.Controls.Add(productUserControl);

                    productIndex++;
                }
            }

            tableLayoutPanelProducts.ResumeLayout();
        }

        private void ProductUserControl_SelectProductClick(object sender, EventArgs e)
        {
            ProductUserControl productUserControl = (ProductUserControl)sender;

            QuickMenuSelectProductForm quickMenuSelectProductForm = new QuickMenuSelectProductForm(productUserControl._index);
            quickMenuSelectProductForm.ShowDialog();
        }

        public List<Product> GetQuickMenu()
        {
            List<Product> products = new List<Product>();

            string file = fileOperations.ReadFile();
            string[] menus = file.Split('#');
            foreach (var menu in menus)
            {
                if (!string.IsNullOrEmpty(menu))
                {
                    string[] properties = menu.Split('/');

                    int productId = Convert.ToInt32(properties[1]);
                    var product = _genericRepositoryProduct.Get(x => x.ProductId == productId);

                    product.Index = Convert.ToInt32(properties[0]);

                    products.Add(product);
                }
            }

            return products;
        }

        private void buttonQuickMenu_Click(object sender, EventArgs e)
        {
            CreateQuickMenu(GetQuickMenu());
        }

        private void buttonNote_Click(object sender, EventArgs e)
        {
            _ticket.Note = textBoxSearchProduct.Text;

            NoteAvailable();
        }
    }
}
