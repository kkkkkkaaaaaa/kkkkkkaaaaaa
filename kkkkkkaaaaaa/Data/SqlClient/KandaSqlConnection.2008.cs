using System.Data;
using System.Data.Common;

namespace kkkkkkaaaaaa.Data.SqlClient
{
    public static class KandaSqlConnection
    {
        public static DataTable GetTablesSchema(this DbConnection connection)
        {
            return connection.GetSchema(@"Tables");
        }
    }
}