using System;
using System.Data;
using System.Data.Common;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.Web.DataTransferObjects;

namespace kkkkkkaaaaaa.Web.TableDataGateways
{
    public class MembershipsGateway : KandaTableDataGateway
    {
        public static KandaDbDataReader Select(string name, string password, DbConnection connection, DbTransaction transaction)
        {
            var reader = KandaTableDataGateway._factory.CreateReader(connection, transaction);

            reader.CommandText = @"usp_SelectMemberships";

            reader.Parameters.Add(KandaTableDataGateway._factory.CreateParameter("@name", name));
            reader.Parameters.Add(KandaTableDataGateway._factory.CreateParameter("@password", password));

            reader.ExecuteReader();

            return reader;
        }

        public static long SelectNextID(DbConnection connection, DbTransaction transaction)
        {
            var command = KandaTableDataGateway._factory.CreateCommand(connection, transaction);

            command.CommandText = @"usp_SelectNextMembershipsID";

            var result = KandaTableDataGateway._factory.CreateParameter("Result", DBNull.Value, ParameterDirection.ReturnValue);
            command.Parameters.Add(result);

            command.ExecuteNonQuery();

            return (long) result.Value;
        }

        public static int InsertMemberships(MembershipEntity entity, DbConnection connection, DbTransaction transaction)
        {
            var command = KandaTableDataGateway._factory.CreateCommand(connection, transaction);

            command.CommandText = @"usp_InsertMemberships";

            command.Parameters.Add(KandaTableDataGateway._factory.CreateParameter("@id", entity.ID));
            command.Parameters.Add(KandaTableDataGateway._factory.CreateParameter("@name", entity.Name));
            command.Parameters.Add(KandaTableDataGateway._factory.CreateParameter("@password", entity.Password));
            command.Parameters.Add(KandaTableDataGateway._factory.CreateParameter("@enabled", entity.Enabled));
            command.Parameters.Add(KandaTableDataGateway._factory.CreateParameter("@createdOn", entity.CreatedOn));

            var affected = command.ExecuteNonQuery();

            return affected;
        }

        public static int UpdatedMemberships(MembershipEntity entity, DbConnection connection, DbTransaction transaction)
        {
            var command = KandaTableDataGateway._factory.CreateCommand(connection, transaction);

            command.CommandText = @"usp_UpdatedMemberships";

            command.Parameters.Add(KandaTableDataGateway._factory.CreateParameter("@name", entity.Name));
            command.Parameters.Add(KandaTableDataGateway._factory.CreateParameter("@password", entity.Password));
            command.Parameters.Add(KandaTableDataGateway._factory.CreateParameter("@enabled", entity.Enabled));
            command.Parameters.Add(KandaTableDataGateway._factory.CreateParameter("@updatedOn", entity.UpdatedOn));

            command.Parameters.Add(KandaTableDataGateway._factory.CreateParameter("@id", entity.ID));

            var affected = command.ExecuteNonQuery();

            return affected;
        }
    }
}
