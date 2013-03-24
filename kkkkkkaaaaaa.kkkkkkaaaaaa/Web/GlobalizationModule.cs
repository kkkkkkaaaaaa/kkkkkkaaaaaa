using System;
using System.Globalization;
using System.Threading;
using System.Web;

namespace kkkkkkaaaaaa.Web
{
    /// <summary>
    /// 
    /// </summary>
    public class GlobalizationModule : KandaHttpModule
    {
        /// <summary>
        /// モジュールを初期化し、要求を処理できるように準備します。
        /// </summary>
        /// <param name="context">
        /// ASP.NET アプリケーション内のすべてのアプリケーションオブジェクトに共通のメソッド、プロパティ、およびイベントへのアクセスを提供する <see cref="T:System.Web.HttpApplication"/>。
        /// </param>
        public override void Init(HttpApplication context)
        {
            context.BeginRequest += this.context_BeginRequest;
            context.AcquireRequestState += this.context_AcquireRequestState;
        }

        #region Private members...

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void context_BeginRequest(object sender, EventArgs e)
        {
            var context = (HttpApplication)sender;

            var culture = CultureInfo.InvariantCulture;
            /*
            if (context.Request.UserLanguages == null) { }
            else if (0 < context.Request.UserLanguages.Length)
            {
                culture = CultureInfo.GetCultureInfo(context.Request.UserLanguages[0]);
            }
            else if (0 < context.Request.Cookies.Count)
            {
                var lang = context.Request.Cookies.Get(@"lang");
            }
            
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            */
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void context_AcquireRequestState(object sender, EventArgs e)
        {
            var context = (HttpApplication)sender;

            var culture = CultureInfo.InvariantCulture;

            //Thread.CurrentThread.CurrentCulture = culture;
            //Thread.CurrentThread.CurrentUICulture = culture;
        }

        #endregion
    }
}