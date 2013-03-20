using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using kkkkkkaaaaaa.DataTransferObjects;
using kkkkkkaaaaaa.DomainModels;
using kkkkkkaaaaaa.Web.Security;
using Membership = kkkkkkaaaaaa.DomainModels.Membership;
using Security = System.Web.Security;

namespace kkkkkkaaaaaa.Web.Mvc.Controllers
{
    public class MembershipController : KandaController
    {
        public override ActionResult Default()
        {
            return this.View(@"SignIn");
        }

        public ActionResult Find()
        {
            if (this.User.Identity.IsAuthenticated)
            {

            }
            else
            {
                // Anonymous
                FormsAuthentication.SetAuthCookie(Memberships.ANONYMOUS.ToString(CultureInfo.InvariantCulture), true);
            }

            var entity = default (MembershipEntity);
            if (this.User.Identity.IsAuthenticated)
            {
                var membership = new Membership(new MembershipEntity { ID = long.Parse(this.User.Identity.Name), });
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

        public ActionResult SignIn(string name, string password)
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

        public ActionResult SignUp()
        {
            return this.View();
        }
    }
}