using System;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPILab.Controllers;
using WebAPILab.DAL;
using WebAPILab.Helpers;
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

            // Act
            HttpResponseMessage response = controller.GetCustomerResponse(testCustomer.CustomerId);
            Customer result = JsonHelper.DeserializeJson<Customer>(response.Content.ToString());

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(testCustomer.CustomerId, result.CustomerId);
            Assert.AreEqual(testCustomer.CustomerEmail, result.CustomerEmail);
            Assert.AreEqual(testCustomer.CustomerName, result.CustomerName);
            Assert.AreEqual(testCustomer.MobileNo, result.MobileNo);
            Assert.AreEqual(testCustomer.TransactionIds, result.TransactionIds);
        }

        [TestMethod]
        public void CanGetCustomerByEmail()
        {
        }

        [TestMethod]
        public void CanGetCustomerByIdAndEmail()
        {
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
