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

            routes.MapRoute(@"Default", @"", new {controller = @"Default", action = @"Default"});
            routes.MapRoute(@"Default2", @"Default", new {controller = @"Default", action = @"Default"});
            routes.MapRoute(@"Default3", @"Default/Default", new {controller = @"Default", action = @"Default"});

            /*
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            */
        }
    }
}