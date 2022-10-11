using System.Data.Common;

namespace kkkkkkaaaaaa.Data
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class KandaDataReaderExtensions
    {
        public static T? AsObject<T>(this DbDataReader reader) where T : new()
        {
            if (reader.Read() == false) { return default(T); }

            var result = new T();
            var members = KandaDataMapper.GetMembers(typeof(T));
            for (var f = 0; f < reader.FieldCount; f++)
            {
                var name = reader.GetName(f);
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

        /*
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        public static void MapToObject(object source, object target)
        {
            var sourceMembers = KandaDataMapper.GetMembers(source);
            var targetMembers = KandaDataMapper.GetMembers(target);

            foreach (var t in targetMembers)
            {
                var attributes = (KandaDataMappingAttribute[])t.GetCustomAttributes(typeof(KandaDataMappingAttribute), true);
                foreach (var s in sourceMembers)
                {
                    var value = KandaDataMapper.GetValue(s, source);
                    foreach (var attribute in attributes)
                    {
                        if (s.Name != attribute.MappingName) { continue; }

                        KandaDataMapper.SetValue(t, target, value);
                        break;
                    }

                    if (attributes.Any()) { continue; }
                    if (s.Name != t.Name) { continue; }

                    KandaDataMapper.SetValue(t, target, value);
                    break;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T MapToObject<T>(object source) where T : new()
        {
            var target = new T();

            KandaDataMapper.MapToObject(source, target);

            return target;
        }
        */
    }
}
