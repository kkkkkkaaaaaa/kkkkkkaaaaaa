using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace kkkkkkaaaaaa.Security.Cryptography
{
    /// <summary>
    /// 対称鍵暗号。
    /// </summary>
    public class KandaSymmetricAlgorithm
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="algName"></param>
        /// <param name="plainText"></param>
        /// <param name="encoding"></param>
        /// <param name="stream"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <returns></returns>
        public static CryptoStream Encrypt(string algName, string plainText, Encoding encoding, Stream stream, out byte[] key, out byte[] iv)
        {
            // 平文
            var buffer = encoding.GetBytes(plainText);

            // 暗号
            var rijndael = SymmetricAlgorithm.Create(algName);

            // キー
            var sizes = rijndael.LegalKeySizes;
            foreach (var size in sizes) { rijndael.KeySize = size.MaxSize; }
            rijndael.GenerateKey();
            key = rijndael.Key;

            // IV
            rijndael.GenerateIV();
            iv = rijndael.IV;

            // 暗号化
            var transform = rijndael.CreateEncryptor(key, iv);
            var crypto = new CryptoStream(stream, transform, CryptoStreamMode.Write);
            crypto.Write(buffer, 0, buffer.Length);
            crypto.FlushFinalBlock();

            return crypto;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="algName"></param>
        /// <param name="encrypted"></param>
        /// <param name="encoding"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <returns></returns>
        public static string Decrypt(string algName, byte[] encrypted, Encoding encoding, byte[] key, byte[] iv)
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

        #region Protected members...

        /// <summary>文字エンコーディング。</summary>
        protected readonly static Encoding _encoding = Encoding.Unicode;

        #endregion
    }
}