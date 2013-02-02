using System.Web.Mvc;

namespace kkkkkkaaaaaa.Web.Mvc
{
    public class KandaRazorViewEngine : RazorViewEngine
    {
        public KandaRazorViewEngine()
        {
            this.ViewLocationFormats = new []
                                           {
                                               @"~/Views/{0}.cshtml", 
                                               @"~/Views/{0}/{1}.cshtml", 
                                           };
        }
    }
}