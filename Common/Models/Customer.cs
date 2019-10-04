using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Common.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Range(1, 9999999999)]
        public int CustomerId { get; set; }
        [MaxLength(30)]
        public string CustomerName { get; set; }
        [MaxLength(25)]
        [EmailAddress]
        public string CustomerEmail { get; set; }
        [Range(1, 9999999999)]
        public double MobileNo { get; set; }
        public string TransactionIds { get; set; }
        public IList<Transaction> Transactions { get; set; }

        public void PopulateTransactions(IList<Transaction> transactions)
        {
            if (transactions != null && transactions.Count > 0)
            {
                int[] transactionIds =
                !string.IsNullOrEmpty(this.TransactionIds) ?
                Array.ConvertAll(this.TransactionIds.Split(','), x => int.Parse(x)) :
                null;
                this.Transactions =
                    transactionIds != null ?
                    transactions.Where(x => transactionIds.Contains(x.TransactionId)).ToList() :
                    new List<Transaction>();
            }
        }

        public IList<Transaction> GetMostRecentTransactions(int take)
        {
            return this.Transactions.OrderByDescending(x => x.TransactionDateTime).Take(take).ToList();
        }

        public void SetMostRecentTransactions(int take)
        {
            this.Transactions = this.GetMostRecentTransactions(take);
        }
    }
}