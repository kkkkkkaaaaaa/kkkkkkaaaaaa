using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;

namespace kkkkkkaaaaaa.Data.Common
{
    public class KandaDbDataMapper : KandaDataMapper
    {
        public static void MapToObject<T>(DbDataReader reader, T obj)
        {
            var type = typeof(T);
            if (obj == null) { throw new ArgumentNullException(string.Format(@"KandaDbDataMapper.MapToObject<{0}>()", type.FullName)); }

            if (!reader.Read()) { return; } // レコードなし
            var schema = reader.GetSchemaTable();

            var members = new List<MemberInfo>();
            members.AddRange(type.GetProperties((BindingFlags.Instance | BindingFlags.Public)));
            members.AddRange(type.GetFields((BindingFlags.Instance | BindingFlags.Public)));

            foreach (var member in members)
            {
                foreach (DataRow row in schema.Rows)
                {
                    var name = (string)row[@"ColumnName"];

                    var attributes = (KandaMappingAttribute[])member.GetCustomAttributes(typeof(KandaMappingAttribute), true);
                    if (attributes.Length > 1) { throw new Exception(string.Format(@"KandaDbDataMapper.MapToObject<{0}>()", type.FullName)); }
                    foreach (var attribute in attributes)
                    {
                        if (attribute.Ignore) { break; } // 無視
                        if (attribute.MappingName != name) { continue; } // マッピング一致なし

                        if (member is PropertyInfo) { ((PropertyInfo)member).SetValue(obj, reader[name], BindingFlags.Default, null, null, null); } // プロパティ
                        else if (member is FieldInfo) { ((FieldInfo)member).SetValue(obj, reader[name], BindingFlags.Default, null, null); } // フィールド
                        else { throw new Exception(string.Format(@"KandaDbDataMapper.MapToObject<{0}>()", type.FullName)); }
                        break;
                    }

                    if (attributes.Length > 0) { continue; } // MappingAttribute あり
                    if (member.Name != name) { continue; } // メンバー名一致なし

                    if (member is PropertyInfo) { ((PropertyInfo)member).SetValue(obj, reader[name], BindingFlags.Default, null, null, null); } // プロパティ
                    else if (member is FieldInfo) { ((FieldInfo)member).SetValue(obj, reader[name], BindingFlags.Default, null, null); } // フィールド
                    else { throw new Exception(string.Format(@"KandaDbDataMapper.MapToObject<{0}>()", type.FullName)); }
                    break;
                }
            }
        }

        public static T MapToObject<T>(DbDataReader reader) where T : new()
        {
            var obj = new T();

            KandaDbDataMapper.MapToObject<T>(reader, obj);

            return obj;
        }
    }
}