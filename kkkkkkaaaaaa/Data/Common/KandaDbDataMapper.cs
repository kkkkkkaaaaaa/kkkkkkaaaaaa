using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Reflection;

namespace kkkkkkaaaaaa.Data.Common
{
    public class KandaDbDataMapper : KandaDataMapper
    {
        public static void MapToObject<T>(DbDataReader reader, T obj) where T : new()
        {
            if (obj == null) { obj = new T(); }


            var type = typeof(T);
            var members = new List<MemberInfo>();
            members.AddRange(type.GetProperties(BindingFlags.Public));
            members.AddRange(type.GetFields(BindingFlags.Public));

            if (!reader.Read()) { return; }
            var schema = reader.GetSchemaTable();
            
            foreach(DataRow row in schema.Rows)
            {
                var name = (string)row[@"Name"];
                foreach (var member in members)
                {
                    var attributes = (KandaMappingAttribute[])member.GetCustomAttributes(typeof (KandaMappingAttribute), true);
                    foreach (var attribute in attributes)
                    {
                        if (attribute.MappingName != name) { continue; }

                        if (member is PropertyInfo)
                        {
                            //((PropertyInfo)member).SetValue(obj, reader[name], null);
                            ((PropertyInfo)member).SetValue(obj, reader[name], BindingFlags.Default, null, null, null);
                        }
                        else if (member is FieldInfo)
                        {
                            //((FieldInfo)member).SetValue(obj, reader[name]);
                            ((FieldInfo)member).SetValue(obj, reader[name], BindingFlags.Default, null, null);
                        }
                        else
                        {
                            throw new Exception(string.Format(@"KandaDbDataMapper.MapToObject<T>()"));
                        }
                        break;
                    }
                }
            }
        }
    }
}