using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPILab.Controllers;
using DAL;
using Common.Helpers;
using Common.Models;

namespace WebAPILab.Tests.Controllers
{
    [TestClass]
    public class InquiryControllerTest
    {
        static HttpClient client = new HttpClient();
        static DatabaseContext databaseContext = new DatabaseContext();
        static DateTime testDate = DateTime.Now;
        static Customer testCustomer = new Customer() { CustomerId = 9999, CustomerEmail = "tests@test.com", CustomerName = "Mr Customer", MobileNo = 1111122222, TransactionIds = "999,888" };
        static Transaction testTransaction1 = new Transaction() { CurrencyCode = "SEK", TransactionDateTime = testDate, Amount = 999.50, Status = Common.Constants.Enum.TransactionStatus.Success, TransactionId = 999 };
        static Transaction testTransaction2 = new Transaction() { CurrencyCode = "GBP", TransactionDateTime = testDate, Amount = 48.20, Status = Common.Constants.Enum.TransactionStatus.Success, TransactionId = 888 };

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
            HttpResponseMessage response = controller.GetCustomerResponseById(testCustomer.CustomerId);
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
            HttpResponseMessage response = controller.GetCustomerResponseByEmail(testCustomer.CustomerEmail);
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
            // Arrange
            AddTestdataToDatabase();
            InquiryController controller = new InquiryController();

            // Act
            HttpResponseMessage response = controller.GetCustomerResponse(testCustomer.CustomerId, testCustomer.CustomerEmail);
            Customer result = JsonHelper.DeserializeJson<Customer>(await response.Content.ReadAsStringAsync());

            // Assert
            AssertTestCustomer(result);
            Assert.AreEqual(2, result.Transactions.Count);
        }

        [TestMethod]
        public async Task NoMatchReturnsNotFoundAsync()
        {
            // Arrange
            AddTestdataToDatabase();
            InquiryController controller = new InquiryController();

            // Act
            HttpResponseMessage response = controller.GetCustomerResponse(500505, "anemail@thatnoone.has");
            string responseContent = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.AreEqual("not found", responseContent.ToLower());
        }

        [TestMethod]
        public async Task BadRequestIsReturnedWhenIdIsNotMatchAsync()
        {
            // Arrange
            AddTestdataToDatabase();
            InquiryController controller = new InquiryController();

            // Act
            HttpResponseMessage response = controller.GetCustomerResponseById(500505);
            string responseContent = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.AreEqual("invalid customer id", responseContent.ToLower());
        }

        [TestMethod]
        public async Task BadRequestIsReturnedWhenEmailIsNotMatchAsync()
        {
            // Arrange
            AddTestdataToDatabase();
            InquiryController controller = new InquiryController();

            // Act
            HttpResponseMessage response = controller.GetCustomerResponseByEmail("anemail@thatnoone.has");
            string responseContent = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.AreEqual("invalid email", responseContent.ToLower());
        }

        [TestMethod]
        public async Task BadRequestIsReturnedForCrazyRequests()
        {
            // Arrange
            AddTestdataToDatabase();
            InquiryController controller = new InquiryController();

            // Act
            HttpResponseMessage response = controller.GetCustomerResponse(100, null);
            string responseContent = await response.Content.ReadAsStringAsync();
            HttpResponseMessage response2 = controller.GetCustomerResponse(-9000, "");
            string responseContent2 = await response.Content.ReadAsStringAsync();
            HttpResponseMessage response3 = controller.GetCustomerResponseByEmail(string.Empty);
            string responseContent3 = await response.Content.ReadAsStringAsync();
            HttpResponseMessage response4 = controller.GetCustomerResponseById(-9000);
            string responseContent4 = await response.Content.ReadAsStringAsync();
            HttpResponseMessage response5 = controller.GetCustomerResponse(int.MaxValue, string.Empty);
            string responseContent5 = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.AreEqual(HttpStatusCode.BadRequest, response2.StatusCode);
            Assert.AreEqual(HttpStatusCode.BadRequest, response3.StatusCode);
            Assert.AreEqual(HttpStatusCode.BadRequest, response4.StatusCode);
            Assert.AreEqual(HttpStatusCode.BadRequest, response5.StatusCode);
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
