using System.Web.Mvc;

namespace kkkkkkaaaaaa.Web.Mvc
{
    public static class EngineConfig
    {
        public static void RegisterViewEngines(ViewEngineCollection engines)
        {
            engines.Add(new KandaRazorViewEngine());
        }
    }
}