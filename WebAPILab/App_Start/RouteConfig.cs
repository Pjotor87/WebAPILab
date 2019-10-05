using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebAPILab
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            MapRoutesDebug(routes);
            MapRoutesRelease(routes);
        }

        [Conditional("DEBUG")]
        private static void MapRoutesDebug(RouteCollection routes)
        {
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                //defaults: new { controller = "Home", action = "RedirectToSwagger", id = UrlParameter.Optional }
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }

        [Conditional("RELEASE")]
        private static void MapRoutesRelease(RouteCollection routes)
        {
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}