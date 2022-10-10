using System.Data;
using System.Dynamic;

namespace kkkkkkaaaaaa.Data
{
    /// <summary>
    /// Syatem.Data.DataTable に拡張メソッドを提供します。
    /// </summary>
    public static class KandaDataTableExtensions
    {
        /// <summary>
        /// DataTable の各 Row を ExpandoObject に変換します。
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static dynamic AsDynamic(this DataTable table)
        {
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
                    return (dynamic)expando;
                });

            return dynamic;
        }
    }
}
