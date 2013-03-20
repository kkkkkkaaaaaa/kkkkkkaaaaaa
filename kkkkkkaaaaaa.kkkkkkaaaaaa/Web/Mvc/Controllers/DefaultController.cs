using System.Web.Mvc;

namespace kkkkkkaaaaaa.Web.Mvc.Controllers
{
    public class DefaultController : KandaController
    {
        public override ActionResult Default()
        {
            return this.View();
        }

        public ActionResult SignIn()
        {
            // SignIn.cshtml
            this.Response.RedirectToRoute(@"DefaultSignIn", @"SignIn");

            return new EmptyResult();
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