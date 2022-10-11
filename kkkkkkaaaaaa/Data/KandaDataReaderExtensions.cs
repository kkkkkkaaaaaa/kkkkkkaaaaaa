using System.Data;
using System.Data.Common;
using System.Dynamic;

namespace kkkkkkaaaaaa.Data
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class KandaDataReaderExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static T AsObject<T>(this DbDataReader reader) where T : new()
        {
            if (reader.Read() == false) { return default(T); }

            var result = new T();
            var members = KandaDataMapper.GetMembers(typeof(T));
            for (var f = 0; f < reader.FieldCount; f++)
            {
                var _ = members
                    .Where(m =>
                    {
                        var name = reader.GetName(f);
                        return name == m.Name;
                    })
                    .Select(m =>
                    {
                        var value = (reader[f] == DBNull.Value)
                            ? null
                            : reader[f];

                        KandaDataMapper.SetValue(m, result, value, value);
                        return m;
                    })
                    .ToArray();
            }


            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static IEnumerable<T> AsObjectEnumerable<T>(this DbDataReader reader) where T : new()
        {
            var result = Enumerable.Empty<T>();
            while (true)
            {
                var item = AsObject<T>(reader);
                if (item == null) { break; }

                result = result.Concat(new[] { item, });
            }

            return result;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static dynamic? AsDynamic(this DbDataReader reader)
        {
            IDictionary<string, object>? result = default(ExpandoObject);

            if (reader.Read() == false) { return result; }

            result = new ExpandoObject()!;
            for (var f = 0; f < reader.FieldCount; f++)
            {
                var name = reader.GetName(f);

                var value  = reader[f];
                if (value is DBNull) { value = null; }

                result.Add(name, value!);
            }

            return result;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static IEnumerable<dynamic> AsDynamicEnumerable(this DbDataReader reader)
        {
            var result = Enumerable.Empty<dynamic>();
            while (true)
            {
                var item = reader.AsDynamic();
                if (item == default(dynamic)) { break; }

                result = result.Concat(new[] { item, });
            }

            return result;
        }

        public static DataTable AsDataTable(this DbDataReader reader)
        {
            var result = KandaDataReaderExtensions.createTable(reader);
            
            while (reader.Read())
            {
                var row = KandaDataReaderExtensions.createRow(result, reader);

                result.Rows.Add(row);
            }

            return result;
        }

        #region Private members...

        #endregion

        /// <summary></summary>
        private static DataTable createTable(DbDataReader reader)
        {
            var table = new DataTable();

            for (var f = 0; f < reader.FieldCount; f++)
            {
                var name = reader.GetName(f);

                var _ = table.Columns.Add(name, reader.GetFieldType(f), @"");
            }

            return table;
        }

        /// <summary></summary>
        private static DataRow createRow(DataTable table, DbDataReader reader)
        {
            var row = table.NewRow();

            row.BeginEdit();
            for (var f = 0; f < reader.FieldCount; f++)
            {
                var name = reader.GetName(f);

                var value = reader[f];
                if (value is DBNull) { value = null; }

                row[name] = value;
            }
            row.EndEdit();

            return row;
        }
    }
}
