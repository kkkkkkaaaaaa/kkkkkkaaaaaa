using System.Web.Http;
using System.Web.Routing;

namespace kkkkkkaaaaaa.Web.Http
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API ルート
            // 属性ルーティング
            config.MapHttpAttributeRoutes();


            // ルートマッピング
            config.Routes.MapHttpRoute(@"Default", @"");

            config.Routes.MapHttpRoute(
                name: "WebApi1",
                routeTemplate: "{controller}/{id:int}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "WebApi2",
                routeTemplate: "{controller}/{action}/{id:int}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}