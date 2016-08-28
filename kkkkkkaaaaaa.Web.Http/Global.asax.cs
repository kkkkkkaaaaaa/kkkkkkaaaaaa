using System;
using System.Web;
using System.Web.Http;

namespace kkkkkkaaaaaa.Web.Http
{
    /// <summary>
    /// Global.asax。
    /// </summary>
    public class Global : HttpApplication
    {
        /// <summary>
        /// アプリケーション最初のリクエスト。
        /// </summary>
        protected void Application_Start(object sender, EventArgs e)
        {
            // Web API を構成する
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}