using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public int Index { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public string BackColor { get; set; }
        public string ForeColor { get; set; }
        public int UnitOfMeasure { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}