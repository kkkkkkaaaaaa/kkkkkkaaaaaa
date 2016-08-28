using System.Web.Http;

namespace kkkkkkaaaaaa.Web.Http.Controllers
{
    /// <summary>
    /// このコントローラークラスのアクションメソッドのルートの親 URI パスには Membership/ が付与されます。
    /// </summary>
    [RoutePrefix(@"Membership")]
    public class MembershipController : ApiController
    {
        /// <summary>
        /// 規約により GetXxxx は GET リクエストを処理する。
        /// </summary>
        /// <param name="id"></param>
        public string GetByConvention(int id = 1)
        {
            // GetByRouteMapping() によりこのメソッドは呼ばれない

            return @"GetByConvention()";
        }

        /// <summary>
        /// kkkkkkaaaaaa.Web.WebApiConfig.Register() により アクションを明示。
        /// </summary>
        /// <param name="id">仮のパラメーター。</param>
        /// <returns></returns>
        public string GetByRouteMapping(int id = 1)
        {
            return @"GetByRouteMapping() called.";
        }

        /// <summary>
        /// ルートをルートマッピングではなくアクションメソッドの属性として指定して。
        /// </summary>
        /// <param name="id">仮のパラメーター。</param>
        /// <returns></returns>
        [Route(@"m/c/{id:int}")]
        public string GetByRouteAttribute(int id)
        {
            return @"GetByRouteAttribute() called.";
        }

        [HttpGet()]
        [Route(@"get/{id:int}")]
        public string CetByRouteAttribute(int id = 1)
        {
            return @"CetByRouteAttribute() called.";
        }
    }
}
