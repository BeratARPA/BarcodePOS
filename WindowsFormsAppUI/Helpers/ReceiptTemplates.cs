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

        public void KitchenReceipt(List<Order> orders)
        {
            var productsId = orders.Select(o => o.ProductId).ToList();

            var groupedCategoriesId = _genericRepositoryProduct
                .GetAll(p => productsId.Contains(p.ProductId))
                 .GroupBy(p => new { p.CategoryId, p.Category.PrinterName })
                .GroupBy(categoryId => categoryId)
                .Select(group => group.Key)
                .ToList();

            foreach (var category in groupedCategoriesId)
            {
                var filteredOrders = orders
                    .Where(o => _genericRepositoryProduct.GetById(o.ProductId).CategoryId == category.Key.CategoryId)
                    .ToList();

                SimpleReport report = new SimpleReport();

                report.AddHeader("Mutfak Makbuzu");

                report.AddColumTextAlignment("Orders", TextAlignment.Left, TextAlignment.Center, TextAlignment.Center);
                report.AddColumnLength("Ürünler", "80*", "20*");
                report.AddTable("Orders", "Ürün", "Birim");
                foreach (var order in filteredOrders)
                {
                    report.AddRow("Orders", order.ProductName, order.Quantity.ToString());
                }
                var a =PrintersHelper.GetPrinterNames();
                PrinterSettings printerSettings = new PrinterSettings();
                var printQueue = PrintersHelper.GetPrinter(category.Key.PrinterName);
                AsyncPrintTask.Exec(true, () => PrintersHelper.PrintFlowDocument(printQueue, report.Document));
            }
        }
    }
}
