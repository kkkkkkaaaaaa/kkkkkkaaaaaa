using System.Data;
using System.Data.Common;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.Web.DataTransferObjects;

namespace kkkkkkaaaaaa.Web.TableDataGateways
{
    public class MembershipsGateway : KandaTableDataGateway
    {
        public static KandaDbDataReader SelectMemberships(string name, string password, DbConnection connection, DbTransaction transaction)
        {
            var reader = KandaTableDataGateway._factory.CreateReader(connection, transaction);

            reader.Parameters.Add(KandaTableDataGateway._factory.CreateParameter("@name", name));
            reader.Parameters.Add(KandaTableDataGateway._factory.CreateParameter("@password", password));

            reader.CommandText = @"usp_SelectMemberships";

            reader.ExecuteReader();

            return reader;
        }

        public static int InsertMemberships(MembershipEntity entity, DbConnection connection, DbTransaction transaction)
        {
            var command = KandaTableDataGateway._factory.CreateCommand(connection, transaction);

            command.Parameters.Add(KandaTableDataGateway._factory.CreateParameter());
            command.Parameters.Add(KandaTableDataGateway._factory.CreateParameter());
            command.Parameters.Add(KandaTableDataGateway._factory.CreateParameter());
            command.Parameters.Add(KandaTableDataGateway._factory.CreateParameter());

            command.CommandText = @"";

            var affected = command.ExecuteNonQuery();

            return affected;
        }
    }
}