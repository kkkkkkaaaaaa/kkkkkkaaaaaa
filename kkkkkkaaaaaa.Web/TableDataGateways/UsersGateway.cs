﻿using System;
using System.Data;
using System.Data.Common;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.Web.DataTransferObjects;

namespace kkkkkkaaaaaa.Web.TableDataGateways
{
    /// <summary>
    /// 
    /// </summary>
    public class UsersGateway : KandaTableDataGateway
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public static DbDataReader Select(UserEntity entity, DbConnection connection, DbTransaction transaction)
        {
            var reader = KandaTableDataGateway._factory.CreateReader(connection, transaction);

            reader.CommandText = @"usp_SelectUsers";

            KandaDbDataMapper.MapToParameters(reader, entity);
            //reader.Parameters.Add(KandaTableDataGateway._factory.CreateParameter("@id", id));

            var error = KandaTableDataGateway._factory.CreateParameter(@"Result", DbType.Int32, sizeof(int), ParameterDirection.ReturnValue, DBNull.Value);
            reader.Parameters.Add(error);

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
        public static int Insert(UserEntity entity, DbConnection connection, DbTransaction transaction)
        {
            var command = KandaTableDataGateway._factory.CreateCommand(connection, transaction);

            command.CommandText = @"usp_InsertUsers";

            KandaDbDataMapper.MapToParameters(command, entity);

            var result = KandaTableDataGateway._factory.CreateParameter(@"Result", DBNull.Value, ParameterDirection.Output);
            command.Parameters.Add(result);

            command.ExecuteNonQuery();

            return (int)result.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public static int Update(UserEntity entity, DbConnection connection, DbTransaction transaction)
        {
            var command = KandaTableDataGateway._factory.CreateCommand(connection, transaction);

            command.CommandText = @"usp_UpdateUsers";

            KandaDbDataMapper.MapToParameters(command, entity);

            var result = KandaTableDataGateway._factory.CreateParameter(@"Result", DBNull.Value);
            command.Parameters.Add(result);

            command.ExecuteNonQuery();

            return (int)result.Value;
        }

        /// <summary>
        /// Truncate。
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public static int Truncate(DbConnection connection, DbTransaction transaction)
        {
            return KandaTableDataGateway.Truncate(@"Users", connection, transaction);
        }
    }
}