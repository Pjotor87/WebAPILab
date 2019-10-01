using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPILab.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        [MaxLength(30)]
        public string CustomerName { get; set; }
        [MaxLength(25)]
        public string CustomerEmail { get; set; }
        public double MobileNo { get; set; }

        [ForeignKey("TransactionId")]
        public virtual IEnumerable<Transaction> RecentTransactions { get; set; }
    }
}