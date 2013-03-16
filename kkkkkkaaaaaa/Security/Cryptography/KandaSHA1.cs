using System.Security.Cryptography;
using System.Text;

namespace kkkkkkaaaaaa.Security.Cryptography
{
    public class KandaSHA1
    {
        public static string ComputeHash(string s, Encoding encoding)
        {
            return KandaHashAlgorithm.ComputeHash(typeof(SHA1Managed).FullName, s, encoding);
        }
    }
}