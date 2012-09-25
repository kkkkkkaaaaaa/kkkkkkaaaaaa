using System.Data;
using System.Data.Common;
using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa.Xunit.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class KandaXunitProviderFactory : KandaProviderFactory
    {
        /// <summary>
        /// Singleton インスタンス。
        /// </summary>
        public static KandaXunitProviderFactory Instance
        {
            get { return KandaXunitProviderFactory._instance; }
        }

        /// <summary>
        /// DbConnection クラスをを実装しているプロバイダーのクラスの新しいインスタンスを返します。
        /// </summary>
        /// <returns></returns>
        public override DbConnection CreateConnection()
        {
            var builder = base.CreateConnectionStringBuilder();
            //builder.ConnectionString = @"Data Source=(localdb)\kkkkkkaaaaaa_2010;Initial Catalog=kkkkkkaaaaaa.Database.2012;Integrated Security=True;Pooling=False;Connect Timeout=30";
            builder.Add(@"Data Source", @"(localdb)\kkkkkkaaaaaa_2010");
            builder.Add(@"Initial Catalog", @"kkkkkkaaaaaa.Database.2012");
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
        public override DbCommand  CreateCommand(DbConnection connection, DbTransaction transaction = null)
        {
            var command = base.CreateCommand(connection);

            command.CommandType = CommandType.StoredProcedure;

            return command;
        }

        /// <summary>
        /// DbConnectionReader クラスを実装しているクラスの新しいインスタンスを返します。
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public KandaDataReader CreateReader(DbConnection connection)
        {
            var reader = base.CreateReader(connection);

            reader.CommandType = CommandType.StoredProcedure;

            return reader;
        }

        #region Private members...

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        /// <param name="factory"></param>
        private KandaXunitProviderFactory(DbProviderFactory factory)
            : base(factory)
        {
            this.DoNothing();
        }

        /// <summary></summary>
        private readonly static KandaXunitProviderFactory _instance = new KandaXunitProviderFactory(KandaProviderFactories.GetFactory(@"System.Data.SqlClient"));

        #endregion

    }
}