using System.Security.Cryptography;
using System.Text;

namespace kkkkkkaaaaaa.Security.Cryptography
{
    public class KandaSHA512 : KandaHashAlgorithm
    {
         public static string ComputeHash(string s, Encoding encoding)
         {
             return KandaHashAlgorithm.ComputeHash(typeof(SHA512Managed).FullName, s, encoding);
         }
    }
}