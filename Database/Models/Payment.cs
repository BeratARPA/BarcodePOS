using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        public int? TicketId { get; set; }
        public int PaymentTypeId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public double TenderedAmount { get; set; }
        public string TerminalName { get; set; }


        [ForeignKey("TicketId")]
        public virtual Ticket Ticket { get; set; }
    }
}
