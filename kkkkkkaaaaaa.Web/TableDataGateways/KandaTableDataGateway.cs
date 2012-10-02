using System;
using System.Data;
using System.Data.Common;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.Web.Data;

namespace kkkkkkaaaaaa.Web.TableDataGateways
{
    public class KandaTableDataGateway
    {
        public const string RETURN_VALUE = @"ReturnValue";


        public static DateTime GetUtcDateTime(DbConnection connction, DbTransaction transaction = null)
        {
            var command = KandaTableDataGateway._factory.CreateCommand(connction, transaction);

            var result = KandaTableDataGateway._factory.CreateParameter("Result", DBNull.Value, ParameterDirection.ReturnValue);
            command.Parameters.Add(result);

            command.CommandText = @"GetUTCDateTime";

            command.ExecuteNonQuery();

            return (DateTime)result.Value;
        }

        public static long SelectNextID(string table, DbConnection connection, DbTransaction transaction)
        {
            return 0L;
        }

        public static void SetIdentityInsert(string table, bool on, DbConnection connection, DbTransaction transaction = null)
        {
            var command = KandaTableDataGateway._factory.CreateCommand(connection, transaction);

            command.CommandType = CommandType.Text;

            const string SET = @"SET IDENTITY_INSERT {0} {1}";
            command.CommandText = string.Format(SET, table, (on ? @"ON" : @"OFF"));

            command.ExecuteNonQuery();
        }

        #region Protected members...

        public static int Truncate(string tableName, DbConnection connection, DbTransaction transaction)
        {
            var command = KandaTableDataGateway._factory.CreateCommand(connection, transaction);

            command.CommandText = @"usp_TruncateTable";

            command.Parameters.Add(KandaTableDataGateway._factory.CreateParameter("@tableName", tableName));

            var result = KandaTableDataGateway._factory.CreateParameter("Result", DbType.Int32, sizeof(int), ParameterDirection.ReturnValue, DBNull.Value);
            command.Parameters.Add(result);

            command.ExecuteNonQuery();

            return (int)result.Value;
        }

        /// <summary>
        /// 何もしません。
        /// </summary>
        protected void DoNothing()
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