using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace kkkkkkaaaaaa.Security.Cryptography
{
    /// <summary>
    /// 暗号ハッシュアルゴリズム。
    /// </summary>
    public class KandaHashAlgorithm
    {
        /// <summary>
        /// 指定された文字列のハッシュ値を計算します。
        /// </summary>
        /// <param name="hashName"></param>
        /// <param name="s"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static byte[] ComputeHash(string hashName, string s, Encoding encoding)
        {
            var algorithm = HashAlgorithm.Create(hashName);
            var buffer = encoding.GetBytes(s);
            var hash = algorithm.ComputeHash(buffer);

            return hash;
            // return BitConverter.ToString(hash).ToLower().Replace(@"-", @""));
        }
    }
}