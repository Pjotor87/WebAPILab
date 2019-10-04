using System.Collections.Generic;
using Common.Models;

namespace DAL.Seed
{
    public class CustomerSeed : ISeed<Customer>
    {
        public List<Customer> GetSeed()
        {
            return new List<Customer>
            {
                new Customer{
                    CustomerId = 123456,
                    CustomerName = "Firstname Lastname",
                    CustomerEmail = "user@domain.com",
                    MobileNo = 0123456789,
                    TransactionIds = "1295"
                },
                new Customer{
                    CustomerId = 12456,
                    CustomerName = "James Hetfield",
                    CustomerEmail = "user3@domain.com",
                    MobileNo = 1029384756,
                    TransactionIds = "550,500,1,2,3,4,5,6"
                },
                new Customer{
                    CustomerId = 198475,
                    CustomerName = "Peter Andersson",
                    CustomerEmail = "user2@domain.com",
                    MobileNo = 9876543210,
                    TransactionIds = string.Empty
                }
            };
        }
    }
}