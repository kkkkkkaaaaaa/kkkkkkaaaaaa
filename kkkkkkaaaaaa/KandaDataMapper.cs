using System;
using System.Collections.Generic;
using System.Reflection;

namespace kkkkkkaaaaaa
{
    public class KandaDataMapper
    {
        public static void MapToObject<T>(object source, T target)
        {

        }

        public static IEnumerable<TTarget> MapToEnumarable<TSource, TTarget>(IEnumerable<TSource> source)
        {
            return default(IEnumerable<TTarget>);
        }

        protected void SetData(MemberInfo member, object obj, object value)
        {
            if (member is PropertyInfo) { ((PropertyInfo)member).SetValue(obj, value , BindingFlags.Default, null, null, null); } // プロパティ
            else if (member is FieldInfo) { ((FieldInfo)member).SetValue(obj, value, BindingFlags.Default, null, null); } // フィールド
            else { throw new Exception(string.Format(@"KandaDataMapper.SetData()")); }
        }
    }
}