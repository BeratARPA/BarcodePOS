using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string PrinterName { get; set; }
        public string BackColor { get; set; }
        public string ForeColor { get; set; }
        public int FontSize { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
