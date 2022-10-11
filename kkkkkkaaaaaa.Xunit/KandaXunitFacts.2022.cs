using kkkkkkaaaaaa.Xunit.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace kkkkkkaaaaaa.Xunit
{
    /// <summary>
    /// 
    /// </summary>
    public class KandaXunitFacts
    {
        /// <summary>
        /// 静的コンストラクター。
        /// </summary>
        static KandaXunitFacts()
        {
            DbProviderFactories.RegisterFactory(@"System.Data.SqlClient", SqlClientFactory.Instance);
        }

        #region Protected members...
        
        /// <summary>
        /// コンストラクター。
        /// </summary>
        protected KandaXunitFacts()
        {
            this.TestData = new Uri(new Uri(AppDomain.CurrentDomain.BaseDirectory), @"../../TestData/");
        }

        /// <summary>
        /// DbProviderFactory を取得します。
        /// </summary>
        protected DbProviderFactory Provider
        {
            get { return this._factory.Value; }
        }

        /// <summary>
        /// テストデータのフォルダのルートを返します。
        /// </summary>
        protected Uri TestData { get; private set; }

        #endregion
        
        #region Private members...

        /// <summary></summary>
        private readonly Lazy<DbProviderFactory> _factory = new Lazy<DbProviderFactory>(
            () => new KandaXunitProviderFactory(),
            LazyThreadSafetyMode.ExecutionAndPublication
        );

        #endregion
    }
}