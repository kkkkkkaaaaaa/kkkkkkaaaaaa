using System.Web.Mvc;

namespace kkkkkkaaaaaa.Web.Mvc
{
    /// <summary>
    /// 
    /// </summary>
    public static class ViewEngineConfig
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="engines"></param>
        public static void RegisterViewEngines(ViewEngineCollection engines)
        {
            engines.Clear();
            engines.Add(new KandaRazorViewEngine());
        }
    }
}