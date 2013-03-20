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
            //routes.RouteExistingFiles = false;

            // 無視
            routes.IgnoreRoute(@"{resource}.axd/{*pathInfo}");

            // favicon.ico

            //routes.Ignore(@"~/favicon.ico");

            // css
            // routes.Ignore(@"css/*");

            // js
            // routes.Ignore(@"js/*");

            // img
            //routes.Ignore(@"img/*");

            // 共通
            routes.MapRoute(@"Default", @"", new { controller = @"Default", action = @"Default", });
            routes.MapRoute(@"DefaultDefault", @"default", new { controller = @"Default", action = @"Default", });
            routes.MapRoute(@"DefaultError", @"error", new { controller = @"Default", action = "Error", });
            routes.MapRoute(@"DefaultHttpStatus", @"status", new { controller = @"Default", action = "Status", status = 404, });

            // 認証
            routes.MapRoute(@"DefaultSignIn", @"signin", new { controller = @"Membership", action = @"Default", });

            /*
            routes.MapRoute(@"DefaultSignIn", @"signin", new { controller = @"Membership", action = @"DoNothing", });
            routes.MapRoute(@"DefaultSignUp", @"signup", new { controller = @"Membership", action = @"DoNothing", });
            routes.MapRoute(@"DefaultSignOut", @"signout", new { controller = @"Membership", action = @"DoNothing", });
            routes.MapRoute(@"DefaultMembership", @"membership", new { controller = @"Membership", action = @"Membership", });

            // Memberships
            routes.MapRoute(@"Memberships", @"memberships", new { controller = @"Membership", action = @"Get", page = UrlParameter.Optional });
            routes.MapRoute(@"MembershipsList", @"memberships/list", new { controller = @"Get", action = @"List", });
            routes.MapRoute(@"MembershipsMembership", @"memberships/{id}", new { controller = @"Membership", action = @"Find", id = 0, });

            // Users

            // Roles

            // Authorizations

            // Web API
            */

            // それ以外
            routes.MapRoute(@"ControllerActionID", @"{controller}/{action}/{id}", new { controller = @"Default", action = @"Default", id = UrlParameter.Optional });

            /*
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Default", action = "Default", id = UrlParameter.Optional }
            );
            */
        }
    }
}