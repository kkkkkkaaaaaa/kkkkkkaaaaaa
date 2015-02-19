using System.Security.Cryptography;
using System.Text;

namespace kkkkkkaaaaaa.Security.Cryptography
{
    public class KandaSHA256 : KandaHashAlgorithm
    {
         public static string ComputeHash(string s, Encoding encoding)
         {
             return KandaHashAlgorithm.ComputeHash(typeof(SHA256Managed).FullName, s, encoding);
         }
    }
}