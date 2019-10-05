using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DAL.Contexts;
using DAL.Initializers;
using DAL.Seed;

namespace WebAPILab
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ContainerConfig.Configure();

#if DEBUG
            var dbInitializer = new TestDatabaseInitializer(new CustomerSeed(), new TransactionSeed());
            dbInitializer.InitializeDatabase(new DatabaseContext());
#endif
        }
    }
}