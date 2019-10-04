using System.Threading.Tasks;
using System.Web.Mvc;
using Common.Helpers;
using DAL;
using WebAPILab.Models;

namespace WebAPILab.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new HomeViewModel(new DatabaseContext()));
        }

        [HttpGet]
        public ActionResult RedirectToSwagger()
        {
            return Redirect("/swagger/ui/index");
        }

        [HttpGet]
        public async Task<JsonResult> GetCustomerAsync(int customerId, string email)
        {
            string response = string.Empty;
            if (ValidationHelper.IsValidIntegerForId(customerId))
            {
                if (ValidationHelper.IsValidEmail(email))
                    response = await new InquiryController().GetCustomerResponse(customerId, email).Content.ReadAsStringAsync();
                else
                    response = await new InquiryController().GetCustomerResponseById(customerId).Content.ReadAsStringAsync();
            }
            else if (ValidationHelper.IsValidEmail(email))
                response = await new InquiryController().GetCustomerResponseByEmail(email).Content.ReadAsStringAsync();
            
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}