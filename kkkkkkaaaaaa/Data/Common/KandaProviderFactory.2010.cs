using System.Data;
using System.Data.Common;

namespace kkkkkkaaaaaa.Data.Common
{
    public partial class KandaProviderFactory
    {
        /// <summary>
        /// DbCommand クラスを実装しているプロバイダーのクラスの新しいインスタンスを返します。
        /// </summary>
        /// <param name="connection">データベースへの接続。</param>
        /// <param name="transaction">トランザクション。</param>
        /// <returns></returns>
        public DbCommand CreateCommand(DbConnection connection, DbTransaction transaction = null)
        {
            var command = this.CreateCommand();

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
    }
}