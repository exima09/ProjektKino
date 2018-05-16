using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProjektKinoo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Repertuar",
                url: "Repertuar",
                defaults: new { controller = "Filmy", action = "Repertuar", id = UrlParameter.Optional },
                constraints: new { controller = "Filmy", action = "Repertuar" }
            );
            routes.MapRoute(
                name: "Home",
                url: "{action}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                constraints: new {controller="Home"}
            );
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
