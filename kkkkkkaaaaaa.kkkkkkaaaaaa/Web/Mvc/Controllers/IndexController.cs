﻿using System;
using System.Web.Mvc;

namespace kkkkkkaaaaaa.Web.Mvc.Controllers
{
    public class IndexController : Controller
    {
        public ViewResult Index()
        {
            throw new Exception(@"From Index");
            return this.View();
        }
    }
}