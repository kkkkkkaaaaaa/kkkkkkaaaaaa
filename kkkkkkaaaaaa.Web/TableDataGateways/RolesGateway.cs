using System.Data.Common;

namespace kkkkkkaaaaaa.Web.TableDataGateways
{
    public class RolesGateway : KandaTableDataGateway
    {
        public static int Truncate(DbConnection connection, DbTransaction transaction)
        {
            return KandaTableDataGateway.Truncate(@"Roles", connection, transaction);
        }
    }
}