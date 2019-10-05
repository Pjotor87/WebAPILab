using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebAPILab.Controllers
{
    public interface IHomeController
    {
        Task<JsonResult> GetCustomerAsync(int customerId, string email);
        ActionResult Index();
        ActionResult RedirectToSwagger();
    }
}