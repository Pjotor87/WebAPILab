using System;
using System.Net.Http;
using System.Threading.Tasks;
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
        static DatabaseContext databaseContext = new DatabaseContext();
        static DateTime testDate = DateTime.Now;
        static Customer testCustomer = new Customer() { CustomerId = 9999, CustomerEmail = "tests@test.com", CustomerName = "Mr Customer", MobileNo = 1111122222, TransactionIds = "999,888" };
        static Transaction testTransaction1 = new Transaction() { CurrencyCode = "SEK", TransactionDateTime = testDate, Amount = 999.50, Status = Constants.Enum.TransactionStatus.Success, TransactionId = 999 };
        static Transaction testTransaction2 = new Transaction() { CurrencyCode = "GBP", TransactionDateTime = testDate, Amount = 48.20, Status = Constants.Enum.TransactionStatus.Success, TransactionId = 888 };

        static bool testsInitialized = false;
        [TestInitialize]
        public void InitializeTests()
        {
            if (!testsInitialized)
            {
                new DatabaseInitializer(databaseContext);
                testsInitialized = true;
            }
        }

        [TestMethod]
        public async Task CanGetCustomerByIdAsync()
        {
            // Arrange
            AddTestdataToDatabase();
            InquiryController controller = new InquiryController();

            // Act
            HttpResponseMessage response = controller.GetCustomerResponse(testCustomer.CustomerId);
            Customer result = JsonHelper.DeserializeJson<Customer>(await response.Content.ReadAsStringAsync());

            // Assert
            AssertTestCustomer(result);
        }

        [TestMethod]
        public async Task CanGetCustomerByEmail()
        {
            // Arrange
            AddTestdataToDatabase();
            InquiryController controller = new InquiryController();

            // Act
            HttpResponseMessage response = controller.GetCustomerResponse(testCustomer.CustomerEmail);
            Customer result = JsonHelper.DeserializeJson<Customer>(await response.Content.ReadAsStringAsync());

            // Assert
            AssertTestCustomer(result);
        }

        [TestMethod]
        public async Task CanGetCustomerByIdAndEmail()
        {
            // Arrange
            AddTestdataToDatabase();
            InquiryController controller = new InquiryController();

            // Act
            HttpResponseMessage response = controller.GetCustomerResponse(testCustomer.CustomerId, testCustomer.CustomerEmail);
            Customer result = JsonHelper.DeserializeJson<Customer>(await response.Content.ReadAsStringAsync());

            // Assert
            AssertTestCustomer(result);
        }

        [TestMethod]
        public async Task CanGetCustomerTransactions()
        {
            Assert.Fail();

            // Arrange
            AddTestdataToDatabase();
            InquiryController controller = new InquiryController();

            // Act
            HttpResponseMessage response = controller.GetCustomerResponse(testCustomer.CustomerId, testCustomer.CustomerEmail);
            Customer result = JsonHelper.DeserializeJson<Customer>(await response.Content.ReadAsStringAsync());

            // Assert
            AssertTestCustomer(result);
        }

        private void AssertTestCustomer(Customer result)
        {
            Assert.IsNotNull(result);
            Assert.AreEqual(testCustomer.CustomerId, result.CustomerId);
            Assert.AreEqual(testCustomer.CustomerEmail, result.CustomerEmail);
            Assert.AreEqual(testCustomer.CustomerName, result.CustomerName);
            Assert.AreEqual(testCustomer.MobileNo, result.MobileNo);
            Assert.AreEqual(testCustomer.TransactionIds, result.TransactionIds);
        }

        [TestCleanup]
        public void TearDown()
        {
            RemoveTestdataFromDatabase();
        }

        private static void AddTestdataToDatabase()
        {
            databaseContext.Customers.Add(testCustomer);
            databaseContext.SaveChanges();
            databaseContext.Transactions.Add(testTransaction1);
            databaseContext.Transactions.Add(testTransaction2);
            databaseContext.SaveChanges();
        }

        private static void RemoveTestdataFromDatabase()
        {
            databaseContext.Customers.Remove(testCustomer);
            databaseContext.SaveChanges();
            databaseContext.Transactions.Remove(testTransaction1);
            databaseContext.Transactions.Remove(testTransaction2);
            databaseContext.SaveChanges();
        }
    }
}
