using System.Security;

namespace kkkkkkaaaaaa.Security
{
    public static partial class KandaSecureString
    {
        public static SecureString AppendChars(this SecureString secureString, string s)
        {
            foreach (var c in s) { secureString.AppendChar(c); }

            return secureString;
        }
    }
}