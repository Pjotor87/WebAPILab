using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPILab.Models
{
    public class Customer
    {
        [MaxLength(10)]
        public int CustomerId { get; set; }
        [MaxLength(30)]
        public string CustomerName { get; set; }
        [MaxLength(25)]
        public string CustomerEmail { get; set; }
        [MaxLength(10)]
        public int MobileNo { get; set; }
        [MaxLength(5)]
        public IList<Transaction> RecentTransactions { get; set; }
    }
}