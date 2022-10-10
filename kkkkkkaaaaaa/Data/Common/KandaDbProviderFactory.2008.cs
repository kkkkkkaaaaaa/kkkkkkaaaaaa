using System.Data;
using System.Data.Common;
using System.Diagnostics;

namespace kkkkkkaaaaaa.Data.Common
{
    /// <summary>
    /// プロバイダーのデータソースクラスの実装のインスタンスを作成するためのメソッドのセットを表わします。
    /// </summary>
    public partial class KandaDbProviderFactory
    {
        /// <summary>
        /// DbCommand クラスを実装しているプロバイダーのクラスの新しいインスタンスを返します。
        /// </summary>
        /// <param name="connection">データベースへの接続。</param>
        /// <param name="transaction">トランザクション。</param>
        /// <returns></returns>
        public DbCommand CreateCommand(DbConnection connection, DbTransaction transaction)
        {
            var command = connection.CreateCommand();

            command.Transaction = transaction;

            return command;
        }

        
        /// <summary>
        /// DbCommand クラスを実装しているプロバイダーのクラスの新しいインスタンスを返します。
        /// </summary>
        /// <param name="connection">データベースへの接続。</param>
        /// <returns></returns>
        public virtual DbCommand CreateCommand(DbConnection connection)
        {
            return this.CreateCommand(connection, null);
        }

        /// <summary>
        /// DbDataReader クラスを実装しているプロバイダーのクラスの新しいインスタンスを返します。
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public KandaDbDataReader CreateReader(DbConnection connection, DbTransaction transaction)
        {
            var command = this.CreateCommand(connection, transaction);

            return new KandaDbDataReader(command);
        }

        /// <summary>
        /// DbDataReader クラスを実装しているプロバイダーのクラスの新しいインスタンスを返します。
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public virtual KandaDbDataReader CreateReader(DbConnection connection)
        {
            return this.CreateReader(connection, null);
        }

        /// <summary>
        /// DbParameter クラスを実装しているプロバイダーのクラスの新しいインスタンスを返します。
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public DbParameter CreateParameter(string name, object value, DbType type, ParameterDirection direction)
        {
            var parameter = this.CreateParameter();

            parameter.ParameterName = name;
            parameter.Value = value;
            parameter.DbType = type;
            parameter.Direction = direction;

            return parameter;
        }

        /// <summary>
        /// プロバイダーのバージョンの CodeAccessPermission クラスを実装しているプロバイダーのクラスの新しいインスタンスを返します。
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public override CodeAccessPermission CreatePermission(PermissionState state)
        {
            return this._factory.CreatePermission(state);
        }
    }
}