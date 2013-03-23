using System.Web.Mvc;

namespace kkkkkkaaaaaa.Web.Mvc.Controllers
{
    public class DefaultController : KandaController
    {
        public override ActionResult Default(string viewName = null)
        {
            return this.View(viewName);
        }

        public ActionResult SignIn()
        {
            return this.RedirectToRoute(@"DefaultSignIn", @"SignIn");
        }

        public ActionResult SignUp()
        {
            return this.RedirectToRoute(@"DefaultSignUp");
        }

        public ActionResult Error()
        {
            return this.View(@"Error");
        }

        public ActionResult Status()
        {
            return this.View(@"Status");
        }
    }
}