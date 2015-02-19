using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using kkkkkkaaaaaa.Security.Cryptography;
using Xunit;

namespace kkkkkkaaaaaa.Xunit.Security.Cryptgraphy
{
    public class KandaRfc2898DeriveBytesFacts
    {
        [Fact()]
        public void ComputeHashFact()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var salt = new byte[8];
                rng.GetBytes(salt);

                var hash1 = KandaRfc2898DeriveBytes.ComputeHash(@"password", BitConverter.ToString(salt), new UTF8Encoding(false), 1001, 64);
                var hash2 = KandaRfc2898DeriveBytes.ComputeHash(@"password", BitConverter.ToString(salt), new UTF8Encoding(false), 1001, 64);

                Assert.Equal(hash1, hash2);
            }
        }
    }
}