using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using kkkkkkaaaaaa.DataTransferObjects;

namespace kkkkkkaaaaaa.Web.Mvc.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class SignInController : KandaController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewName"></param>
        /// <returns></returns>
        [HttpGet()]
        public override ActionResult Default(string viewName = null)
        {
            return this.View(@"SignIn");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost()]
        public ActionResult SignIn(MembershipEntity model)
        {
            if (!this.TryValidateModel(model)) { this.View(@"SignIn", model); }
            else if (!Membership.ValidateUser(model.Name, model.Password[0])) { return this.View(@"SignIn", model); }

            var user = Membership.GetUser(model.Name);
            var id = (long)user.ProviderUserKey;

            FormsAuthentication.RedirectFromLoginPage(id.ToString(CultureInfo.InvariantCulture), true);

            return new EmptyResult();
        }
    }
}
