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
        [TestInitialize]
        public void MyTestMethod()
        {
            new DatabaseInitializer(new DatabaseContext());
        }

        [TestMethod]
        public void CanGetCustomerById()
        {
            // Arrange
            InquiryController controller = new InquiryController();
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
    }
}
