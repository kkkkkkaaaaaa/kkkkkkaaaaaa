using System.Reflection;

namespace kkkkkkaaaaaa
{
    /// <summary>
    /// 汎用的な DataMapperを表します。
    /// </summary>
    public partial class KandaDataMapper
    {
        /// <summary>
        /// 指定したメンバーの値を取得して返します。
        /// </summary>
        /// <param name="member">メンバー。</param>
        /// <param name="obj">値を取得するオブジェクト。</param>
        /// <param name="nullValue">null だった場合。</param>
        /// <returns></returns>
        protected static object GetValue(MemberInfo member, object obj, object? nullValue = default(object))
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
                throw new ArgumentNullException(string.Format(@"KandaDbDataMapper.GetValue()"));
            }

            value = (value ?? nullValue);

            return value;
        }
    }
}