using kkkkkkaaaaaa.Data;
using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa.Xunit.Repositories
{
    /// <summary>
    /// Kanda.Xunit.Repositories の基底クラスです。
    /// </summary>
    public abstract class KandaXunitRepositoryFacts
    {
        /// <summary>
        /// このアプリケーションのデータプロバイダーのクラスのインスタンスを生成して返す、Factory Mathod を提供します。
        /// </summary>
        protected KandaDbProviderFactory _factory = KandaProviderFactory.Instance;
    }
}