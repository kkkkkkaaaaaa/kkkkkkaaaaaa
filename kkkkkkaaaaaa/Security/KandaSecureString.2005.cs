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

        public static string GetString()
        {
            var source = default(IntPtr);

            try
            {
                source = Marshal.SecureStringToGlobalAllocUnicode(secureString);

                var destination = new char[secureString.Length];
                Marshal.Copy(source, destination, 0, destination.Length);

                return new string(destination);
            }
            finally
            {
                if (source != IntPtr.Zero) { Marshal.ZeroFreeGlobalAllocUnicode(source); }
            }
        }
    }
}
