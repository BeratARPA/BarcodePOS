using Database.Data;
using Database.Models;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Windows;

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

        private void KitchenTemplate(List<Order> orders, Ticket ticket, string printerName)
        {
            SimpleReport report = new SimpleReport();

            report.AddHeader(CompanyName);

            report.AddParagraph("Description");
            report.AddParagraphLine("Description", GlobalVariables.CultureHelper.GetText("TicketNumber") +": " + ticket.TicketNumber);
            report.AddParagraphLine("Description", GlobalVariables.CultureHelper.GetText("Time") + ": " + ticket.Date);
            if (!string.IsNullOrEmpty(ticket.Note))
            {
                report.AddParagraphLine("Description", GlobalVariables.CultureHelper.GetText("Note")+": " + ticket.Note);
            }

            report.AddLine();

            report.AddColumTextAlignment("Orders", TextAlignment.Left, TextAlignment.Center, TextAlignment.Center);
            report.AddColumnLength("Orders", "80*", "20*");
            report.AddTable("Orders", GlobalVariables.CultureHelper.GetText("Product"), GlobalVariables.CultureHelper.GetText("Unit"));
            foreach (var order in orders)
            {
                report.AddRow("Orders", order.ProductName, order.Quantity.ToString());
            }

            PrinterSettings printerSettings = new PrinterSettings();
            var printQueue = PrintersHelper.GetPrinter(printerName);
            AsyncPrintTask.Exec(true, () => PrintersHelper.PrintFlowDocument(printQueue, report.Document));
        }
        #endregion
    }
}
