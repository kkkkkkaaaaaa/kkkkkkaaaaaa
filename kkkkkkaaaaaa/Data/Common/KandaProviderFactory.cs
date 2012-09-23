using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace kkkkkkaaaaaa.Data.Common
{
    /// <summary>
    /// プロバイダーのデータソースクラスの実装のインスタンスを作成するためのメソッドのセットを表わします。
    /// </summary>
    public partial class KandaProviderFactory : DbProviderFactory
    {
        /// <summary>
        /// DbCommandBuilder クラスを実装しているプロバイダーのクラスの新しいインスタンスを返します。
        /// </summary>
        /// <returns></returns>
        public override DbConnectionStringBuilder CreateConnectionStringBuilder()
        {
            return this._factory.CreateConnectionStringBuilder();
        }

        /// <summary>
        /// DbConnection クラスを実装しているプロバイダーの新しいインスタンスを返します。
        /// </summary>
        /// <returns></returns>
        public override DbConnection CreateConnection()
        {
            return this._factory.CreateConnection();
        }

        /// <summary>
        /// DbCommand クラスを実装しているプロバイダーのクラスの新しいインスタンスを返します。
        /// </summary>
        /// <returns></returns>
        public override DbCommand CreateCommand()
        {
            return this._factory.CreateCommand();
        }

        /// <summary>
        /// DbCommand クラスを実装しているプロバイダーのクラスの新しいインスタンスを返します。
        /// </summary>
        /// <param name="connection">データベースへの接続。</param>
        /// <param name="transaction">トランザクション。</param>
        /// <returns></returns>
        public DbCommand CreateCommand(DbConnection connection, DbTransaction transaction)
        {
            var command = this.CreateCommand();

            command.Connection = connection;
            command.Transaction = transaction;

            return command;
        }

        /// <summary>
        /// DbDataReader クラスを実装しているプロバイダーのクラスの新しいインスタンスを返します。
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public DbDataReader CreateReader(DbConnection connection, DbTransaction transaction)
        {
            var command = this.CreateCommand(connection, transaction);

            return new KandaDataReader(command);
        }

        /// <summary>
        /// DbParameter クラスを実装しているプロバイダーのクラスの新しいインスタンスを返します。
        /// </summary>
        /// <returns></returns>
        public override DbParameter CreateParameter()
        {
            return this._factory.CreateParameter();
        }

        /// <summary>
        /// DbParameter クラスを実装しているプロバイダーのクラスの新しいインスタンスを返します。
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public DbParameter CreateParameter(string name, object value)
        {
            return this.CreateParameter(name, value, ParameterDirection.Input);
        }


        /// <summary>
        /// コンストラクタ―。
        /// </summary>
        /// <param name="factory"></param>
        internal KandaProviderFactory(DbProviderFactory factory)
        {
            this._factory = factory;
        }

        #region Private members...

        /// <summary>プロバイダーのデータソースクラスの実装のインスタンスを作成するためのメソッドのセットを表わします。</summary>f
        private readonly DbProviderFactory _factory;

        #endregion
    }
}
