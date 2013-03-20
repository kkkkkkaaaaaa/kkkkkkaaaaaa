using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace kkkkkkaaaaaa.Security
{
    public static partial class KandaSecureString
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="secureString"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static SecureString AppendString(this SecureString secureString, string s)
        {
            foreach (var c in s) { secureString.AppendChar(c); }

            return secureString;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="secureString"></param>
        /// <returns></returns>
        public static string GetString(this SecureString secureString)
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