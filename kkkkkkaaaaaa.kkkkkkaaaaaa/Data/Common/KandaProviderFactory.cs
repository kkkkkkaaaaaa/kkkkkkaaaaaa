using System;
using System.Data;
using System.Data.Common;
using System.Threading;

namespace kkkkkkaaaaaa.Data.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class KandaProviderFactory : KandaDbProviderFactory
    {
        /// <summary>
        /// Singleton インスタンス。
        /// </summary>
        public static KandaProviderFactory Instance
        {
            get { return KandaProviderFactory._instance.Value; }
        }

        /// <summary>
        /// DbConnetion クラスを実装しているプロバイダーのクラスの新しいインスタンスを返します。
        /// </summary>
        /// <returns></returns>
        public override DbConnection CreateConnection()
        {
            var builder = base.CreateConnectionStringBuilder();
            builder.Add(@"Data Source", @"(localdb)\kkkkkkaaaaaa_2010");
            builder.Add(@"Initial Catalog", @"kkkkkkaaaaaa.Database.2010");
            builder.Add(@"Integrated Security", @"True");
            builder.Add(@"Pooling", @"False");
            builder.Add(@"Connect Timeout", @"30");

            var connection = base.CreateConnection();
            connection.ConnectionString = builder.ConnectionString;

            return connection;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public override DbCommand CreateCommand(DbConnection connection, DbTransaction transaction = null)
        {
            var command = base.CreateCommand(connection, transaction);

            command.CommandType = CommandType.StoredProcedure;

            return command;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public override KandaDbDataReader CreateReader(DbConnection connection, DbTransaction transaction = null)
        {
            var reader = base.CreateReader(connection, transaction);

            reader.CommandType = CommandType.StoredProcedure;

            return reader;
        }

        #region Private members...

        /// <summary>
        /// コンストラクタ―。
        /// </summary>
        private KandaProviderFactory()
            : base(DbProviderFactories.GetFactory(@"System.Data.SqlClient"))
        {
            this.DoNothing();
        }

        /// <summary></summary>
        private static readonly Lazy<KandaProviderFactory> _instance = new Lazy<KandaProviderFactory>(() => { return new KandaProviderFactory(); }, LazyThreadSafetyMode.ExecutionAndPublication);

        #endregion
    }
}