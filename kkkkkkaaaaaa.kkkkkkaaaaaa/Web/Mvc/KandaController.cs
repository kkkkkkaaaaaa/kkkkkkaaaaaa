using System.Web.Mvc;

namespace kkkkkkaaaaaa.Web.Mvc
{
    public abstract class KandaController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract ActionResult Default();

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