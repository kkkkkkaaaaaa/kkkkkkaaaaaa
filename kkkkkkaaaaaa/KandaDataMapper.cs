using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa
{
    /// <summary>
    /// 
    /// </summary>
    public partial class KandaDataMapper
    {
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
                var attributes = (KandaMappingAttribute[])t.GetCustomAttributes(typeof(KandaMappingAttribute), true);
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

        #region Protected members...

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected static IEnumerable<MemberInfo> GetMembers(object obj)
        {
            var type = obj.GetType();

            var members = new List<MemberInfo>();
            members.AddRange(type.GetProperties(BindingFlags.Public | BindingFlags.Instance));
            members.AddRange(type.GetFields(BindingFlags.Public | BindingFlags.Instance));

            return members;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="member"></param>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        /// <param name="nullValue"></param>
        protected static void SetValue(MemberInfo member, object obj, object value, object nullValue)
        {
            if (member is PropertyInfo)
            {
                // プロパティ
                ((PropertyInfo)member).SetValue(obj, (value ?? nullValue) , BindingFlags.Default, null, null, null);
            }
            else if (member is FieldInfo)
            {
                // フィールド
                ((FieldInfo)member).SetValue(obj, (value ?? nullValue), BindingFlags.Default, null, null);
            }
            else
            {
                throw new Exception(string.Format(@"KandaDataMapper.MapToObject<{0}>()", obj.GetType().FullName));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="member"></param>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        protected static void SetValue(MemberInfo member, object obj, object value)
        {
            KandaDataMapper.SetValue(member, obj, value, value);
        }

        #endregion
    }
}
