using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace kkkkkkaaaaaa.Xunit
{
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

        #endregion

        /// <summary>
        /// コンストラクター。
        /// </summary>
        protected KandaXunitFacts()
        {
            this.TestData = new Uri(new Uri(AppDomain.CurrentDomain.BaseDirectory), @"../../TestData/");
        }

        /// <summary>
        /// テストデータのフォルダのルートを返します。
        /// </summary>
        protected Uri TestData { get; private set; }
    }
}