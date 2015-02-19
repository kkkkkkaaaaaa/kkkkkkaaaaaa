using System;
using System.Security.Cryptography;
using System.Text;

namespace kkkkkkaaaaaa.Security.Cryptography
{
    /// <summary>
    /// RFC 2898 を表します。
    /// </summary>
    public class KandaRfc2898DeriveBytes
    {
        /// <summary>
        /// パスワードの疑似乱数キーを返します。
        /// </summary>
        /// <param name="password">パスワード。</param>
        /// <param name="salt">ソルト。</param>
        /// <param name="encoding">エンコーディング。</param>
        /// <param name="iterations">繰り返し回数。</param>
        /// <param name="cb">疑似乱数キーバイトの数。</param>
        /// <returns>疑似乱数キーのバイト数。</returns>
        public static string ComputeHash(string password, string salt, Encoding encoding, int iterations, int cb)
        {
            // var saltSize = encoding.GetByteCount(salt);
            var saltBytes = encoding.GetBytes(salt);

            var bytes = KandaRfc2898DeriveBytes.GetBytes(password, saltBytes, iterations, cb);

            var hash = BitConverter.ToString(bytes, 0, bytes.Length).Replace(@"-", @"").ToLowerInvariant();

            return hash;
        }

        /// <summary>
        /// パスワードの疑似乱数キーを返します。
        /// </summary>
        /// <param name="password">パスワード。</param>
        /// <param name="salt">ソルト。</param>
        /// <param name="iterations">ストレッチ回数。</param>
        /// <param name="cb">疑似乱数キーのバイト数。</param>
        /// <returns></returns>
        public static byte[] GetBytes(string password, byte[] salt, int iterations, int cb)
        {
            var rfc2898 = default(Rfc2898DeriveBytes);

            try
            {
                rfc2898 = new Rfc2898DeriveBytes(password, salt, iterations);

                return rfc2898.GetBytes(cb);
            }
            finally
            {
                if (rfc2898 != null) { rfc2898.Reset(); }
            }

        }
    }
}
