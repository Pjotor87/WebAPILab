using System;
using System.Collections.Generic;
using System.Data.Entity;
using WebAPILab.Models;

namespace WebAPILab.DAL
{
    public class DatabaseInitializer : DropCreateDatabaseAlways<DatabaseContext>
    {
        public DatabaseInitializer(DatabaseContext databaseContext)
        {
            this.InitializeDatabase(databaseContext);
        }

        protected override void Seed(DatabaseContext context)
        {
            var customers = new List<Customer>
            {
                new Customer{
                    CustomerId = 123456,
                    CustomerName = "Firstname Lastname",
                    CustomerEmail = "user@domain.com",
                    MobileNo = 0123456789,
                    TransactionIds = "1295"
                },
                new Customer{
                    CustomerId = 123456,
                    CustomerName = "James Hetfield",
                    CustomerEmail = "user3@domain.com",
                    MobileNo = 1029384756,
                    TransactionIds = "550,500"
                },
                new Customer{
                    CustomerId = 198475,
                    CustomerName = "Peter Andersson",
                    CustomerEmail = "user2@domain.com",
                    MobileNo = 9876543210,
                    TransactionIds = string.Empty
                }
            };

            customers.ForEach(x => context.Customers.Add(x));
            context.SaveChanges();

            var transactions = new List<Transaction>
            {
                new Transaction()
                {
                    TransactionId = 1295,
                    Amount = 199.90,
                    CurrencyCode = "SEK",
                    TransactionDateTime = DateTime.Now,
                    Status = Constants.TransactionStatus.Success
                },
                new Transaction()
                {
                    TransactionId = 500,
                    Amount = 699.90,
                    CurrencyCode = "SEK",
                    TransactionDateTime = DateTime.Now.AddDays(-30),
                    Status = Constants.TransactionStatus.Failed
                },
                new Transaction()
                {
                    TransactionId = 550,
                    Amount = 699.90,
                    CurrencyCode = "SEK",
                    TransactionDateTime = DateTime.Now.AddDays(-30),
                    Status = Constants.TransactionStatus.Failed
                }
            };

            transactions.ForEach(x => context.Transactions.Add(x));
            context.SaveChanges();
        }
    }
}