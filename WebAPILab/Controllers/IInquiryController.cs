using System.Net.Http;

namespace WebAPILab.Controllers
{
    public interface IInquiryController
    {
        HttpResponseMessage GetCustomerResponse(int customerId, string email);
        HttpResponseMessage GetCustomerResponseByEmail(string email);
        HttpResponseMessage GetCustomerResponseById(int customerId);
    }
}