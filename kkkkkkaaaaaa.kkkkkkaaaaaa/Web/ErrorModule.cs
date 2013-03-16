using System;
using System.Web;
using System.Web.Routing;

namespace kkkkkkaaaaaa.Web
{
    public class ErrorModule : KandaHttpModule
    {
        /// <summary>
        /// モジュールを初期化し、要求を処理できるように準備します。
        /// </summary>
        /// <param name="context">ASP.NET アプリケーション内のすべてのアプリケーション オブジェクトに共通のメソッド、プロパティ、およびイベントへのアクセスを提供する <see cref="T:System.Web.HttpApplication"/>。</param>
        public override void Init(HttpApplication context)
        {
            context.Error += this.context_Error;
        }

        #region Private members...

        /// <summary>
        /// 
        /// </summary>
        private void context_Error(object sender, EventArgs e)
        {
            var context = ((HttpApplication) sender);
            context.Response.Redirect(@"~/Error", true);

        }

        #endregion
    }
}