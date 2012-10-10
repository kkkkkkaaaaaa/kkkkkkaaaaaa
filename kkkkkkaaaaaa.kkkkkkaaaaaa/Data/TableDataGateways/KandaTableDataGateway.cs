using System;
using System.Data;
using System.Data.Common;
using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa.Data.TableDataGateways
{
    internal class KandaTableDataGateway
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        protected static int Truncate(string tableName, DbConnection connection, DbTransaction transaction = null)
        {
            var command = KandaTableDataGateway._factory.CreateCommand(connection, transaction);

            command.CommandText = @"usp_TruncateTable";

            command.Parameters.Add(KandaTableDataGateway._factory.CreateParameter("@tableName", tableName));

            var result = KandaTableDataGateway._factory.CreateParameter(KandaTableDataGateway.RETURN_VALUE, DbType.Int32, sizeof(int), ParameterDirection.ReturnValue, DBNull.Value);
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
        protected static decimal IdentCurrent(string tableName, DbConnection connection, DbTransaction transaction = null)
        {
            var command = KandaTableDataGateway._factory.CreateCommand(connection, transaction);

            command.CommandText = @"IdentCurrentTable";

            command.Parameters.Add(KandaTableDataGateway._factory.CreateParameter(@"tableName", tableName));

            var result = KandaTableDataGateway._factory.CreateParameter(KandaTableDataGateway.RETURN_VALUE, DbType.Decimal, sizeof(decimal), ParameterDirection.ReturnValue, DBNull.Value);
            command.Parameters.Add(result);

            command.ExecuteNonQuery();

            return (decimal)result.Value;
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

        /*
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public static DbDataReader Select(Entity entity, DbConnection connection, DbTransaction transaction)
        {
            var reader = KandaTableDataGateway._factory.CreateReader(connection, transaction);

            reader.CommandText = @"usp_Select";

            KandaDbDataMapper.MapToParameters(reader, entity);

            reader.ExecuteReader();

            return reader;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public static int Insert(Entity entity, DbConnection connection, DbTransaction transaction)
        {
            var command = KandaTableDataGateway._factory.CreateCommand(connection, transaction);

            command.CommandText = @"usp_Insert";

            KandaDbDataMapper.MapToParameters(command, entity);

            var result = KandaTableDataGateway._factory.CreateParameter(KandaTableDataGateway.RETURN_VALUE, DbType.Int32, sizeof (int), ParameterDirection.ReturnValue, DBNull.Value);
            command.Parameters.Add(result);

            command.ExecuteNonQuery();

            return (int) result.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public static int Update(Entity entity, DbConnection connection, DbTransaction transaction)
        {
            var command = KandaTableDataGateway._factory.CreateCommand(connection, transaction);

            command.CommandText = @"usp_Update";

            KandaDbDataMapper.MapToParameters(command, entity);

            var result = KandaTableDataGateway._factory.CreateParameter(KandaTableDataGateway.RETURN_VALUE, DbType.Int32, sizeof(int), ParameterDirection.ReturnValue, DBNull.Value);
            command.Parameters.Add(result);

            command.ExecuteNonQuery();

            return (int)result.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public static int Truncate(DbConnection connection, DbTransaction transaction)
        {
            return KandaTableDataGateway.Truncate(@"", connection, transaction);
        }
        */
    }
}