using Database.Data;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsAppUI.Helpers;
using WindowsFormsAppUI.UserControls;

namespace WindowsFormsAppUI.Forms
{
    public partial class POSForm : Form
    {
        private readonly IGenericRepository<Product> _genericRepositoryProduct = new GenericRepository<Product>(GlobalVariables.SQLContext);
        private readonly IGenericRepository<Category> _genericRepositoryCategory = new GenericRepository<Category>(GlobalVariables.SQLContext);
        private readonly IGenericRepository<Ticket> _genericRepositoryTicket = new GenericRepository<Ticket>(GlobalVariables.SQLContext);
        private readonly IGenericRepository<Order> _genericRepositoryOrder = new GenericRepository<Order>(GlobalVariables.SQLContext);
        private readonly IGenericRepository<PaymentType> _genericRepositoryPaymentType = new GenericRepository<PaymentType>(GlobalVariables.SQLContext);
        private readonly IGenericRepository<Payment> _genericRepositoryPayment = new GenericRepository<Payment>(GlobalVariables.SQLContext);

        private Ticket _ticket = new Ticket();
        private List<Ticket> _tickets = new List<Ticket>();
        private List<Order> _orders = new List<Order>();
        private List<Product> _products = new List<Product>();
        private List<Category> _category = new List<Category>();
        private List<PaymentType> _paymentTypes = new List<PaymentType>();

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000; //WS_EX_COMPOSITED
                return handleParam;
            }
        }

        public POSForm(Ticket ticket = null)
        {
            InitializeComponent();

            numeratorUserControl.textBoxPin.KeyPress += new KeyPressEventHandler(NumeratorTextBoxPin_KeyPress);

            _ticket = ticket;
        }

        private void POSForm_Load(object sender, EventArgs e)
        {
            CreateTicket();

            CloseAndOpenTicket();

            _products = _genericRepositoryProduct.GetAll();
            _category = _genericRepositoryCategory.GetAll();
            _paymentTypes = _genericRepositoryPaymentType.GetAll();
            CreateProducts(_products);
            CreateCategories(_category);
            CreatePayments(_paymentTypes);
            CalculateTotalBalance();
        }

        public void CloseAndOpenTicket()
        {
            if (!_ticket.IsOpened)
            {
                tableLayoutPanelProducts.Enabled = false;
                tableLayoutPanelPaymentTypes.Enabled = false;
                numeratorUserControl.Enabled = false;
                tableLayoutPanelCategories.Enabled = false;
                flowLayoutPanelOrders.Enabled = false;
                buttonDiscount.Enabled = false;
                buttonMultiplePayment.Enabled = false;
                buttonClose.Enabled = true;
            }
            else
            {
                tableLayoutPanelProducts.Enabled = true;
                tableLayoutPanelPaymentTypes.Enabled = true;
                numeratorUserControl.Enabled = true;
                tableLayoutPanelCategories.Enabled = true;
                flowLayoutPanelOrders.Enabled = true;
                buttonDiscount.Enabled = true;
                buttonMultiplePayment.Enabled = true;
                buttonClose.Enabled = true;
            }
        }

        public void CreateTicket()
        {
            _tickets = _genericRepositoryTicket.GetAll();

            if (_ticket != null)
            {
                foreach (Order order in _ticket.Orders)
                {
                    var product = _genericRepositoryProduct.GetAll(x => x.ProductId == order.ProductId).FirstOrDefault();
                    ProductUserControl productUserControl = new ProductUserControl(product);

                    ProductOnCardUserControl newProductOnCard = CreateNewProductOnCard(productUserControl, order);
                    flowLayoutPanelOrders.Controls.Add(newProductOnCard);

                    _orders.Add(order);
                }

                CalculateTotalBalance();

                return;
            }

            int lastTicketNumber = 0;
            try { lastTicketNumber = _tickets.Max(x => int.Parse(x.TicketNumber)); }
            catch { lastTicketNumber = 0; }

            Ticket ticket = new Ticket
            {
                TicketGuid = Guid.NewGuid(),
                LastUpdateDate = DateTime.Now,
                TicketNumber = (lastTicketNumber + 1).ToString(),
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
                Price = quantity * product.Price,
                Quantity = quantity,
                TerminalName = GlobalVariables.TerminalName,
                CreatingUserName = LoggedInUser.CurrentUser.Fullname,
                CreatedDateTime = DateTime.Now,
                LastUpdateDateTime = DateTime.Now
            };

            _orders.Add(order);

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
                    ProductUserControl productUserControl = new ProductUserControl(products[productIndex])
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
            order.Price = totalPrice;
            order.LastUpdateDateTime = DateTime.Now;
            _ticket.LastOrderDate = DateTime.Now;
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
                totalBalance += order.Price;
            }

            labelTicketTotal.Text = string.Format("{0:C}", totalBalance);

            //Discount
            if (_ticket.Discount != 0)
            {
                tableLayoutPanelLabels.RowStyles[0].Height = 33;
                tableLayoutPanelLabels.RowStyles[1].Height = 33;
                totalBalance = DiscountHelper.Calculate(totalBalance, _ticket.Discount);

                labelDiscountPercent.Text = string.Format("Iskonto {0:N}%", _ticket.Discount);
                labelDiscount.Text = string.Format("({0:C})", DiscountHelper.discountAmount);
            }
            else
            {
                tableLayoutPanelLabels.RowStyles[0].Height = 0;
                tableLayoutPanelLabels.RowStyles[1].Height = 0;
            }

            labelBalance.Text = string.Format("{0:C}", totalBalance);


            //
            if (totalBalance == 0)
            {
                tableLayoutPanelMiddle.RowStyles[1].Height = 0;
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

            tableLayoutPanelMiddle.RowStyles[1].Height = 100;

            return totalBalance;
        }

        public void SaveTicket()
        {
            if (_orders.Count != 0)
            {
                Ticket ticket = null;
                ticket = _genericRepositoryTicket.GetAll(x => x.TicketGuid == _ticket.TicketGuid).FirstOrDefault();
                if (ticket != null)
                {
                    ticket = _ticket;
                    _genericRepositoryTicket.Update(ticket);
                }
                else
                {
                    _genericRepositoryTicket.Add(_ticket);
                    ticket = _genericRepositoryTicket.GetAll(x => x.TicketGuid == _ticket.TicketGuid).FirstOrDefault();
                }

                foreach (Order order in _orders)
                {
                    var checkOrder = _genericRepositoryOrder.GetAll(x => x.TicketId == ticket.TicketId && x.ProductId == order.ProductId).FirstOrDefault();
                    if (checkOrder != null)
                    {
                        _genericRepositoryOrder.Update(order);
                    }
                    else
                    {
                        order.TicketId = ticket.TicketId;
                        _genericRepositoryOrder.Add(order);
                    }
                }
            }
        }

        public void ClearTicket()
        {
            _ticket = null;
            _orders.Clear();
            flowLayoutPanelOrders.Controls.Clear();
            CreateTicket();
            CalculateTotalBalance();
            CloseAndOpenTicket();
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
                    order.Price = totalPrice;
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

        private void PaymentTypeUserControl_Click(object sender, EventArgs e)
        {
            if (_orders.Count != 0)
            {
                PaymentTypeUserControl paymentTypeUserControl = (PaymentTypeUserControl)sender;

                if (GlobalVariables.MessageBoxForm.ShowMessage(paymentTypeUserControl._paymentType.Name + " ile ödeme alınacak, onaylıyor musunuz?", "Bilgi", MessageButton.YesNo, MessageIcon.Information) != DialogResult.Yes)
                {
                    return;
                }

                Ticket ticket = null;
                ticket = _genericRepositoryTicket.GetAll(x => x.TicketGuid == _ticket.TicketGuid).FirstOrDefault();
                if (ticket == null)
                {
                    SaveTicket();
                    ticket = _genericRepositoryTicket.GetAll(x => x.TicketGuid == _ticket.TicketGuid).FirstOrDefault();
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
            }
        }

        private void ProductUserControl_Click(object sender, EventArgs e)
        {
            ProductUserControl productUserControl = (ProductUserControl)sender;

            AddOrUpdateProductToOrder(productUserControl);

            numeratorUserControl.Clear();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            if (_orders.Count == 0 || !_ticket.IsOpened)
            {
                ClearTicket();
                NavigationManager.OpenForm(new DashboardForm(), DockStyle.Fill, GlobalVariables.ShellForm.panelMain);
                return;
            }

            SaveTicket();

            ClearTicket();

            NavigationManager.OpenForm(new DashboardForm(), DockStyle.Fill, GlobalVariables.ShellForm.panelMain);
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
            var products = _products.Where(x => x.Barcode == " ").ToList();
            CreateProducts(products);
        }

        private void buttonProductsWithBarcode_Click(object sender, EventArgs e)
        {
            var products = _products.Where(x => x.Barcode != " ").ToList();
            CreateProducts(products);
        }

        private void NumeratorTextBoxPin_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sadece rakam (0-9) veya virgül (,) karakterlerine izin verme
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '\b') // '\b' BACKSPACE karakteridir
            {
                e.Handled = true; // Olayı işleme (yoksayma)
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                string barcode = numeratorUserControl.textBoxPin.Text;
                if (string.IsNullOrEmpty(barcode))
                {
                    return;
                }

                var productWithBarcode = _genericRepositoryProduct.GetAll(x => x.Barcode == barcode).FirstOrDefault();
                if (productWithBarcode != null)
                {
                    ProductUserControl productUserControl = new ProductUserControl(productWithBarcode);

                    AddOrUpdateProductToOrder(productUserControl);

                    numeratorUserControl.Clear();
                }
                else
                {

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

        private void buttonTicketDelete_Click(object sender, EventArgs e)
        {
            if (_orders.Count != 0)
            {
                if (GlobalVariables.MessageBoxForm.ShowMessage("Fiş silinecek(İptal) devam etmek istiyor musunuz?", "Uyarı", MessageButton.YesNo, MessageIcon.Warning) != DialogResult.Yes)
                {
                    return;
                }

                var ticket = _genericRepositoryTicket.GetAll(x => x.TicketGuid == _ticket.TicketGuid).FirstOrDefault();
                var payments = _genericRepositoryPayment.GetAll(x => x.TicketId == ticket.TicketId);
                foreach (Payment payment in payments)
                {
                    _genericRepositoryPayment.Delete(payment);
                }

                var orders = _genericRepositoryOrder.GetAll(x => x.TicketId == ticket.TicketId);
                foreach (Order order in orders)
                {
                    _genericRepositoryOrder.Delete(order);
                }

                if (ticket != null)
                {
                    _genericRepositoryTicket.Delete(ticket);
                }

                ClearTicket();
            }
        }

        private void buttonTickets_Click(object sender, EventArgs e)
        {
            SaveTicket();

            ClearTicket();

            NavigationManager.OpenForm(new TicketsForm(), DockStyle.Fill, GlobalVariables.ShellForm.panelMain);
            GlobalVariables.ShellForm.buttonMainMenu.Enabled = true;
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            if (_orders.Count != 0)
            {
                //PrintHelper printHelper = new PrintHelper(PrintType.MM80, "test80mm");
                PrintHelper printHelper = new PrintHelper(PrintType.MM58, "test58mm");
            }
        }

        private void buttonNewTicket_Click(object sender, EventArgs e)
        {
            SaveTicket();

            ClearTicket();
        }
    }
}
