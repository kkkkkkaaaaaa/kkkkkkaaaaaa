﻿using System;
using System.Reflection;

namespace kkkkkkaaaaaa
{
	public partial class KandaDataMapper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="member"></param>
        /// <param name="obj"></param>
        /// <param name="nullValue"></param>
        /// <returns></returns>
        protected static object GetValue(MemberInfo member, object obj, object nullValue)
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
                throw new ArgumentNullException(string.Format(@"KandaDbDataMapper.GetValue()"));
            }

            value = (value ?? nullValue);

            return value;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="member"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected static object GetValue(MemberInfo member, object obj)
        {
            return KandaDataMapper.GetValue(member, obj, default(object));
        }
    }
}