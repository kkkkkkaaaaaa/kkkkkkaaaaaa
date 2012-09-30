using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

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

        #region Protected members...

        /// <summary>
        /// 
        /// </summary>
        /// <param name="member"></param>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        protected static void SetValue(_MemberInfo member, object obj, object value)
        {
            if (member is PropertyInfo)
            {
                // プロパティ
                ((PropertyInfo)member).SetValue(obj, value, BindingFlags.Default, null, null, null);
            }
            else if (member is FieldInfo)
            {
                // フィールド
                ((FieldInfo)member).SetValue(obj, value, BindingFlags.Default, null, null);
            }
            else
            {
                throw new Exception(string.Format(@"KandaDbDataMapper.MapToObject<{0}>()", obj.GetType().FullName));
            }
        }

        #endregion

        protected static object GetValue(MemberInfo member, object obj)
        {
            var value = default(object);

            if (member is PropertyInfo)
            {
                // プロパティ
                value = ((PropertyInfo) member).GetValue(obj, BindingFlags.Default, null, null, null);
            }
            else if (member is FieldInfo)
            {
                // フィールド
                value = ((FieldInfo) member).GetValue(obj);
            }
            else
            {
                throw new ArgumentNullException(string.Format(@"KandaDbDataMapper.MapToParameters()"));
            }
            return value;
        }
    }
}
