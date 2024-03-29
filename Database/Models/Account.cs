using System;
using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
