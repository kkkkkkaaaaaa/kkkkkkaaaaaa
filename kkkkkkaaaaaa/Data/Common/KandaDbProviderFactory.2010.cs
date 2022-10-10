using System;
using System.Data;
using System.Data.Common;
using System.Diagnostics;

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
        public virtual KandaDbDataReader CreateReader(DbConnection connection, DbTransaction transaction = null)
        {
            return new KandaDbDataReader(connection, transaction);
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