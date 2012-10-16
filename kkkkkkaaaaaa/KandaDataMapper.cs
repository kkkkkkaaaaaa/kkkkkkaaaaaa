using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace kkkkkkaaaaaa
{
    public class KandaDataMapper
    {
        public static T MapToObject<T>(object source) where T : new()
        {
            var target = new T();

            KandaDataMapper.MapToObject(source, target);

            return target;
        }

        public static void MapToObject(object source, object target)
        {
            /*
            var members = new List<MemberInfo>();
            members.AddRange(target.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance));
            members.AddRange(target.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance));

            foreach (var member in members)
            {
                var attributes = member.GetCustomAttributes(typeof (KandaDataMappingAttribute), true);
                foreach (var attribute in attributes)
                {
                    if (member.Name != attribute.Name) { continue; }

                    KandaDataMapper.SetValue(member, target, value);
                    break;
                }

                if ()
            }
            */
        }




        protected IEnumerable<MemberInfo> GetMembers(object obj)
        {
            var type = obj.GetType();

            var members = new List<MemberInfo>();
            members.AddRange(type.GetProperties(BindingFlags.Public | BindingFlags.Instance));
            members.AddRange(type.GetFields(BindingFlags.Public | BindingFlags.Instance));

            return members;
        }

        /*
        public static IEnumerable<TTarget> MapToEnumarable<TSource, TTarget>(IEnumerable<TSource> source)
        {
            return default(IEnumerable<TTarget>);
        }
        */
        #region Protected members...


        protected static object GetValue(MemberInfo member, object obj)
        {
            var value = default(object);

            if (member is PropertyInfo)
            {
                // プロパティ
                value = ((PropertyInfo)member).GetValue(obj, BindingFlags.Default, null, null, null);
            }
            else if (member is FieldInfo)
            {
                // フィールド
                value = ((FieldInfo)member).GetValue(obj);
            }
            else
            {
                throw new ArgumentNullException(string.Format(@"KandaDbDataMapper.MapToParameters()"));
            }
            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="member"></param>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        protected static void SetValue(MemberInfo member, object obj, object value)
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
                throw new Exception(string.Format(@"KandaDataMapper.MapToObject<{0}>()", obj.GetType().FullName));
            }
        }

        #endregion
    }
}
