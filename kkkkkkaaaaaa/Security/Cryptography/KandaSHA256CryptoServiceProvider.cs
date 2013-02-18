using System;
using System.Security.Cryptography;
using System.Text;

namespace kkkkkkaaaaaa.Security.Cryptography
{
    public static class KandaSHA5126CryptoServiceProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ComputeHash(string s, Encoding encoding)
        {
            var algorithm = HashAlgorithm.Create(typeof (SHA512).FullName);
            var buffer = encoding.GetBytes(s);
            var hash = algorithm.ComputeHash(buffer, 0, buffer.Length);

            return encoding.GetString(hash, 0, hash.Length);
        }
    }
}
