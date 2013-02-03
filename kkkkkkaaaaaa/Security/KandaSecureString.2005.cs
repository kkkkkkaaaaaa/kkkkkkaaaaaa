using System.Security;

namespace kkkkkkaaaaaa.Security
{
    public static partial class KandaSecureString
    {
        public static SecureString AppendChars(string s)
        {
            var secureString = new SecureString();
            secureString.AppendChars(s);
            return secureString;
        }
    }
}