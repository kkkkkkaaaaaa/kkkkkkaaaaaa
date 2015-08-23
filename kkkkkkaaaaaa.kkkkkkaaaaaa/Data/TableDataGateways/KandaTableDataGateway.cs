using System;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa.Data.TableDataGateways
{
    /// <summary>
    /// 
    /// </summary>
    internal partial class KandaTableDataGateway
    {
        /// <summary>
        /// 
        /// </summary>
        public const string RETURN_VALUE = @"ReturnValue";

        /// <summary>
        /// 
        /// </summary>
        public const int NO_ERRORS = 0;

        /// <summary>
        /// 
        /// </summary>
        public const int DUPLICATE_USER_NAME = 2627;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connction"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public static DateTime GetUtcDateTime(DbConnection connction, DbTransaction transaction)
        {
            var command = _factory.CreateCommand(connction, transaction);

            var result = _factory.CreateParameter(RETURN_VALUE, DbType.DateTime2, 8, ParameterDirection.ReturnValue, DBNull.Value);
            command.Parameters.Add(result);

            command.CommandText = @"GetUTCDateTime";

            command.ExecuteNonQuery();

            return (DateTime)result.Value;
        }

        #region Internal members...

        /// <summary>
        /// 
        /// </summary>
        /// <param name="count"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        internal static string NewLine(int count, DbConnection connection)
        {
            var command = _factory.CreateCommand(connection);

            // パラメーター
            command.Parameters.Add(_factory.CreateParameter("@count", DbType.Int32, sizeof(int), ParameterDirection.Input, count));

            // 戻り値
            var result = _factory.CreateParameter(RETURN_VALUE, DbType.String, 0, ParameterDirection.ReturnValue, DBNull.Value);
            command.Parameters.Add(result);

            command.CommandText = @"NewLine";

            command.ExecuteNonQuery();

            return (string)result.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        internal static string NewLine(DbConnection connection)
        {
            var command = _factory.CreateCommand(connection);

            // 戻り値
            var result = _factory.CreateParameter(RETURN_VALUE, DbType.String, 0, ParameterDirection.ReturnValue, DBNull.Value);
            command.Parameters.Add(result);

            command.CommandText = @"NewLine";

            command.ExecuteNonQuery();

            return (string)result.Value;
        }

        #endregion

        #region Protected members...

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        protected static int Truncate(string tableName, DbConnection connection, DbTransaction transaction)
        {
            var command = _factory.CreateCommand(connection, transaction);

            command.CommandText = @"usp_TruncateTable";

            command.Parameters.Add(_factory.CreateParameter("@tableName", tableName));

            var result = _factory.CreateParameter(RETURN_VALUE, DbType.Int32, sizeof(int), ParameterDirection.ReturnValue, DBNull.Value);
            command.Parameters.Add(result);

            command.ExecuteNonQuery();

            return (int)result.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        protected static decimal IdentCurrent(string tableName, DbConnection connection, DbTransaction transaction)
        {
            var command = _factory.CreateCommand(connection, transaction);

            command.CommandText = @"IdentCurrentTable";

            command.Parameters.Add(_factory.CreateParameter("@tableName", tableName));

            var result = _factory.CreateParameter(RETURN_VALUE, DbType.Decimal, sizeof(decimal), ParameterDirection.ReturnValue, DBNull.Value);
            command.Parameters.Add(result);

            command.ExecuteNonQuery();

            return (decimal)result.Value;
        }

        /// <summary>
        /// 何もしません。
        /// </summary>
        [DebuggerStepThrough()]
        protected static void DoNothing()
        {
            // 何もしない
        }

        /// <summary>
        /// 
        /// </summary>
        protected static KandaDbProviderFactory _factory = KandaProviderFactory.Instance;

        #endregion
    }
}