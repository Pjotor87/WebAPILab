using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using WebAPILab.DAL;
using WebAPILab.Models;

namespace WebAPILab.Controllers
{
    public class InquiryController : ApiController
    {
        #region MVC
        public Customer GetCustomerById(int customerId)
        {
            return new DatabaseContext().Customers.Where(x => x.CustomerId == customerId).FirstOrDefault();
        }

        public Customer GetCustomerByEmail(string email)
        {
            return new DatabaseContext().Customers.Where(x => x.CustomerEmail == email).FirstOrDefault();
        }

        public Customer GetCustomer(int customerId, string email)
        {
            return new DatabaseContext().Customers.ToList().Where(x => x.CustomerId == customerId && x.CustomerEmail == email).FirstOrDefault();
        }
        #endregion

        #region HttpResponse
        public HttpResponseMessage GetCustomerResponseById(int customerId)
        {
            return this.GetCustomerResponse(customerId, string.Empty);
        }

        public HttpResponseMessage GetCustomerResponseByEmail(string email)
        {
            return this.GetCustomerResponse(-1, email);
        }

        public HttpResponseMessage GetCustomerResponse(int customerId, string email)
        {
            HttpResponseMessage response = null;

            DatabaseContext databaseContext = new DatabaseContext();

            if (customerId <= 0 && string.IsNullOrEmpty(email))
            {
                response = new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent("No inquiry criteria") };
            }
            else if (customerId <= 0)
            {
                Customer searchResult = databaseContext.Customers.Where(x => x.CustomerEmail == email).FirstOrDefault();
                searchResult.PopulateTransactions(databaseContext.Transactions.ToList());
                searchResult.SetMostRecentTransactions(5);
                if (searchResult == null)
                    response = new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent("Invalid Email") };
                else
                    response = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(JsonConvert.SerializeObject(searchResult), Encoding.UTF8, "application/json") };
            }
            else if (string.IsNullOrEmpty(email))
            {
                Customer searchResult = databaseContext.Customers.Where(x => x.CustomerId == customerId).FirstOrDefault();
                searchResult.PopulateTransactions(databaseContext.Transactions.ToList());
                searchResult.SetMostRecentTransactions(5);
                if (searchResult == null)
                    response = new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent("Invalid Customer ID") };
                else
                    response = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(JsonConvert.SerializeObject(searchResult), Encoding.UTF8, "application/json") };
            }
            else
            {
                Customer searchResult = databaseContext.Customers.ToList().Where(x => x.CustomerId == customerId && x.CustomerEmail == email).FirstOrDefault();
                searchResult.PopulateTransactions(databaseContext.Transactions.ToList());
                searchResult.SetMostRecentTransactions(5);
                if (searchResult == null)
                    response = new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent("Not found") };
                else
                    response = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(JsonConvert.SerializeObject(searchResult), Encoding.UTF8, "application/json") };
            }

            return response;
        }
        #endregion
    }
}