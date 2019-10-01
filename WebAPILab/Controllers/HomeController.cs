using System;
using System.Collections.Generic;
using System.Linq;
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

        [ValidateAntiForgeryToken]
        [HttpPost]
        public JsonResult GetCustomer(int customerId, string email)
        {
            Customer customer = null;

            if (customerId > 0)
            {
                if (!string.IsNullOrEmpty(email))
                    customer = new InquiryController().GetCustomer(customerId, email);
                else
                    customer = new InquiryController().GetCustomer(customerId);
            }
            else if (!string.IsNullOrEmpty(email))
                customer = new InquiryController().GetCustomer(email);
            else
                return Json(new { Error = "Bad arguments" });    

            return Json(customer);
        }
    }
}