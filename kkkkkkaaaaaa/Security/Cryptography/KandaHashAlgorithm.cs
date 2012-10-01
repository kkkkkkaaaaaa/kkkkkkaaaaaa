using System;
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
        /// 
        /// </summary>
        /// <param name="hashName"></param>
        /// <param name="s"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ComputeHash(string hashName, string s, Encoding encoding)
        {
            var algorithm = HashAlgorithm.Create(hashName);
            var buffer = encoding.GetBytes(s);
            var hash = algorithm.ComputeHash(buffer, 0, buffer.Length);

            return Convert.ToString(hash);
        }
    }
}