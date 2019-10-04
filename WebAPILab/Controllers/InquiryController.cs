using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using DAL;
using Common.Models;

namespace WebAPILab.Controllers
{
    public class InquiryController : ApiController
    {
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

            IDatabaseContext databaseContext = DALFactory.CreateDatabaseContext();

            if (customerId <= 0 && string.IsNullOrEmpty(email))
            {
                response = new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent("No inquiry criteria") };
            }
            else if (customerId <= 0)
            {
                ICustomer searchResult = databaseContext.Customers.Where(x => x.CustomerEmail == email).FirstOrDefault();
                if (searchResult == null)
                    response = new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent("Invalid Email") };
                else
                {
                    PopulateSearchResultWithLatestTransactions(databaseContext, searchResult);
                    response = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(JsonConvert.SerializeObject(searchResult), Encoding.UTF8, "application/json") };
                }
            }
            else if (string.IsNullOrEmpty(email))
            {
                ICustomer searchResult = databaseContext.Customers.Where(x => x.CustomerId == customerId).FirstOrDefault();
                if (searchResult == null)
                    response = new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent("Invalid Customer ID") };
                else
                {
                    PopulateSearchResultWithLatestTransactions(databaseContext, searchResult);
                    response = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(JsonConvert.SerializeObject(searchResult), Encoding.UTF8, "application/json") };
                }
            }
            else
            {
                ICustomer searchResult = databaseContext.Customers.ToList().Where(x => x.CustomerId == customerId && x.CustomerEmail == email).FirstOrDefault();
                if (searchResult == null)
                    response = new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent("Not found") };
                else
                {
                    PopulateSearchResultWithLatestTransactions(databaseContext, searchResult);
                    response = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(JsonConvert.SerializeObject(searchResult), Encoding.UTF8, "application/json") };
                }
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