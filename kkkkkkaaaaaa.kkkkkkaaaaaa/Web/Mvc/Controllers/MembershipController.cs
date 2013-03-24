using System.Globalization;
using System.Security.Authentication;
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

        [HttpGet()]
        public ActionResult Find()
        {
            if (!this.User.Identity.IsAuthenticated) { throw new AuthenticationException(@"MembershipController.Find()");}

            if (this.MembershipID == DomainModels.Memberships.ANONYMOUS) { return this.RedirectToRoute(@"DefaultSignIn"); }

            var membership = new DomainModels.Membership(new MembershipEntity
                                    {
                                        ID = this.MembershipID, 
                                    });
            var view = default(ViewResult);
            membership.Found += (sender, entity) => { view = this.View(@"Membership", entity); };
            membership.Find();

            return view;
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return this.RedirectToRoute(@"Default");
        }

        [HttpPost()]
        public ActionResult SignUp(MembershipEntity entity)
        {
            var status = MembershipCreateStatus.ProviderError;
            var user = Membership.CreateUser(entity.Name, entity.Password[0], entity.Email, null, null, true, null, out status);
            if (status !=  MembershipCreateStatus.Success) { return this.View(@"SignUp", entity); }

            var name = ((long)user.ProviderUserKey).ToString(CultureInfo.InvariantCulture);

            FormsAuthentication.RedirectFromLoginPage(name, true);

            return new EmptyResult();
        }

        public ActionResult GetUser()
        {
            return this.View(@"User");
        }
    }
}