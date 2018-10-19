using System;
using System.Data;

namespace kkkkkkaaaaaa.Data
{
    /// <summary>
    /// 
    /// </summary>
    public static class KandaDataReaderExtensions
    {
        /// <summary>
        /// 列に格納されている値が存在しない値または欠損値かどうかを表す値を取得します。
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool IsDBNull(this IDataReader reader, string name)
        {
            var ordinal = reader.GetOrdinal(name);

            return reader.IsDBNull(ordinal);
        }

        /// <summary>
        /// 指定した列の値を String のインスタンスとして取得します。
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetString(this IDataReader reader, string name)
        {
            var ordinal = reader.GetOrdinal(name);

            return reader.GetString(ordinal);
        }

        /// <summary>
        /// 指定した列の値を 64 ビット符号付き整数として取得します。
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static long GetInt64(this IDataReader reader, string name)
        {
            var ordinal = reader.GetOrdinal(name);

            return reader.GetInt64(ordinal);
        }

        /// <summary>
        /// 指定した列の値をブール値として取得します。
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool GetBoolean(this IDataReader reader, string name)
        {
            var ordinal = reader.GetOrdinal(name);

            return reader.GetBoolean(ordinal);
        }

        /// <summary>
        /// 指定した列の値を DateTime オブジェクトとして取得します。
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static DateTime GetDateTime(this IDataReader reader, string name)
        {
            var ordinal = reader.GetOrdinal(name);

            return reader.GetDateTime(ordinal);
        }
    }
}
