using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using DAL;
using Common.Models;
using Common.Helpers;

namespace WebAPILab.Controllers
{
    public class InquiryController : ApiController
    {
        #region HttpResponse
        public HttpResponseMessage GetCustomerResponseById(int customerId)
        {
            if (!ValidationHelper.IsValidIntegerForId(customerId))
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent("Invalid Customer ID") };

            HttpResponseMessage response = null;
            IDatabaseContext databaseContext = DALFactory.CreateDatabaseContext();
            ICustomer searchResult = databaseContext.Customers.Where(x => x.CustomerId == customerId).FirstOrDefault();
            if (searchResult == null)
                response = new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent("Not found") };
            else
            {
                PopulateSearchResultWithLatestTransactions(databaseContext, searchResult);
                response = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(JsonConvert.SerializeObject(searchResult), Encoding.UTF8, "application/json") };
            }
            return response;
        }

        public HttpResponseMessage GetCustomerResponseByEmail(string email)
        {
            if (!ValidationHelper.IsValidEmail(email))
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent("Invalid Email") };

            HttpResponseMessage response = null;
            IDatabaseContext databaseContext = DALFactory.CreateDatabaseContext();
            ICustomer searchResult = databaseContext.Customers.Where(x => x.CustomerEmail == email).FirstOrDefault();
            if (searchResult == null)
                response = new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent("Not found") };
            else
            {
                PopulateSearchResultWithLatestTransactions(databaseContext, searchResult);
                response = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(JsonConvert.SerializeObject(searchResult), Encoding.UTF8, "application/json") };
            }
            return response;
        }

        public HttpResponseMessage GetCustomerResponse(int customerId, string email)
        {
            if (!ValidationHelper.IsValidIntegerForId(customerId) && !ValidationHelper.IsValidEmail(email))
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent("No inquiry criteria") };

            HttpResponseMessage response = null;
            IDatabaseContext databaseContext = DALFactory.CreateDatabaseContext();
            ICustomer searchResult = databaseContext.Customers.ToList().Where(x => x.CustomerId == customerId && x.CustomerEmail == email).FirstOrDefault();
            if (searchResult == null)
                response = new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent("Not found") };
            else
            {
                PopulateSearchResultWithLatestTransactions(databaseContext, searchResult);
                response = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(JsonConvert.SerializeObject(searchResult), Encoding.UTF8, "application/json") };
            }
            return response;
        }

        private static void PopulateSearchResultWithLatestTransactions(IDatabaseContext databaseContext, ICustomer searchResult, int take = 5)
        {
            searchResult.PopulateTransactions(databaseContext.Transactions.ToList());
            searchResult.SetMostRecentTransactions(take);
        }
        #endregion
    }
}