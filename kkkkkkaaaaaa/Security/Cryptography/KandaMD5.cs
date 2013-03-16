using System.Security.Cryptography;
using System.Text;

namespace kkkkkkaaaaaa.Security.Cryptography
{
    public class KandaMD5 : KandaHashAlgorithm
    {
        public static string ComputeHash(string s, Encoding encoding)
        {
            return KandaHashAlgorithm.ComputeHash(typeof(MD5CryptoServiceProvider).FullName, s, encoding);
        }
    }
}