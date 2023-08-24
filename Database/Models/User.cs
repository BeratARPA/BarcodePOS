using Database.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Fullname => $"{Name.ToTitleCase()} {Surname.ToUpper()}";

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}
