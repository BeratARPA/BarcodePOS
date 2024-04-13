using Database.Data;
using Database.Models;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Windows;
using System.Windows.Documents;

namespace WindowsFormsAppUI.Helpers
{
    public class ReceiptTemplates
    {
        private readonly IGenericRepository<Product> _genericRepositoryProduct = new GenericRepository<Product>(GlobalVariables.SQLContext);
        private readonly IGenericRepository<CompanyInformation> _genericRepositoryCompanyInformation = new GenericRepository<CompanyInformation>(GlobalVariables.SQLContext);

        private readonly string CompanyName;

        public ReceiptTemplates()
        {
            CompanyName = _genericRepositoryCompanyInformation.GetById(1).Name;
        }

        public FlowDocument TicketsReport(List<Ticket> tickets)
        {
            double totalSales = 0;
            double total = 0;

            SimpleReport report = new SimpleReport();

            report.AddHeader("Fiş Satış Raporu");

            var query = tickets
                .GroupBy(t => t.CustomerId == 0)
                .Select(g => new
                {
                    Name = g.Key ? "Masa" : "Paket",
                    Count = g.Count(),
                    Total = g.Sum(t => t.TotalAmount)
                })
                .ToList();


            report.AddColumTextAlignment("Sales", TextAlignment.Left, TextAlignment.Center);
            report.AddColumnLength("Sales", "auto", "20*", "20*");
            report.AddTable("Sales", GlobalVariables.CultureHelper.GetText("Tickets"), GlobalVariables.CultureHelper.GetText("Unit"), GlobalVariables.CultureHelper.GetText("Amount"));
            foreach (var ticket in query)
            {
                totalSales += ticket.Count;
                total += ticket.Total;
                report.AddRow("Sales", ticket.Name, ticket.Count.ToString(), string.Format("{0:C}", ticket.Total));
            }

            report.AddLine("line1");

            report.AddRow("Sales", "", "");
            report.AddRow("Sales", GlobalVariables.CultureHelper.GetText("Total") + ":", totalSales.ToString(), string.Format("{0:C}", total));

            report.AddFooter("Footer", CompanyName, true);

            report.Document.PageWidth = 302;
            report.Document.PageHeight = report.GetDocumentHeight();

            return report.Document;
        }

        public FlowDocument ProductSalesReport(List<Order> orders)
        {
            double totalSales = 0;
            double total = 0;

            SimpleReport report = new SimpleReport();

            report.AddHeader("Ürün Satış Raporu");

            var query = from o in orders
                        group o by new { o.ProductId, o.ProductName } into g
                        select new
                        {
                            Name = g.Key.ProductName,
                            TotalQuantity = g.Sum(x => x.Quantity),
                            Total = g.Sum(x => x.Quantity * x.Price)
                        };


            report.AddColumTextAlignment("Sales", TextAlignment.Left, TextAlignment.Center);
            report.AddColumnLength("Sales", "auto", "20*", "20*");
            report.AddTable("Sales", GlobalVariables.CultureHelper.GetText("Product"), GlobalVariables.CultureHelper.GetText("Unit"), GlobalVariables.CultureHelper.GetText("Amount"));
            foreach (var productSales in query)
            {
                totalSales += productSales.TotalQuantity;
                total += productSales.Total;
                report.AddRow("Sales", productSales.Name, productSales.TotalQuantity.ToString(), string.Format("{0:C}", productSales.Total));
            }

            report.AddLine("line1");

            report.AddRow("Sales", "", "");
            report.AddRow("Sales", GlobalVariables.CultureHelper.GetText("Total") + ":", totalSales.ToString(), string.Format("{0:C}", total));

            report.AddFooter("Footer", CompanyName, true);

            report.Document.PageWidth = 302;
            report.Document.PageHeight = report.GetDocumentHeight();

            return report.Document;
        }

        public FlowDocument CategorySalesReport(List<Ticket> tickets, List<Order> orders, List<Product> products, List<Category> categories)
        {
            double totalSales = 0;
            double total = 0;

            SimpleReport report = new SimpleReport();

            report.AddHeader("Kategori Satış Raporu");

            var query = from t in tickets
                        join o in orders on t.TicketId equals o.TicketId
                        join p in products on o.ProductId equals p.ProductId
                        join c in categories on p.CategoryId equals c.CategoryId
                        where t.IsOpened == false
                        group o by new { c.CategoryId, c.Name } into grouped
                        select new
                        {
                            CategoryID = grouped.Key.CategoryId,
                            CategoryName = grouped.Key.Name,
                            TotalQuantity = grouped.Sum(x => x.Quantity),
                            Total = grouped.Sum(x => x.Price * x.Quantity)
                        };


            report.AddColumTextAlignment("Sales", TextAlignment.Left, TextAlignment.Center);
            report.AddColumnLength("Sales", "auto", "20*", "20*");
            report.AddTable("Sales", GlobalVariables.CultureHelper.GetText("Categories"), GlobalVariables.CultureHelper.GetText("Unit"), GlobalVariables.CultureHelper.GetText("Amount"));
            foreach (var categoriesSales in query)
            {
                totalSales += categoriesSales.TotalQuantity;
                total += categoriesSales.Total;
                report.AddRow("Sales", categoriesSales.CategoryName, categoriesSales.TotalQuantity.ToString(), string.Format("{0:C}", categoriesSales.Total));
            }

            report.AddLine("line1");

            report.AddRow("Sales", "", "");
            report.AddRow("Sales", GlobalVariables.CultureHelper.GetText("Total") + ":", totalSales.ToString(), string.Format("{0:C}", total));

            report.AddFooter("Footer", CompanyName, true);

            report.Document.PageWidth = 302;
            report.Document.PageHeight = report.GetDocumentHeight();

            return report.Document;
        }

        public FlowDocument RevenuesReport(List<Payment> payments)
        {
            double totalRevenues = 0;

            SimpleReport report = new SimpleReport();

            report.AddHeader("Hasılat Raporu");

            var paymentTotalAmounts = payments
            .GroupBy(p => p.PaymentTypeId)
            .Select(g => new
            {
                PaymentName = g.First().Name,
                Total = g.Sum(p => p.TenderedAmount)
            });

            report.AddColumTextAlignment("Sales", TextAlignment.Left, TextAlignment.Center);
            report.AddColumnLength("Sales", "auto", "20*");
            report.AddTable("Sales", GlobalVariables.CultureHelper.GetText("PaymentTypes"), GlobalVariables.CultureHelper.GetText("Amount"));
            foreach (var paymentTotalAmount in paymentTotalAmounts)
            {
                totalRevenues += paymentTotalAmount.Total;
                report.AddRow("Sales", paymentTotalAmount.PaymentName, string.Format("{0:C}", paymentTotalAmount.Total));
            }

            report.AddLine("line1");

            report.AddRow("Sales", "", "");
            report.AddRow("Sales", GlobalVariables.CultureHelper.GetText("Total") + ":", string.Format("{0:C}", totalRevenues));

            report.AddFooter("Footer", CompanyName, true);

            report.Document.PageWidth = 302;
            report.Document.PageHeight = report.GetDocumentHeight();

            return report.Document;
        }

        public FlowDocument TicketReceipt(List<Order> orders, Ticket ticket)
        {
            double totalBalance = 0;

            SimpleReport report = new SimpleReport();

            report.AddHeader(CompanyName);

            report.AddParagraph("Description");
            report.AddParagraphLine("Description", GlobalVariables.CultureHelper.GetText("TicketNumber") + ": " + ticket.TicketNumber);
            report.AddParagraphLine("Description", GlobalVariables.CultureHelper.GetText("Time") + ": " + ticket.Date);
            report.AddParagraphLine("Description", GlobalVariables.CultureHelper.GetText("User") + ": " + ticket.CreatedUserName);
            if (ticket.TableId != 0)
            {
                report.AddParagraphLine("Description", GlobalVariables.CultureHelper.GetText("Table") + ": " + TableName.GetName(ticket.TableId));
            }
            if (!string.IsNullOrEmpty(ticket.Note))
            {
                report.AddParagraphLine("Description", GlobalVariables.CultureHelper.GetText("Note") + ": " + ticket.Note);
            }
            if (ticket.CustomerId != 0)
            {
                report.AddParagraphLine("Description", string.Format(GlobalVariables.CultureHelper.GetText("POSCustomer"), CustomerHelper.GetNameAndPhoneNumber(ticket.CustomerId)));
                report.AddParagraphLine("Description", GlobalVariables.CultureHelper.GetText("CustomerAddress") + ": " + CustomerHelper.GetAddress(ticket.CustomerId));
            }

            report.AddLine("line1");

            report.AddColumTextAlignment("Orders", TextAlignment.Left, TextAlignment.Center, TextAlignment.Center);
            report.AddColumnLength("Orders", "auto", "20*", "20*");
            report.AddTable("Orders", GlobalVariables.CultureHelper.GetText("Product"), GlobalVariables.CultureHelper.GetText("Unit"), GlobalVariables.CultureHelper.GetText("Amount"));
            foreach (var order in orders)
            {
                var product = _genericRepositoryProduct.GetById(order.ProductId);

                totalBalance += order.Price * order.Quantity;
                report.AddRow("Orders", order.ProductName, order.Quantity.ToString() + $" {UnitConvert.UnitOfMeasureToString(product.UnitOfMeasure)}", string.Format("{0:C}", order.Price * order.Quantity));
            }

            report.AddLine("line2");

            report.AddTable("Total");
            report.AddText("Total", GlobalVariables.CultureHelper.GetText("Total") + ":", string.Format("{0:C}", totalBalance));
            if (ticket.Discount != 0)
            {
                totalBalance = DiscountHelper.Calculate(totalBalance, ticket.Discount);
                report.AddText("Total", GlobalVariables.CultureHelper.GetText("ReceiptDiscount") + ":", string.Format("{0:C}", DiscountHelper.discountAmount));
                report.AddText("Total", GlobalVariables.CultureHelper.GetText("General") + ":", string.Format("{0:C}", totalBalance));
            }

            report.AddFooter("Footer", GlobalVariables.CultureHelper.GetText("ReceiptFooter"), true);

            report.Document.PageWidth = 302;
            report.Document.PageHeight = report.GetDocumentHeight();

            PrinterSettings printerSettings = new PrinterSettings();
            var printQueue = PrintersHelper.GetPrinter(printerSettings.PrinterName);
            AsyncPrintTask.Exec(true, () => PrintersHelper.PrintFlowDocument(printQueue, report.Document));

            return report.Document;
        }

        #region Kitchen
        public void KitchenReceipt(List<Order> orders, Ticket ticket)
        {
            var productsId = orders.Select(o => o.ProductId).ToList();

            var groupedCategories = _genericRepositoryProduct
                .GetAllAsNoTracking(p => productsId.Contains(p.ProductId))
                .GroupBy(p => new { p.CategoryId, p.Category.PrinterName })
                .ToList();

            // Check if all printers are the same
            var distinctPrinters = groupedCategories.Select(group => group.Key.PrinterName).Distinct().ToList();

            if (distinctPrinters.Count == 1)
            {
                // If all printers are the same, print all orders in one receipt
                KitchenTemplate(orders, ticket, distinctPrinters.First());
            }
            else
            {
                // If printers are different, print each category's orders in separate receipts
                foreach (var categoryGroup in groupedCategories)
                {
                    var category = categoryGroup.Key;
                    var printerName = category.PrinterName;
                    var filteredOrders = orders.Where(o => _genericRepositoryProduct.GetById(o.ProductId).CategoryId == category.CategoryId).ToList();

                    KitchenTemplate(filteredOrders, ticket, printerName);
                }
            }
        }

        public FlowDocument KitchenTemplate(List<Order> orders, Ticket ticket, string printerName)
        {
            SimpleReport report = new SimpleReport();

            report.AddHeader(CompanyName);

            report.AddParagraph("Description");
            report.AddParagraphLine("Description", GlobalVariables.CultureHelper.GetText("TicketNumber") + ": " + ticket.TicketNumber);
            report.AddParagraphLine("Description", GlobalVariables.CultureHelper.GetText("Time") + ": " + ticket.Date);
            if (ticket.TableId != 0)
            {
                report.AddParagraphLine("Description", GlobalVariables.CultureHelper.GetText("Table") + ": " + TableName.GetName(ticket.TableId));
            }
            if (!string.IsNullOrEmpty(ticket.Note))
            {
                report.AddParagraphLine("Description", GlobalVariables.CultureHelper.GetText("Note") + ": " + ticket.Note);
            }

            report.AddLine("line1");

            report.AddColumTextAlignment("Orders", TextAlignment.Left, TextAlignment.Center);
            report.AddColumnLength("Orders", "auto", "20*");
            report.AddTable("Orders", GlobalVariables.CultureHelper.GetText("Product"), GlobalVariables.CultureHelper.GetText("Unit"));
            foreach (var order in orders)
            {
                var product = _genericRepositoryProduct.GetById(order.ProductId);

                report.AddRow("Orders", order.ProductName, order.Quantity.ToString() + $" {UnitConvert.UnitOfMeasureToString(product.UnitOfMeasure)}");
            }

            report.Document.PageWidth = 302;
            report.Document.PageHeight = report.GetDocumentHeight();

            PrinterSettings printerSettings = new PrinterSettings();
            var printQueue = PrintersHelper.GetPrinter(printerName);
            AsyncPrintTask.Exec(true, () => PrintersHelper.PrintFlowDocument(printQueue, report.Document));

            return report.Document;
        }
        #endregion
    }
}
