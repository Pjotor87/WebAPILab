using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using WebAPILab.DAL;

namespace WebAPILab.Models
{
    public class HomeViewModel
    {
        public IList<Customer> Customers { get; set; }
        public IList<Transaction> Transactions { get; set; }

        public HomeViewModel(DatabaseContext databaseContext)
        {
            DbSet<Customer> customers = databaseContext.Customers;
            DbSet<Transaction> transactions = databaseContext.Transactions;

            try
            {
                this.Customers = customers.ToList();
            }
            catch (DataException ex)
            {
                this.Customers = new List<Customer>();
            }

            try
            {
                this.Transactions = transactions.ToList();
            }
            catch (DataException ex)
            {
                this.Transactions = new List<Transaction>();
            }

            foreach (var customer in this.Customers)
                customer.PopulateTransactions(this.Transactions);
        }
    }
}