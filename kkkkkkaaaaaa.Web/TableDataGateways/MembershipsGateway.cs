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

            reader.Parameters.Add(KandaTableDataGateway._factory.CreateParameter(@"id"));
            reader.Parameters.Add(KandaTableDataGateway._factory.CreateParameter("@name", name));
            reader.Parameters.Add(KandaTableDataGateway._factory.CreateParameter("@password", password));

            reader.ExecuteReader();

            return reader;
        }

        public static KandaDbDataReader Select(long id, DbConnection connection, DbTransaction transaction)
        {
            var reader = KandaTableDataGateway._factory.CreateReader(connection, transaction);

            reader.CommandText = @"usp_SelectMemberships";

            reader.Parameters.Add(KandaTableDataGateway._factory.CreateParameter("@id", id));
            reader.Parameters.Add(KandaTableDataGateway._factory.CreateParameter("@name"));
            reader.Parameters.Add(KandaTableDataGateway._factory.CreateParameter("@password"));

            reader.ExecuteReader();

            return reader;
        }

        public static long SelectNextID(DbConnection connection, DbTransaction transaction)
        {
            var command = KandaTableDataGateway._factory.CreateCommand(connection, transaction);

            command.CommandText = @"usp_SelectNextMembershipID";

            var scalar = command.ExecuteScalar();

            return (long)scalar;
        }

        public static void SetIdentityInsert(bool on, DbConnection connection, DbTransaction transaction)
        {
            KandaTableDataGateway.SetIdentityInsert(@"Memberships", on, connection, transaction);
        }

        public static int Insert(MembershipEntity entity, DbConnection connection, DbTransaction transaction)
        {
            var command = KandaTableDataGateway._factory.CreateCommand(connection, transaction);

            command.CommandText = @"usp_InsertMemberships";

            command.Parameters.Add(KandaTableDataGateway._factory.CreateParameter("@id", entity.ID));
            command.Parameters.Add(KandaTableDataGateway._factory.CreateParameter("@name", entity.Name));
            command.Parameters.Add(KandaTableDataGateway._factory.CreateParameter("@password", entity.Password));
            command.Parameters.Add(KandaTableDataGateway._factory.CreateParameter("@enabled", entity.Enabled));
            command.Parameters.Add(KandaTableDataGateway._factory.CreateParameter("@createdOn", entity.CreatedOn, DbType.DateTime2));

            var affected = command.ExecuteNonQuery();

            return affected;
        }

        public static int Update(MembershipEntity entity, DbConnection connection, DbTransaction transaction)
        {
            var command = KandaTableDataGateway._factory.CreateCommand(connection, transaction);

            command.CommandText = @"usp_UpdateMemberships";

            command.Parameters.Add(KandaTableDataGateway._factory.CreateParameter("@password", entity.Password));
            command.Parameters.Add(KandaTableDataGateway._factory.CreateParameter("@enabled", entity.Enabled));
            //command.Parameters.Add(KandaTableDataGateway._factory.CreateParameter("@updatedOn", entity.UpdatedOn));
            command.Parameters.Add(KandaTableDataGateway._factory.CreateParameter("@updatedOn", entity.UpdatedOn, DbType.DateTime2));

            command.Parameters.Add(KandaTableDataGateway._factory.CreateParameter("@id", entity.ID));

            var affected = command.ExecuteNonQuery();

            return affected;
        }

        internal static int Truncate(DbConnection connection, DbTransaction transaction)
        {
            var command = KandaTableDataGateway._factory.CreateCommand(connection, transaction);

            command.CommandText = @"usp_TruncateMemberships";

            var result = KandaTableDataGateway._factory.CreateParameter("Result", DBNull.Value, ParameterDirection.ReturnValue);
            command.Parameters.Add(result);

            command.ExecuteNonQuery();

            return (int)result.Value;
        }
    }
}
