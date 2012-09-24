using System.Data;
using System.Data.Common;

namespace kkkkkkaaaaaa.Data.Common
{
    /// <summary>
    /// プロバイダーのデータソースクラスの実装のインスタンスを作成するためのメソッドのセットを表わします。
    /// </summary>
    public partial class KandaProviderFactory
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
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public DbParameter CreateParameter(string name, object value, ParameterDirection direction)
        {
            var parameter = this.CreateParameter();

            parameter.ParameterName = name;
            parameter.Value = value;
            parameter.Direction = direction;

            return parameter;
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
    }
}