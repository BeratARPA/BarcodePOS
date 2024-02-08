using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public class CompanyInformation
    {
        [Key]
        public int CompanyInformationId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string EMail { get; set; }
    }
}
