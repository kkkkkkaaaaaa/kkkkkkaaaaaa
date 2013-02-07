using System.Text;
using Xunit;
using kkkkkkaaaaaa.Security.Cryptography;

namespace kkkkkkaaaaaa.Xunit.Security.Cryptgraphy
{
    public class KandaRijndaelManagedFacts
    {
        [Fact()]
        public void EncryptFact()
        {
            var key = default(byte[]);
            var iv= default(byte[]);
            var encrypted = KandaRijndaelManaged.Encrypt(@"a", out key, out iv);

            var decrypted = Encoding.Unicode.GetString(encrypted);
            Assert.NotEmpty(decrypted);
        }

        [Fact()]
        public void DecryptFact()
        {
            const string PLAIN_TEXT = @"a";

            var key = default(byte[]);
            var iv = default(byte[]);
            var encrypted = KandaRijndaelManaged.Encrypt(PLAIN_TEXT, out key, out iv);

            var plainText = KandaRijndaelManaged.Decrypt(encrypted, key, iv);

            Assert.Equal(PLAIN_TEXT, plainText);
        }
    }
}