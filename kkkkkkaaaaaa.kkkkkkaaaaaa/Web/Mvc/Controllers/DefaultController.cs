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
            return this.RedirectToRoute(@"DefaultSignIn");
        }

        public ActionResult SignUp()
        {
            return this.RedirectToRoute(@"DefaultSignUp");
        }

        public ActionResult Error()
        {
            return this.RedirectToRoute(@"DefaultError");
        }

        public ActionResult HttpStatus()
        {
            return this.View(@"HttpStatus");
        }

        [ActionName(@"View")]
        public  ActionResult DefaultView()
        {
            return this.View(@"View");
        }
    }
}