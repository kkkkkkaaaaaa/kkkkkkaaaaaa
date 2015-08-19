using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa.Xunit.Repositories
{
    public class KandaRepositoryFacts
    {
        /// <summary>
        /// 
        /// </summary>
        protected KandaProviderFactory Factory
        {
            get { return this._factory; }
        }

        /// <summary></summary>
        private readonly KandaProviderFactory _factory = KandaProviderFactory.Instance;
    }
}