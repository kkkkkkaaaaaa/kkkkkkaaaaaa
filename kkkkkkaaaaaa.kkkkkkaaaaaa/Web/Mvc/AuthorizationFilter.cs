using System.Web;
using System.Web.Mvc;

namespace kkkkkkaaaaaa.Web.Mvc
{
    public class AuthorizationFilter : IAuthorizationFilter
    {
        /// <summary>
        /// 承認が必要なときに呼び出されます。
        /// </summary>
        /// <param name="filterContext">フィルター コンテキスト。</param>
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            // 
        }
    }
}