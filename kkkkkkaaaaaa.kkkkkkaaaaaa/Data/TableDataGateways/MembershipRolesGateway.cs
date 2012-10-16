using System;
using System.Data;
using System.Data.Common;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.DataTransferObjects;

namespace kkkkkkaaaaaa.Data.TableDataGateways
{
    /// <summary>
    /// 
    /// </summary>
    internal class MembershipRolesGateway : KandaTableDataGateway
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public static KandaDbDataReader Select(MembershipRolesCriteria criteria, DbConnection connection, DbTransaction transaction)
        {
            var reader = KandaTableDataGateway._factory.CreateReader(connection, transaction);

            reader.CommandText = @"usp_SelectMembershipRoles";

            KandaDbDataMapper.MapToParameters(reader, criteria);

            var result = KandaTableDataGateway._factory.CreateParameter(KandaTableDataGateway.RETURN_VALUE, DbType.Int32, sizeof(int), ParameterDirection.ReturnValue, DBNull.Value);
            reader.Parameters.Add(result);

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
        public static int Insert(MembershipRoleEntity entity, DbConnection connection, DbTransaction transaction)
        {
            var command = KandaTableDataGateway._factory.CreateCommand(connection, transaction);

            command.CommandText = @"usp_InsertMembershipRoles";

            KandaDbDataMapper.MapToParameters(command, entity);

            var result = KandaTableDataGateway._factory.CreateParameter(@"Result", DbType.Int32, sizeof(int), ParameterDirection.ReturnValue, DBNull.Value);
            command.Parameters.Add(result);

            command.ExecuteNonQuery();

            return (int)result.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public static int Delete(MembershipRolesCriteria criteria, DbConnection connection, DbTransaction transaction)
        {
            var command = KandaTableDataGateway._factory.CreateCommand(connection, transaction);

            command.CommandText = @"usp_DeleteMembershipRoles";

            KandaDbDataMapper.MapToParameters(command, criteria);

            var result = KandaTableDataGateway._factory.CreateParameter(@"Result", DbType.Int32, sizeof(int), ParameterDirection.ReturnValue, DBNull.Value);
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
            return KandaTableDataGateway.Truncate(@"MembershipRoles", connection, transaction);
        }
    }
}