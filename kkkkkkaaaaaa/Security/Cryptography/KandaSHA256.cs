using System.Security.Cryptography;
using System.Text;

namespace kkkkkkaaaaaa.Security.Cryptography
{
    /// <summary>
    /// 
    /// </summary>
    public class KandaSHA256 : KandaHashAlgorithm
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ComputeHash(string s, Encoding encoding)
        {
            return KandaHashAlgorithm.ComputeHash(typeof(SHA256).FullName, s, encoding);
        }
    }
}