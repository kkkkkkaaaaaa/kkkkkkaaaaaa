using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kkkkkkaaaaaa.Web.Mvc.Controllers
{
    public class DefaultController : Controller
    {
        //
        // GET: /Default/
        public ActionResult Default()
        {
            this.ViewBag.Title = @"a";

            return this.View();
        }

    }
}
