using System;
using System.Data;
using System.Data.Common;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.Web.DataTransferObjects;

namespace kkkkkkaaaaaa.Web.TableDataGateways
{
    public class RolesGateway : KandaTableDataGateway
    {
        public static DbDataReader Select(RoleEntity role, DbConnection connection, DbTransaction transaction)
        {
            var reader = KandaTableDataGateway._factory.CreateReader(connection, transaction);

            reader.CommandText = @"usp_SelectRoles";

            KandaDbDataMapper.MapToParameters(reader, role);

            return reader.ExecuteReader();
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

        public static int Truncate(DbConnection connection, DbTransaction transaction)
        {
            return KandaTableDataGateway.Truncate(@"Roles", connection, transaction);
        }
    }
}