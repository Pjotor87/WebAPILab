using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using DAL;
using Models;
using Services.LoggingService;

namespace WebAPILab.Models
{
    public class HomeViewModel : IHomeViewModel
    {
        public IList<Customer> Customers { get; set; }
        public IList<Transaction> Transactions { get; set; }

        public HomeViewModel(IDatabaseContext databaseContext, ILogger logger)
        {
            DbSet<Customer> customers = databaseContext.Customers;
            DbSet<Transaction> transactions = databaseContext.Transactions;

            logger.Log("TEST");

            try
            {
                this.Customers = customers.ToList();
            }
            catch (DataException ex)
            {
                this.Customers = new List<Customer>();
                logger.Log(ex.ToString());
            }

            try
            {
                this.Transactions = transactions.ToList();
            }
            catch (DataException ex)
            {
                this.Transactions = new List<Transaction>();
                logger.Log(ex.ToString());
            }

            foreach (var customer in this.Customers)
                customer.PopulateTransactions(this.Transactions);
        }
    }
}