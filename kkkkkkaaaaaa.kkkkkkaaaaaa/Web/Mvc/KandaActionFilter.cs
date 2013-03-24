using System.Web.Mvc;

namespace kkkkkkaaaaaa.Web.Mvc
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class KandaActionFilter : IActionFilter
    {
        /// <summary>
        /// アクション メソッドの実行前に呼び出されます。
        /// </summary>
        /// <param name="filterContext">
        /// フィルター コンテキスト。
        /// </param>
        public abstract void OnActionExecuting(ActionExecutingContext filterContext);

        /// <summary>
        /// アクション メソッドの実行後に呼び出されます。
        /// </summary>
        /// <param name="filterContext">
        /// フィルター コンテキスト。
        /// </param>
        public abstract void OnActionExecuted(ActionExecutedContext filterContext);

        #region Protected members...

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