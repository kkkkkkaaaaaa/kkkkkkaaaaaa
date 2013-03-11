using System.Web.Mvc;

namespace kkkkkkaaaaaa.Web.Mvc
{
    public class KandaRazorViewEngine : RazorViewEngine
    {
        public KandaRazorViewEngine()
        {
            this.MasterLocationFormats = new[]
                                             {
                                                 @"~/Views/Shared/{0}.cshtml",
                                             };

            // {0} : controller, {1} : action
            this.ViewLocationFormats = new []
                                           {
                                               @"~/Views/{1}.cshtml", 
                                               @"~/Views/{0}/{1}.cshtml", 
                                           };
        }
    }
}