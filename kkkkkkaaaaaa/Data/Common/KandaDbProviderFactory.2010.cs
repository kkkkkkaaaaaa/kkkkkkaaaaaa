using System;
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
            var command = this.CreateCommand();

            command.Connection = connection;
            command.Transaction = transaction;

            return command;
        }

        public DbParameter CreateParameter(string name, DbType dbType, int size, ParameterDirection direction, object value)
        {
            var parameter = this.CreateParameter();

            parameter.ParameterName = name;
            parameter.DbType = dbType;
            parameter.Size = size;
            parameter.Direction = direction;
            parameter.Value = value;

            return parameter;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public DbParameter CreateParameter(string name, object value, DbType type, int size, ParameterDirection direction)
        {
            var parameter = this.CreateParameter();

            parameter.ParameterName = name;
            parameter.Value = value;
            parameter.DbType = type;
            parameter.Size = size;
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
            return this.CreateParameter(name, value, default(DbType), default(int), ParameterDirection.Input);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public DbParameter CreateParameter(string name, object value, ParameterDirection direction)
        {
            return this.CreateParameter(name, value, default(DbType), default(int), direction);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public DbParameter CreateParameter(string name, object value, DbType type)
        {
            return this.CreateParameter(name, value, type, default(int), ParameterDirection.Input);
        }

        /// <summary>
        /// DbParameter クラスを実装しているプロバイダーのクラスの新しいインスタンスを返します。
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DbParameter CreateParameter(string name)
        {
            return this.CreateParameter(name, DBNull.Value, default(DbType), default(int), ParameterDirection.Input);
        }

        /*
        /// <summary>
        /// DbParameter クラスを実装しているプロバイダーのクラスの新しいインスタンスを返します。
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public DbParameter CreateParameter(string name, object value, DbType type = DbType.Object, ParameterDirection direction = ParameterDirection.Input)
        {

            var parameter = this.CreateParameter();

            parameter.ParameterName = name;
            parameter.Value = value;
            parameter.DbType = type;
            parameter.Direction = direction;

            return parameter;
        }
        */

        /// <summary>
        /// DbDataReader クラスを実装しているプロバイダーのクラスの新しいインスタンスを返します。
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public virtual KandaDbDataReader CreateReader(DbConnection connection, DbTransaction transaction = null)
        {
            /*
             * 
            var command = this.CreateCommand(connection, transaction);

            return new KandaDbDataReader(command);
            */
            return new KandaDbDataReader(connection, transaction);
        }
    }
}