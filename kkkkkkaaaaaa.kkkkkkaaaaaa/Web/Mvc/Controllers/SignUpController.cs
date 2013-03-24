using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using kkkkkkaaaaaa.DataTransferObjects;

namespace kkkkkkaaaaaa.Web.Mvc.Controllers
{
    public class SignUpController : KandaController
    {
        public override ActionResult Default(string viewName = null)
        {
            return this.View(@"SignUp");
        }


        [HttpPost()]
        public ActionResult SignUp(MembershipEntity entity)
        {
            var status = MembershipCreateStatus.ProviderError;
            var user = Membership.CreateUser(entity.Name, entity.Password[0], entity.Email, null, null, true, null, out status);
            if (status != MembershipCreateStatus.Success) { return this.View(@"SignUp", entity); }

            var name = ((long)user.ProviderUserKey).ToString(CultureInfo.InvariantCulture);

            FormsAuthentication.RedirectFromLoginPage(name, true);

            return new EmptyResult();
        }
    }
}