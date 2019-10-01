using System.Linq;
using System.Web.Http;
using WebAPILab.DAL;
using WebAPILab.Models;

namespace WebAPILab.Controllers
{
    public class ValuesController : ApiController
    {
        public Customer GetCustomer(int customerId)
        {
            return new DatabaseContext().Customers.Where(x => x.CustomerId == customerId).FirstOrDefault();
        }

        public Customer GetCustomer(string email)
        {
            return new DatabaseContext().Customers.Where(x => x.CustomerEmail == email).FirstOrDefault();
        }

        public Customer GetCustomer(int customerId, string email)
        {
            return new DatabaseContext().Customers.ToList().Where(x => x.CustomerId == customerId && x.CustomerEmail == email).FirstOrDefault();
        }
    }
}