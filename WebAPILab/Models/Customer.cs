using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPILab.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public int MobileNo { get; set; }
        public IList<Transaction> RecentTransactions { get; set; }
    }
}