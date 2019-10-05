using System.Collections.Generic;
using Models;

namespace DAL.Seed
{
    public class CustomerSeed : ICustomerSeed
    {
        public List<Customer> GetSeed()
        {
            Customer customer1 = new Customer();
            customer1.CustomerId = 123456;
            customer1.CustomerName = "Firstname Lastname";
            customer1.CustomerEmail = "user@domain.com";
            customer1.MobileNo = 0123456789;
            customer1.TransactionIds = "1295";
            Customer customer2 = new Customer();
            customer2.CustomerId = 12456;
            customer2.CustomerName = "James Hetfield";
            customer2.CustomerEmail = "user3@domain.com";
            customer2.MobileNo = 1029384756;
            customer2.TransactionIds = "550,500,1,2,3,4,5,6";
            Customer customer3 = new Customer();
            customer3.CustomerId = 198475;
            customer3.CustomerName = "Peter Andersson";
            customer3.CustomerEmail = "user2@domain.com";
            customer3.MobileNo = 9876543210;
            customer3.TransactionIds = string.Empty;

            return new List<Customer>
            {
                customer1,
                customer2,
                customer3
            };
        }
    }
}