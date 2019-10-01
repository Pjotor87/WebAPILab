using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPILab;
using WebAPILab.Controllers;
using WebAPILab.DAL;
using WebAPILab.Models;

namespace WebAPILab.Tests.Controllers
{
    [TestClass]
    public class InquiryControllerTest
    {
        static HttpClient client = new HttpClient();
        static DateTime testDate = DateTime.Now;
        static Customer testCustomer = new Customer() { CustomerId = 9999, CustomerEmail = "tests@test.com", CustomerName = "Mr Customer", MobileNo = 1111122222, TransactionIds = "999,888" };
        static Transaction testTransaction1 = new Transaction() { CurrencyCode = "SEK", TransactionDateTime = testDate, Amount = 999.50, Status = Constants.Enum.TransactionStatus.Success, TransactionId = 999 };
        static Transaction testTransaction2 = new Transaction() { CurrencyCode = "GBP", TransactionDateTime = testDate, Amount = 48.20, Status = Constants.Enum.TransactionStatus.Success, TransactionId = 888 };

        [TestInitialize]
        public void InitializeTests()
        {
            DatabaseContext context = new DatabaseContext();
            new DatabaseInitializer(context);
            context.Customers.Add(testCustomer);
            context.SaveChanges();
            context.Transactions.Add(testTransaction1);
            context.Transactions.Add(testTransaction2);
            context.SaveChanges();
        }

        [TestMethod]
        public void CanGetCustomerById()
        {
            // Arrange
            InquiryController controller = new InquiryController();
            //controller.GetCustomerResponse();
            int customerId = 123456;

            // Act
            Customer result = controller.GetCustomer(customerId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(customerId, result.CustomerId);
            Assert.AreEqual("Firstname Lastname", result.CustomerId);
            Assert.AreEqual("user @domain.com", result.CustomerId);
            Assert.AreEqual("0123456789", result.CustomerId);
        }

        [TestMethod]
        public void CanGetCustomerByEmail()
        {
            // Arrange
            ValuesController controller = new ValuesController();
            string email = "user@domain.com";

            // Act
            Customer result = controller.GetCustomer(email);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(123456, result.CustomerId);
            Assert.AreEqual(email, result.CustomerId);
            Assert.AreEqual("user @domain.com", result.CustomerId);
            Assert.AreEqual("0123456789", result.CustomerId);
            Assert.AreEqual(new Transaction(), result.RecentTransactions);
        }

        [TestMethod]
        public void CanGetCustomerByIdAndEmail()
        {
            // Arrange
            ValuesController controller = new ValuesController();
            int customerId = 123456;
            string email = "user@domain.com";

            // Act
            Customer result = controller.GetCustomer(customerId, email);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result);
            Assert.AreEqual(customerId, result.CustomerId);
            Assert.AreEqual(email, result.CustomerId);
            Assert.AreEqual("user @domain.com", result.CustomerId);
            Assert.AreEqual("0123456789", result.CustomerId);
            Assert.AreEqual(new Transaction(), result.RecentTransactions);
        }

        [TestCleanup]
        public void TearDown()
        {
            DatabaseContext context = new DatabaseContext();
            context.Customers.Remove(testCustomer);
            context.SaveChanges();
            context.Transactions.Remove(testTransaction1);
            context.Transactions.Remove(testTransaction2);
            context.SaveChanges();
        }
    }
}
