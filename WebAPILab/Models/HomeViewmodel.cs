using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using Common.Models;
using DAL;

namespace WebAPILab.Models
{
    public class HomeViewModel
    {
        public IList<ICustomer> Customers { get; set; }
        public IList<ITransaction> Transactions { get; set; }

        public HomeViewModel(IDatabaseContext databaseContext)
        {
            DbSet<ICustomer> customers = databaseContext.Customers;
            DbSet<ITransaction> transactions = databaseContext.Transactions;

            try
            {
                this.Customers = customers.ToList();
            }
            catch (DataException ex)
            {
                this.Customers = new List<ICustomer>();
                File.AppendAllText(ConfigurationManager.AppSettings["LogFilePath"], $"{DateTime.Now.ToString()} ERROR: {ex.ToString()}");
            }

            try
            {
                this.Transactions = transactions.ToList();
            }
            catch (DataException ex)
            {
                this.Transactions = new List<ITransaction>();
                File.AppendAllText(ConfigurationManager.AppSettings["LogFilePath"], $"{DateTime.Now.ToString()} ERROR: {ex.ToString()}");
            }

            foreach (var customer in this.Customers)
                customer.PopulateTransactions(this.Transactions);
        }
    }
}