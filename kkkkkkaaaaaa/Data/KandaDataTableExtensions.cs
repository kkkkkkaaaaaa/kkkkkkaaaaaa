using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace kkkkkkaaaaaa.Data
{
    /// <summary>
    /// 
    /// </summary>
    public static class KandaDataTableExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static IEnumerable<dynamic>  AsDynamic(this DataTable table)
        {
            var dynamic = table.AsEnumerable().Select(row =>
                    {
                        IDictionary<string, object> expando = new ExpandoObject();
                        foreach (DataColumn column in row.Table.Columns)
                        {
                            var value = row[column];

                            if (value == DBNull.Value) { value = null; }
                            expando.Add(column.ColumnName, value);
                        }
                        return (dynamic)expando;
                    });

            return dynamic;
        }

        /*
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static IEnumerable<dynamic>  AsDynamic(this DataTable table)
        {
            return table.AsEnumerable().Select(KandaDataTableExtensions.OnSelector);
        }

        private static dynamic OnSelector(DataRow row)
        {
            IDictionary<string, object> expando = new ExpandoObject();
            foreach (DataColumn column in row.Table.Columns)
            {
                var value = row[column];

                if (value == DBNull.Value)
                {
                    value = null;
                }
                expando.Add(column.ColumnName, value);
            }
            return (dynamic) expando;
        }
         */
    }
}
