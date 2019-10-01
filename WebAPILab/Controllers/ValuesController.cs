using System.Web.Http;
using WebAPILab.Models;

namespace WebAPILab.Controllers
{
    public class ValuesController : ApiController
    {
        public Customer GetCustomer(int customerId)
        {
            return new Customer();
        }

        public Customer GetCustomer(string email)
        {
            return new Customer();
        }

        public Customer GetCustomer(int customerId, string email)
        {
            return new Customer();
        }
    }
}
