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
        public static void MapToObject<T>(DbDataReader reader, T obj) where T : new()
        {
            if (!reader.Read()) { return; } // レコードなし
            var schema = reader.GetSchemaTable();

            if (obj == null) { obj = new T(); } // インスタンス作成

            var type = typeof (T);
            var members = new List<MemberInfo>();
            members.AddRange(type.GetProperties(BindingFlags.Public));
            members.AddRange(type.GetFields(BindingFlags.Public));

            foreach (var member in members)
            {
                var attributes = (KandaMappingAttribute[]) member.GetCustomAttributes(typeof (KandaMappingAttribute), true);
                foreach (var attribute in attributes)
                //foreach (var attribute in attributes.Where((attribute) => { return !attribute.Ignore; }))
                {
                    if (attribute.Ignore) { continue; }

                    foreach (DataRow row in schema.Rows)
                    {
                        var name = (string) row[@"Name"];

                        if ((member.Name == name) || (attribute.MappingName == name)) { continue; } // 一致なし

                        if (member is PropertyInfo) { ((PropertyInfo) member).SetValue(obj, reader[name], BindingFlags.Default, null, null, null); } // プロパティ
                        else if (member is FieldInfo) { ((FieldInfo) member).SetValue(obj, reader[name], BindingFlags.Default, null, null); } // フィールドｒ
                        else { throw new Exception(string.Format(@"KandaDbDataMapper.MapToObject<{0}>()", type.FullName)); }

                        break;
                    }
                }
            }
        }
    }
}