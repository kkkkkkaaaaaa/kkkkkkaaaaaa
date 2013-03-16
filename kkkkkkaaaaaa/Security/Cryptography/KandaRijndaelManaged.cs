using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace kkkkkkaaaaaa.Security.Cryptography
{
    public class KandaRijndaelManaged : KandaSymmetricAlgorithm
    {
        public static byte[] Encrypt(string plainText, out byte[] key, out byte[] iv)
        {
            var stream = default(MemoryStream);
            var crypto = default(CryptoStream);

            try
            {
                stream = new MemoryStream();
                crypto = KandaSymmetricAlgorithm.Encrypt(KandaRijndaelManaged.AlgName, plainText, KandaSymmetricAlgorithm._encoding, stream, out key, out iv);

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
            return KandaSymmetricAlgorithm.Decrypt(KandaRijndaelManaged.AlgName, encrypted, KandaSymmetricAlgorithm._encoding, key, iv);
        }

        #region Private members...

        /// <summary></summary>
        private readonly static string AlgName = typeof(RijndaelManaged).FullName;

        #endregion
    }
}
