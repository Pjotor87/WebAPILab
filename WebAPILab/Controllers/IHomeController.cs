using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebAPILab.Controllers
{
    public interface IHomeController
    {
        ActionResult Index();
        ActionResult RedirectToSwagger();
    }
}