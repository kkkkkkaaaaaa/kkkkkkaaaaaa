using System.Data;
using System.Data.Common;

namespace kkkkkkaaaaaa.Data.Common
{
    public partial class KandaDbProviderFactory
    {
        /// <summary>
        /// DbCommand クラスを実装しているプロバイダーのクラスの新しいインスタンスを返します。
        /// </summary>
        /// <param name="connection">データベースへの接続。</param>
        /// <param name="transaction">トランザクション。</param>
        /// <returns></returns>
        public virtual DbCommand CreateCommand(DbConnection connection, DbTransaction transaction = null)
        {
            var command = connection.CreateCommand();

            command.Connection = connection;
            command.Transaction = transaction;

            return command;
        }

        /// <summary>
        /// DbParameter クラスを実装しているプロバイダーのクラスの新しいインスタンスを返します。
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public DbParameter CreateParameter(string name, object value, ParameterDirection direction = ParameterDirection.Input)
        {
            var parameter = this.CreateParameter();

            parameter.ParameterName = name;
            parameter.Value = value;
            parameter.Direction = direction;

            return parameter;
        }

        /// <summary>
        /// DbDataReader クラスを実装しているプロバイダーのクラスの新しいインスタンスを返します。
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public virtual KandaDbDataReader CreateReader(DbConnection connection, DbTransaction transaction = null)
        {
            var command = connection.CreateCommand();
            
            // var command = this.CreateCommand();

            // command.Connection = connection;
            // command.Transaction = transaction;

            return new KandaDbDataReader(command);
        }
    }
}