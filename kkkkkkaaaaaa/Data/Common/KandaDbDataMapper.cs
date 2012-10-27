using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;

namespace kkkkkkaaaaaa.Data.Common
{
    public class KandaDbDataMapper : KandaDataMapper
    {
        public static void MapToObject(DbDataReader reader, object obj)
        {
            var type = obj.GetType();
            if (obj == null) { throw new ArgumentNullException(string.Format(@"KandaDbDataMapper.MapToObject<{0}>()", type.FullName)); }

            var schema = reader.GetSchemaTable();

            var members = new List<MemberInfo>();
            members.AddRange(type.GetProperties((BindingFlags.Instance | BindingFlags.Public)));
            members.AddRange(type.GetFields((BindingFlags.Instance | BindingFlags.Public)));

            foreach (var member in members)
            {
                foreach (DataRow row in schema.Rows)
                {
                    var name = (string)row[@"ColumnName"];
                    var value = reader[name];

                    var attributes = (KandaMappingAttribute[])member.GetCustomAttributes(typeof(KandaMappingAttribute), true);
                    if (attributes.Length > 1) { throw new Exception(string.Format(@"KandaDbDataMapper.MapToObject<{0}>()", type.FullName)); }
                    foreach (var attribute in attributes)
                    {
                        if (attribute.Ignore) { break; } // 無視
                        if (attribute.MappingName != name) { continue; } // マッピング一致なし

                        KandaDataMapper.SetValue(member, obj, value);
                        break;
                    }

                    if (0 < attributes.Length) { continue; } // MappingAttribute あり
                    if (member.Name != name) { continue; } // メンバー名一致なし

                    KandaDataMapper.SetValue(member, obj, value);
                    break;
                }
            }
        }

        public static T MapToObject<T>(DbDataReader reader) where T : new()
        {
            var obj = new T();

            KandaDbDataMapper.MapToObject(reader, obj);

            return obj;
        }

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

        public static IEnumerable<T> MapToEnumerable<T>(DbDataReader reader) where T : new()
        {
            return KandaDbDataMapper.MapToCollection<T>(reader);
        }

        public static void MapToParameters(DbCommand command, object obj)
        {
            if (obj == null) { throw new ArgumentNullException(string.Format(@"KandaDbDataMapper.MapToParameters()")); }

            var type = obj.GetType();

            var members = new List<MemberInfo>();
            members.AddRange(type.GetProperties((BindingFlags.Instance | BindingFlags.Public)));
            members.AddRange(type.GetFields((BindingFlags.Instance | BindingFlags.Public)));

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
                    parameter.Value = ((parameter.Direction == ParameterDirection.Input) ? KandaDataMapper.GetValue(member, obj, DBNull.Value) : attribute.DefaultValue);

                    command.Parameters.Add(parameter);
                }
            }
        }

        public static void MapToParameters(KandaDbDataReader reader, object obj)
        {
            KandaDbDataMapper.MapToParameters(reader.InnerCommand, obj);
        }
    }
}