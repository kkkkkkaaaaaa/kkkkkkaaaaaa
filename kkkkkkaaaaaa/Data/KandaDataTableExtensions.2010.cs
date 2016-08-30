using System;
using System.Data;
using System.Collections.Generic;
using System.Dynamic;

namespace kkkkkkaaaaaa.Data
{
    /// <summary>
    /// 
    /// </summary>
    public static class KandaDataTableExtensions
    {
        /// <summary>
        /// DataTableの各RowをExpandoObjectに変換します。
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static dynamic AsDynamic(this DataTable table)
        {
            // return table.AsEnumerable()
            var dynamic = table.AsEnumerable()
                .Select(row =>
                {
                    IDictionary<string, object> expando = new ExpandoObject();
                    foreach (DataColumn column in row.Table.Columns)
                    {
                        var value = row[column];

                        if (value is DBNull) { value = null; }
                        expando.Add(column.ColumnName, value);
                    }
                    return (dynamic) expando;
                });

            return dynamic;
        }
    }
}
