using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public class Section
    {
        [Key]
        public int SectionId { get; set; }
        public string Keyword { get; set; }
        public string Title { get; set; }
    }
}
