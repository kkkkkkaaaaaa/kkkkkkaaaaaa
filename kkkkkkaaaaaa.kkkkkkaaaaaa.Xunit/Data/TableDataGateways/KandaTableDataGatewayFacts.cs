using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa.kkkkkkaaaaaa.Xunit.Data.TableDataGateways
{
    /// <summary>
    /// TableDataGatewayFacts の基底クラスを表します。
    /// </summary>
    public class KandaTableDataGatewayFacts
    {
        #region Protected members...

        /// <summary>
        /// データベースプロバイダーのファクトリー。
        /// </summary>
        protected KandaProviderFactory Factory
        {
            get { return this._factory; }
        }

        #endregion

        #region Private members...

        /// <summary></summary>
        private readonly KandaProviderFactory _factory = KandaProviderFactory.Instance;

        #endregion
    }
}