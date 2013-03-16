using System.Web;

namespace kkkkkkaaaaaa.Web
{
    public abstract class KandaHttpModule : IHttpModule
    {
        /// <summary>
        /// モジュールを初期化し、要求を処理できるように準備します。
        /// </summary>
        /// <param name="context">ASP.NET アプリケーション内のすべてのアプリケーション オブジェクトに共通のメソッド、プロパティ、およびイベントへのアクセスを提供する <see cref="T:System.Web.HttpApplication"/>。</param>
        public abstract void Init(HttpApplication context);

        /// <summary>
        /// <see cref="T:System.Web.IHttpModule"/> を実装するモジュールで使用されるリソース (メモリを除く) を解放します。
        /// </summary>
        public virtual void Dispose()
        {
            this.DoNothing();
        }

        #region Provated members...

        /// <summary>
        /// 何もしません。
        /// </summary>
        protected void DoNothing()
        {
            // 何もしない
        }

        #endregion
    }
}