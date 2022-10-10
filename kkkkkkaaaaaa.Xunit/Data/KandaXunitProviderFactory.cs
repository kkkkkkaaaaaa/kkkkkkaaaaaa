using kkkkkkaaaaaa.Data.Common;
using System.Data.Common;
using System.Data.SqlClient;

namespace kkkkkkaaaaaa.Xunit.Data
{
    /// <summary>
    /// プロバイダーのデータソースクラスの実装インスタンスを作成するためのメソッドのセットを表します。
    /// </summary>
    public class KandaXunitProviderFactory : KandaDbProviderFactory
    {
        static KandaXunitProviderFactory()
        {
            // DbProviderFactories.RegisterFactory(@"System.Data.SqlClient.SqlClientFactory", SqlClientFactory.Instance);
            DbProviderFactories.RegisterFactory(@"System.Data.SqlClient", SqlClientFactory.Instance);
        }


        /// <summary>
        /// Singleton インスタンス。
        /// </summary>
        public static readonly KandaXunitProviderFactory Instance = new Lazy<KandaXunitProviderFactory>(
            () => new KandaXunitProviderFactory(), 
            LazyThreadSafetyMode.ExecutionAndPublication).Value;

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public  KandaXunitProviderFactory() : base(DbProviderFactories.GetFactory(@"System.Data.SqlClient"))
        {
            this.DoNothing();
        }

        /// <summary>
        /// データベースへの接続を生成して取得します。
        /// </summary>
        /// <returns></returns>
        public override DbConnection CreateConnection()
        {
            var builder = this.CreateConnectionStringBuilder();
            builder.Add(@"Data Source", @"(local)");
            builder.Add(@"Initial Catalog", @"AdventureWorks2019");
            builder.Add(@"Integrated Security", @"True");
            builder.Add(@"Pooling", @"True");
            builder.Add(@"Connect Timeout", @"10");

            var connection = base.CreateConnection();
            connection.ConnectionString = builder.ConnectionString;

            return connection;
        }
    }
}
