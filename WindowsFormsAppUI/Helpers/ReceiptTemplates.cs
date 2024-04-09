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
                totalBalance += order.Price * order.Quantity;
                report.AddRow("Orders", order.ProductName, order.Quantity.ToString(), string.Format("{0:C}", order.Price * order.Quantity));
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
                report.AddRow("Orders", order.ProductName, order.Quantity.ToString());
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
