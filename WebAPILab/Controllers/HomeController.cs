using System.Web.Mvc;
using DAL.Contexts;
using Services.LoggingService;
using WebAPILab.Models;

namespace WebAPILab.Controllers
{
    public class HomeController : Controller, IHomeController
    {
        private readonly ILogger Logger;
        private readonly IDatabaseContext DbContext;
        private readonly IHomeViewModel ViewModel;

        public HomeController(ILogger logger, IDatabaseContext dbContext, IHomeViewModel viewModel)
        {
            Logger = logger;
            DbContext = dbContext;
            ViewModel = viewModel;
        }

        public ActionResult Index()
        {
            IHomeViewModel homeViewModel = new HomeViewModel(DbContext, Logger);
            return View(homeViewModel);
        }

        [HttpGet]
        public ActionResult RedirectToSwagger()
        {
            return Redirect(Constants.Swagger.RELATIVE_URL);
        }

        //[HttpGet]
        //public async Task<JsonResult> GetCustomerAsync(int customerId, string email)
        //{
        //    string response = string.Empty;
        //    if (ValidationHelper.IsValidIntegerForId(customerId))
        //    {
        //        if (ValidationHelper.IsValidEmail(email))
        //            response = await new InquiryController().GetCustomerResponse(customerId, email).Content.ReadAsStringAsync();
        //        else
        //            response = await new InquiryController().GetCustomerResponseById(customerId).Content.ReadAsStringAsync();
        //    }
        //    else if (ValidationHelper.IsValidEmail(email))
        //        response = await new InquiryController().GetCustomerResponseByEmail(email).Content.ReadAsStringAsync();
            
        //    return Json(response, JsonRequestBehavior.AllowGet);
        //}
    }
}