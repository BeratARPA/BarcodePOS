using System;
using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public class OldCalling
    {
        [Key]
        public int OldCallingId { get; set; }
        public string Serial { get; set; }
        public string Line { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CallingDateTime { get; set; }
    }
}
