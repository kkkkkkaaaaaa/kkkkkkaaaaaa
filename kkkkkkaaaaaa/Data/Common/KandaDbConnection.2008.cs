using System.Data;
using System.Data.Common;

namespace kkkkkkaaaaaa.Data.Common
{
    public static class KandaDbConnection
    {
        public static DataTable GetMetaDataCollectionsSchema(this DbConnection connection)
        {
            return connection.GetSchema(@"DataSourceInformation");
        }

        public static DataTable GetDataTypesSchema(this DbConnection connection)
        {
            return connection.GetSchema(@"DataTypes");
        }

        public static DataTable GetRestrictionsSchema(this DbConnection connection)
        {
            return connection.GetSchema(@"Restrictions");
        }

        public static DataTable GetReservedWordsSchema(this DbConnection connection)
        {
            return connection.GetSchema(@"ReservedWords");
        }

        public static DataTable GetTablesSchema(this DbConnection connection)
        {
            return connection.GetSchema(@"Tables");
        }

        public static DataTable GetColumnsSchema(this DbConnection connection)
        {
            return connection.GetSchema(@"Columns");
        }

        public static DataTable GetIndexesSchema(this DbConnection connection)
        {
            return connection.GetSchema(@"Indexes");
        }

        public static DataTable GetProceduresSchema(this DbConnection connection)
        {
            return connection.GetSchema(@"Procedures");
        }

        public static DataTable GetProcedureParametersSchema(this DbConnection connection)
        {
            return connection.GetSchema(@"ProcedureParameters");
        }
    }
}
