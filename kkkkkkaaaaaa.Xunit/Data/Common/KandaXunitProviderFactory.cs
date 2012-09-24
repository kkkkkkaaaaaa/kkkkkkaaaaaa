using System;
using System.Data.Common;
using System.Threading;
using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa.Xunit.Data.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class KandaXunitProviderFactory : KandaProviderFactory
    {
        /// <summary>
        /// Singleton インスタンス。
        /// </summary>
        public readonly static KandaXunitProviderFactory Instance = new KandaXunitProviderFactory(KandaProviderFactories.GetFactory(@"System.Data.SqlClient"));

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="factory"></param>
        internal KandaXunitProviderFactory(DbProviderFactory factory)
            : base(factory)
        {
            this.DoNothing();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override DbConnection CreateConnection()
        {
            var builder = this.CreateConnectionStringBuilder();

            builder.Add(@"Data Source", @"(localdb)\kkkkkkaaaaaa_2010");
            builder.Add(@"Initial Catalog", @"kkkkkkaaaaaa.Database.2012");
            builder.Add(@"Integrated Security", @"True");
            builder.Add(@"Pooling", @"False");
            builder.Add(@"Connect Timeout", @"30");

            //builder.ConnectionString = @"Data Source=(localdb)\kkkkkkaaaaaa_2010;Initial Catalog=kkkkkkaaaaaa.Database.2012;Integrated Security=True;Pooling=False;Connect Timeout=30";

            var connection = base.CreateConnection();
            connection.ConnectionString = builder.ConnectionString;

            return connection;
        }

    }
}