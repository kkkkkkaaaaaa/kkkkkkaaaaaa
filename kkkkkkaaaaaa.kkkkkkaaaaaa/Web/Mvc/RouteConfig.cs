using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace kkkkkkaaaaaa.Web.Mvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(@"Index0", @"", new { controller = @"Index", action = @"Index", id = UrlParameter.Optional });
            routes.MapRoute(@"Index1", @"Index", new { controller = @"Home", action = @"Home", id = UrlParameter.Optional });

            routes.MapRoute(@"Error", @"Error", new { controller = @"Stub", action="Error", });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}