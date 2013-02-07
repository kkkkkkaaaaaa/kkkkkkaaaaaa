using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace kkkkkkaaaaaa.Security.Cryptography
{
    public class KandaRijndaelManaged : KandaSymmetricAlgorithm
    {
        /// <summary></summary>
        public const string ALG_NAME = @"System.Security.Cryptography.RijndaelManaged";

        [DebuggerStepThrough()]
        public static byte[] Encrypt(string plainText, out byte[] key, out byte[] iv)
        {
            var stream = default(MemoryStream);
            var crypto = default(CryptoStream);

            try
            {
                stream = new MemoryStream();
                crypto = KandaSymmetricAlgorithm.Encrypt(KandaRijndaelManaged.ALG_NAME, plainText, KandaRijndaelManaged._encoding, stream, out key, out iv);

                return stream.ToArray();
            }
            finally
            {
                if (crypto != null) { crypto.Close(); }
                if (stream != null) { stream.Close(); }
            }
        }

        [DebuggerStepThrough()]
        public static string Decrypt(byte[] encrypted, byte[] key, byte[] iv)
        {
            return KandaRijndaelManaged.Decrypt(KandaRijndaelManaged.ALG_NAME, encrypted, KandaRijndaelManaged._encoding, key, iv);
        }

        #region Protected members...

        /// <summary>
        /// 
        /// </summary>
        /// <param name="algName"></param>
        /// <param name="encrypted"></param>
        /// <param name="encoding"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <returns></returns>
        private static string Decrypt(string algName, byte[] encrypted, Encoding encoding, byte[] key, byte[] iv)
        {
            // 復号
            var stream = default(MemoryStream);
            var crypto = default(CryptoStream);
            var reader = default(StreamReader);

            try
            {
                // 復号化
                var rijndael = SymmetricAlgorithm.Create(algName);
                var transform = rijndael.CreateDecryptor(key, iv);

                stream = new MemoryStream(encrypted);
                crypto = new CryptoStream(stream, transform, CryptoStreamMode.Read);
                reader = new StreamReader(crypto, encoding, false);

                // 平文
                var plainText = reader.ReadToEnd();

                return plainText;

            }
            finally
            {
                if (reader != null) { reader.Close(); }
                if (crypto != null) { crypto.Close(); }
                if (stream != null) { stream.Close(); }
            }
        }

        /// <summary></summary>
        protected readonly static Encoding _encoding = Encoding.Unicode;

        #endregion
    }
}
