using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public class PaymentType
    {
        [Key]
        public int PaymentTypeId { get; set; }
        public string Name { get; set; }
        public string BackColor { get; set; }
        public string ForeColor { get; set; }
        public int FontSize { get; set; }
    }
}
