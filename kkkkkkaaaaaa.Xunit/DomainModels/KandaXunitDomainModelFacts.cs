using kkkkkkaaaaaa.Data;
using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa.Xunit.DomainModels
{
    /// <summary>
    /// kkkkkkaaaaaa.Xunit.DomainModels の基底クラスです。
    /// </summary>
    public class KandaXunitDomainModelFacts
    {
        /// <summary>
        /// このアプリケーションのデータプロバイダーのクラスのインスタンスを生成して返す、factroy Method を提供します。
        /// </summary>
        protected readonly KandaDbProviderFactory _factory = KandaProviderFactory.Instance;
    }
}