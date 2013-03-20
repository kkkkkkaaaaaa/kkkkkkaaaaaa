using System;
using System.Globalization;
using System.Web;
using System.Web.Security;
using kkkkkkaaaaaa.DomainModels;

namespace kkkkkkaaaaaa.Web
{
    /// <summary>
    /// 
    /// </summary>
    public class PostAuthenticateRequestModule : KandaHttpModule
    {
        /// <summary>
        /// モジュールを初期化し、要求を処理できるように準備します。
        /// </summary>
        /// <param name="context">
        /// ASP.NET アプリケーション内のすべてのアプリケーション オブジェクトに共通のメソッド、プロパティ、およびイベントへのアクセスを提供する <see cref="T:System.Web.HttpApplication"/>。
        /// </param>
        public override void Init(HttpApplication context)
        {
            context.PostAuthenticateRequest += this.context_PostAuthenticateRequest;
        }

        #region Private members...

        /// <summary>
        /// PostAuthenticateRequest イベントハンドラー。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void context_PostAuthenticateRequest(object sender, EventArgs eventArgs)
        {
            var context = ((HttpApplication)sender);
            if (context.User.Identity.IsAuthenticated) { return; }

            FormsAuthentication.SetAuthCookie(Memberships.ANONYMOUS.ToString(CultureInfo.InvariantCulture), true);
        }

        #endregion
    }
}