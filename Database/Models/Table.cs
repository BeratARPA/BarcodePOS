using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Models
{
    public class Table
    {
        [Key]
        public int TableId { get; set; }
        public int SectionId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }

        [ForeignKey("SectionId")]
        public virtual Section Section { get; set; }
    }
}
