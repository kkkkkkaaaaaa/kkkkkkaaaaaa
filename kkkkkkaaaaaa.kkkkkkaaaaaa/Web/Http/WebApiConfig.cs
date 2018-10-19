using System.Web.Http;

namespace kkkkkkaaaaaa.Web.Http
{
    public static class WebApiConfig
    {
        /// <summary>
        /// URI ルーティングの方法を構成および設定します。
        /// </summary>
        public static void Register(HttpConfiguration config)
        {
            // 属性ルーティング
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(@"Default", @"");

            // アクションメソッドは規約に従う
            config.Routes.MapHttpRoute(
                name: "WebApi1",
                routeTemplate: "{controller}/{id:int}",
                defaults: new { id = RouteParameter.Optional }
            );

            // アクションメソッドも指定する
            config.Routes.MapHttpRoute(
                name: "WebApi2",
                routeTemplate: "{controller}/{action}/{id:int}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}