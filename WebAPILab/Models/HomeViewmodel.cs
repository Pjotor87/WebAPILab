using System.Collections.Generic;
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
            this.Customers = databaseContext.Customers.ToList();
            this.Transactions = databaseContext.Transactions.ToList();

            foreach (var customer in this.Customers)
                customer.PopulateTransactions(this.Transactions);
        }
    }
}