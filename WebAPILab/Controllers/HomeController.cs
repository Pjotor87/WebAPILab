using System.Threading.Tasks;
using System.Web.Mvc;
using WebAPILab.DAL;
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
        public async Task<JsonResult> GetCustomerAsync(int customerId, string email)
        {
            string response = await new InquiryController().GetCustomerResponse(customerId, email).Content.ReadAsStringAsync();
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult RedirectToSwagger()
        {
            return Redirect("/swagger/ui/index");
        }
    }
}