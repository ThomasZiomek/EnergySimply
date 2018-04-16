using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EnergySimplyMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /* TODO: Not working!
            routes.MapRoute(
                name: "Plan",
                url: "Plan/{*pathinfo}",
                defaults: new { controller = "Home", action = "Plan" });
            */

            routes.MapRoute(
                name: "Contact",
                url: "Contact/{*pathinfo}",
                defaults: new { controller = "Home", action = "Contact" });

            routes.MapRoute(
                name: "About",
                url: "About/{*pathinfo}",
                defaults: new { controller = "Home", action = "About" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
