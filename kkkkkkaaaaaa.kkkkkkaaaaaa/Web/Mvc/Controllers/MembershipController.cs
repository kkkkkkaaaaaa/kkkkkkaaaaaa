using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using kkkkkkaaaaaa.DataTransferObjects;
using kkkkkkaaaaaa.Web.Security;

namespace kkkkkkaaaaaa.Web.Mvc.Controllers
{
    public class MembershipController : KandaController
    {
        [HttpGet()]
        public override ActionResult Default(string viewName = null)
        {
            return this.View(viewName);
        }

        public ActionResult Find()
        {
            if (this.User.Identity.IsAuthenticated)
            {

            }
            else
            {
                // Anonymous
                FormsAuthentication.SetAuthCookie(DomainModels.Memberships.ANONYMOUS.ToString(CultureInfo.InvariantCulture), true);
            }

            var entity = default (MembershipEntity);
            if (this.User.Identity.IsAuthenticated)
            {
                var membership = new DomainModels.Membership(new MembershipEntity { ID = long.Parse(this.User.Identity.Name), });
                membership.Found += (_, __) =>
                                        {
                                            entity = __;
                                        };
                membership.Find();
            }
            else
            {
                FormsAuthentication.SignOut();
            }

            return this.View(entity);
        }

        [HttpPost()]
        public ActionResult SignIn(string name, string password) // , bool remember)
        {
            if (System.Web.Security.Membership.ValidateUser(name, password))
            {
                var user = (KandaMembershipUser)System.Web.Security.Membership.GetUser(name);

                FormsAuthentication.RedirectFromLoginPage(user.MembershipID.ToString(CultureInfo.InvariantCulture), true);

                return new EmptyResult();
            }
            else
            {
                // 認証できない
                this.Response.RedirectToRoute(@"DefaultSignIn", @"Default");
            }

            return this.View();
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();

            return this.View();
        }

        [HttpPost()]
        public ActionResult SignUp(MembershipEntity entity)
        {
            var status = MembershipCreateStatus.ProviderError;
            var user = Membership.CreateUser(entity.Name, entity.Password[0], entity.Email, null, null, true, null, out status);
            if (status !=  MembershipCreateStatus.Success) { return this.View(@"SignUp", entity); }

            return this.RedirectToRoute(@"DefaultMembership");
        }

        public ActionResult GetUser()
        {
            return this.View(@"User");
        }
    }
}