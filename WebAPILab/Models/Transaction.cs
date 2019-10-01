using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPILab.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public DateTime TransactionTimeStamp { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }

    }
}