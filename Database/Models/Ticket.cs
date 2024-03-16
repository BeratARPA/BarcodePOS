using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
        public Guid TicketGuid { get; set; }
        public int TableId { get; set; }
        public int CustomerId { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public string TicketNumber { get; set; }
        public DateTime Date { get; set; }
        public DateTime LastOrderDate { get; set; }
        public DateTime LastPaymentDate { get; set; }
        public bool IsOpened { get; set; }
        public bool IsPrinted { get; set; }
        public double RemainingAmount { get; set; }
        public double TotalAmount { get; set; }
        public double Discount { get; set; }
        public string TerminalName { get; set; }
        public string Note { get; set; }
        public string LastModifiedUserName { get; set; }
        public string CreatedUserName { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
