using System.Web.Mvc;

namespace kkkkkkaaaaaa.Web.Mvc
{
    public class KandaRazorViewEngine : RazorViewEngine
    {
        public KandaRazorViewEngine()
        {
            // {0} : view、{1} : controller、{2} : area

            this.MasterLocationFormats = new[]
                                             {
                                                 @"~/Views/Shared/{0}.cshtml", 
                                             };

            this.PartialViewLocationFormats = new[]
                                                  {
                                                      @"~/Views/Partial/{0}.cshtml",  
                                                      @"~/Views/Shared/{0}.cshtml", 
                                                      @"~/Views/Shared/Partial/{0}.cshtml", 
                                                  };

            this.ViewLocationFormats = new[]
                                           {
                                               @"~/Views/{1}.cshtml", 
                                               @"~/Views/{1}/{0}.cshtml", 
                                           };
        }
    }
}