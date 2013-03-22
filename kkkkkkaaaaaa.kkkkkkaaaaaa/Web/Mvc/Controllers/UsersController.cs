using System.Web.Mvc;

namespace kkkkkkaaaaaa.Web.Mvc.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult Get()
        {
            return this.View();
        }

        public ActionResult Find()
        {
            return this.View(@"User");
        }

        public ActionResult Update()
        {
            return this.View();
        }

        public ActionResult Delete()
        {
            return this.View();
        }
    }
}