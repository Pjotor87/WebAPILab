using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.IO;
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
                File.AppendAllText(ConfigurationManager.AppSettings["LogFilePath"], $"{DateTime.Now.ToString()} ERROR: {ex.ToString()}");
            }

            try
            {
                this.Transactions = transactions.ToList();
            }
            catch (DataException ex)
            {
                this.Transactions = new List<Transaction>();
                File.AppendAllText(ConfigurationManager.AppSettings["LogFilePath"], $"{DateTime.Now.ToString()} ERROR: {ex.ToString()}");
            }

            foreach (var customer in this.Customers)
                customer.PopulateTransactions(this.Transactions);
        }
    }
}