using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Reflection;

namespace kkkkkkaaaaaa.Data.Common
{
    /// <summary>
    /// 
    /// </summary>
    public partial class KandaDbDataMapper : KandaDataMapper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="obj"></param>
        public static void MapToObject(DbDataReader reader, object obj)
        {
            if (obj == null) { throw new ArgumentNullException(@"KandaDbDataMapper.MapToObject(reader, null)"); }

            var type = obj.GetType();

            var schema = reader.GetSchemaTable();

            var members = new List<MemberInfo>();
            members.AddRange(type.GetProperties(BindingFlags.Instance | BindingFlags.Public));
            members.AddRange(type.GetFields(BindingFlags.Instance | BindingFlags.Public));

            foreach (var member in members)
            {
                var attributes = (KandaDataMappingAttribute[])member.GetCustomAttributes(typeof(KandaDataMappingAttribute), true);
                if (1 < attributes.Length) { throw new Exception(string.Format(@"KandaDbDataMapper.MapToObject<{0}>()", type.FullName)); }

                foreach (DataRow row in schema.Rows)
                {
                    var name = (string)row[@"ColumnName"];
                    var value = reader[name];

                    foreach (var attribute in attributes)
                    {
                        if (attribute.Ignore) { break; } // 無視
                        if (attribute.MappingName != name) { continue; } // マッピング一致なし

                        value = ((value is DBNull) ? attribute.DefaultValue : value);
                        KandaDataMapper.SetValue(member, obj, value);
                        break;
                    }

                    if (0 < attributes.Length) { continue; } // MappingAttribute あり
                    if (member.Name != name) { continue; } // メンバー名一致なし

                    value = ((value is DBNull) ? null : value);
                    KandaDataMapper.SetValue(member, obj, value);
                    break;
                }
            }
        }

        /// <summary></summary>
        [DebuggerStepThrough()]
        public static T MapToObject<T>(DbDataReader reader) where T : new()
        {
            var obj = new T();

            KandaDbDataMapper.MapToObject(reader, obj);

            return obj;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static ICollection<T> MapToCollection<T>(DbDataReader reader) where T : new()
        {
            var collection = new Collection<T>();

            while(reader.Read())
            {
                var item = KandaDbDataMapper.MapToObject<T>(reader);

                collection.Add(item);
            }

            return collection;

        }

        /// <summary></summary>
        [DebuggerStepThrough()]
        public static IEnumerable<T> MapToEnumerable<T>(DbDataReader reader) where T : new()
        {
            return KandaDbDataMapper.MapToCollection<T>(reader);
        }

        /// <summary></summary>
        [DebuggerStepThrough()]
        public static IEnumerable<T> MapToEnumerable<T>(DataTable table) where T : new()
        {
            var reader = default(DbDataReader);

            try
            {
                reader = new DataTableReader(table);

                return KandaDbDataMapper.MapToEnumerable<T>(reader);
            }
            finally
            {
                if (reader != null) { reader.Close(); }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="obj"></param>
        public static void MapToParameters(DbCommand command, object obj)
        {
            if (obj == null) { throw new ArgumentNullException(string.Format(@"KandaDbDataMapper.MapToParameters()")); }

            var type = obj.GetType();

            var members = new List<MemberInfo>();
            members.AddRange(type.GetProperties(BindingFlags.Instance | BindingFlags.Public));
            members.AddRange(type.GetFields(BindingFlags.Instance | BindingFlags.Public));

            foreach (var member in members)
            {
                var attributes = (KandaDbParameterMappingAttribute[])member.GetCustomAttributes(typeof(KandaDbParameterMappingAttribute), true);
                if (1 < attributes.Length) { throw new Exception(string.Format(@"KandaDbDataMapper.MapToParameters()")); }
                
                foreach (KandaDbParameterMappingAttribute attribute in attributes)
                {
                    if (attribute.Ignore) { continue; }
                    var m = member.GetType();
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = attribute.MappingName;
                    parameter.DbType = attribute.DbType;
                    parameter.Direction = attribute.Direction;
                    //parameter.IsNullable = attribute.IsNullable;
                    //parameter.Value = ((parameter.Direction == ParameterDirection.Input) ? KandaDataMapper.GetValue(member, obj, DBNull.Value) : attribute.DefaultValue);
                    parameter.Value = KandaDataMapper.GetValue(member, obj, attribute.DefaultValue);

                    command.Parameters.Add(parameter);
                }
            }
        }

        /// <summary></summary>
        [DebuggerStepThrough()]
        public static void MapToParameters(KandaDbDataReader reader, object obj)
        {
            KandaDbDataMapper.MapToParameters(reader.InnerCommand, obj);
        }
    }
}