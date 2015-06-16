using System.Data;
using System.Data.Common;

namespace kkkkkkaaaaaa.Data.Common
{
    public static class KandaDbConnection
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static DataTable GetMetaDataCollectionsSchema(this DbConnection connection)
        {
            return connection.GetSchema(DbMetaDataCollectionNames.MetaDataCollections);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static DataTable GetDataTypesSchema(this DbConnection connection)
        {
            return connection.GetSchema(DbMetaDataCollectionNames.DataTypes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static DataTable GetRestrictionsSchema(this DbConnection connection)
        {
            return connection.GetSchema(DbMetaDataCollectionNames.Restrictions);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static DataTable GetReservedWordsSchema(this DbConnection connection)
        {
            return connection.GetSchema(DbMetaDataCollectionNames.ReservedWords);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static DataTable GetTablesSchema(this DbConnection connection)
        {
            return connection.GetSchema(@"Tables");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static DataTable GetColumnsSchema(this DbConnection connection)
        {
            return connection.GetSchema(@"Columns");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static DataTable GetIndexesSchema(this DbConnection connection)
        {
            return connection.GetSchema(@"Indexes");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static DataTable GetProceduresSchema(this DbConnection connection)
        {
            return connection.GetSchema(@"Procedures");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static DataTable GetProcedureParametersSchema(this DbConnection connection)
        {
            return connection.GetSchema(@"ProcedureParameters");
        }
    }
}
