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

            // DefaultController
            routes.MapRoute(@"Default", @"", new { controller = @"Default", action = @"Default", });
            routes.MapRoute(@"DefaultDefault", @"default", new { controller = @"Default", action = @"Default", });
            routes.MapRoute(@"DefaultError", @"error", new { controller = @"Default", action = @"Error", });
            routes.MapRoute(@"DefaultHttpStatus", @"status", new { controller = @"Default", action = @"Status", status = 404, });

            routes.MapRoute(@"DefaultView", @"view", new { controller = @"Default", action = @"View", });


            // MembershipController
            routes.MapRoute(@"DefaultSignIn", @"signin", new { controller = @"SignIn", action = @"Default", });
            routes.MapRoute(@"DefaultSignUp", @"signup", new { controller = @"SignUp", action = @"Default", });
            routes.MapRoute(@"DefaultSignOut", @"signout", new { controller = @"Membership", action = @"DoNothing", });
            routes.MapRoute(@"DefaultMembership", @"membership", new { controller = @"Membership", action = @"Find", });
            routes.MapRoute(@"DefaultUser", @"user", new { controller = @"Users", action = @"Find" });
            routes.MapRoute(@"DefaultRole", @"role", new { controller = @"Roles", action = @"Find", });
            routes.MapRoute(@"DefaultAuthorization", @"authorization", new { controller = @"Authorizations", action = @"Find", });

            // MembershipsController
            routes.MapRoute(@"MembershipsDefault", @"memberships", new { controller = @"Memberships", action = @"Get", });
            routes.MapRoute(@"MembershipsID", @"memberships/{id}", new { controller = @"Memberships", action = @"Find", id = -1, });

            // Users
            routes.MapRoute(@"UsersDefault", @"users", new { controller = @"Users", action = @"Get", });
            routes.MapRoute(@"UsersID", @"users/{id}", new { controller = @"Users", action = @"Find", id = -1, });

            /*
            // Roles

            // Authorizations

            // Web API
            */

            // それ以外
            routes.MapRoute(@"ControllerAction", @"{controller}/{action}", new { controller = @"Default", action = @"Default", });
            routes.MapRoute(@"ControllerActionID", @"{controller}/{action}/{id}", new { controller = @"Default", action = @"Default", id = UrlParameter.Optional, });

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