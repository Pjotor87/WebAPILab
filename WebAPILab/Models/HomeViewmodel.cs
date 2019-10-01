using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPILab.DAL;

namespace WebAPILab.Models
{
    public class HomeViewModel
    {
        public IList<Customer> Customers { get; set; }
        public IList<Transaction> Transactions { get; set; }

        public HomeViewModel()
        {
            CustomerContext customerContext = new CustomerContext();
            this.Customers = customerContext.Customers.ToList();
        }
    }
}