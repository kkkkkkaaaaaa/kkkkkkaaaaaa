using System.Web;
using System.Web.Mvc;

namespace kkkkkkaaaaaa.Web.Mvc
{
    public abstract class KandaController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        public long MembershipID
        {
            get
            {
                var name = this.User.Identity.Name;
                var id = long.Parse(name);

                return id;

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract ActionResult Default(string viewName = null);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual ActionResult DoNothing(string viewName = null)
        {
            return this.View(viewName);
        }
    }
}