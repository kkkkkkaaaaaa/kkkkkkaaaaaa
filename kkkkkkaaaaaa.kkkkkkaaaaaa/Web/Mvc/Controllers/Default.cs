using System.Web.Mvc;

namespace kkkkkkaaaaaa.Web.Mvc.Controllers
{
    public class DefaultController : Controller
    {
        public ActionResult Default()
        {
            return this.View();
        }

        public ActionResult Error()
        {
            return this.View();
        }

        public ActionResult Status()
        {
            return this.View();
        }

        public ActionResult DoNothing()
        {
            return this.View();
        }
    }
}