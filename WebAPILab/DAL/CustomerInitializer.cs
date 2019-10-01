using System;
using System.Collections.Generic;
using System.Data.Entity;
using WebAPILab.Models;

namespace WebAPILab.DAL
{
    public class CustomerInitializer : DropCreateDatabaseAlways<CustomerContext>
    {
        public CustomerInitializer(CustomerContext customerContext)
        {
            this.InitializeDatabase(customerContext);
        }

        protected override void Seed(CustomerContext context)
        {
            var customers = new List<Customer>
            {
                new Customer{
                    Id = 1,
                    CustomerId = 123456,
                    CustomerName = "Firstname Lastname",
                    CustomerEmail = "user@domain.com",
                    MobileNo = 0123456789,
                    RecentTransactions = new List<Transaction> {
                        new Transaction()
                    }
                },
                new Customer{
                    Id = 1,
                    CustomerId = 198475,
                    CustomerName = "Peter Andersson",
                    CustomerEmail = "user2@domain.com",
                    MobileNo = 9876543210,
                    RecentTransactions = new List<Transaction> {
                        new Transaction()
                        {
                            TransactionId = 1,
                            Amount = 199.90,
                            CurrencyCode = "SEK",
                            TransactionDateTime = DateTime.Now,
                            Status = Constants.TransactionStatus.Success
                        }
                    }
                }
            };

            customers.ForEach(x => context.Customers.Add(x));
            context.SaveChanges();
        }
    }
}