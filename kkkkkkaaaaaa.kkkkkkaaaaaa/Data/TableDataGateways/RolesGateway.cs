using System;
using System.Data;
using System.Data.Common;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.DataTransferObjects;

namespace kkkkkkaaaaaa.Data.TableDataGateways
{
    internal class RolesGateway : KandaTableDataGateway
    {
        public const string TABLE_NAME = @"Roles";

        public static DbDataReader Select(RolesCriteria criteria, DbConnection connection, DbTransaction transaction)
        {
            var reader = KandaTableDataGateway._factory.CreateReader(connection, transaction);

            reader.CommandText = @"usp_SelectRoles";

            KandaDbDataMapper.MapToParameters(reader, criteria);

            reader.ExecuteReader();

            return reader;
        }

        public static decimal IdentCurrent(DbConnection connection, DbTransaction transaction)
        {
            return KandaTableDataGateway.IdentCurrent(RolesGateway.TABLE_NAME, connection, transaction);
        }

        public static int Insert(RoleEntity entity, DbConnection connection, DbTransaction transaction)
        {
            var command = KandaTableDataGateway._factory.CreateCommand(connection, transaction);

            command.CommandText = @"usp_InsertRoles";

            KandaDbDataMapper.MapToParameters(command, entity);

            var result = KandaTableDataGateway._factory.CreateParameter(@"Result", DbType.Int32, sizeof(int), ParameterDirection.ReturnValue, DBNull.Value);
            command.Parameters.Add(result);

            command.ExecuteNonQuery();

            return (int)result.Value;
        }

        public static int Update(RoleEntity entity, DbConnection connection, DbTransaction transaction)
        {
            var command = KandaTableDataGateway._factory.CreateCommand(connection, transaction);

            command.CommandText = @"usp_UpdateRoles";

            KandaDbDataMapper.MapToParameters(command, entity);

            var result = KandaTableDataGateway._factory.CreateParameter(@"Result", DbType.Int32, sizeof(int), ParameterDirection.ReturnValue, DBNull.Value);
            command.Parameters.Add(result);

            command.ExecuteNonQuery();

            return (int)result.Value;
        }

        public static int Delete(long id, DbConnection connection, DbTransaction transaction)
        {
            var command = KandaTableDataGateway._factory.CreateCommand(connection, transaction);

            command.CommandText = @"usp_DeleteRoles";

            command.Parameters.Add(KandaTableDataGateway._factory.CreateParameter("@id", id));

            var result = KandaTableDataGateway._factory.CreateParameter(KandaTableDataGateway.RETURN_VALUE, DbType.Int32, sizeof(int), ParameterDirection.ReturnValue, DBNull.Value);
            command.Parameters.Add(result);

            command.ExecuteNonQuery();

            return (int)result.Value;
        }

        public static int Truncate(DbConnection connection, DbTransaction transaction)
        {
            return KandaTableDataGateway.Truncate(RolesGateway.TABLE_NAME, connection, transaction);
        }
    }
}