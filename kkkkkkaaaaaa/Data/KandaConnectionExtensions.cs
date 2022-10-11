using System.Data;
using System.Data.Common;

namespace kkkkkkaaaaaa.Data.Common.Extensions
{
    public static partial class KandaConnectionExtensions
    {
        /// <summary>
        /// https://learn.microsoft.com/ja-jp/dotnet/framework/data/adonet/getschema-and-schema-collections
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static DataTable GetTablesSchema(this DbConnection connection)
        {
            return connection.GetSchema(KandaMetaDataCollectionNames.Tables);
        }
    }
}