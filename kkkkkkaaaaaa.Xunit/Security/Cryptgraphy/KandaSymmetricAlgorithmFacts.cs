using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Xunit;
using kkkkkkaaaaaa.Security.Cryptography;

namespace kkkkkkaaaaaa.Xunit.Security.Cryptgraphy
{
    public class KandaSymmetricAlgorithmFacts
    {
        [Fact()]
        public void EncryptFact()
        {
            const string PLAIN_TEXT = @"X-Art features beautiful, explicit, HD erotic videos that will absolutely blow your mind! Visit X-Art today for over 100 gorgeous girls-next-door and fresh-faced fashion models getting fucked in HOT, explicit sex scenes... all shot in crystal-clear 1920x1080 Super High Definition Video!";
            var stream = default (Stream);
            var encrypto = default(CryptoStream);

            try
            {
                stream = new MemoryStream();
                byte[] key;
                byte[] iv;
                encrypto = KandaSymmetricAlgorithm.Encrypt(typeof(Rijndael).FullName, PLAIN_TEXT, Encoding.Unicode, stream, out key, out iv);
                //encrypto = KandaSymmetricAlgorithm.Encrypt(KandaRijndaelManaged.ALG_NAME, PLAIN_TEXT, Encoding.Unicode, stream, out key, out iv);
                Assert.True(0 < stream.Length);
            }
            finally
            {
                if (encrypto != null) { encrypto.Close(); }
                if (stream != null) { stream.Close(); }
            }
        }

        [Fact()]
        public void DecryptFact()
        {
            const string PLAIN_TEXT = @"X-Art features beautiful, explicit, HD erotic videos that will absolutely blow your mind! Visit X-Art today for over 100 gorgeous girls-next-door and fresh-faced fashion models getting fucked in HOT, explicit sex scenes... all shot in crystal-clear 1920x1080 Super High Definition Video!";
            var stream = default(MemoryStream);
            var encrypto = default(CryptoStream);

            try
            {
                stream = new MemoryStream();
                byte[] key;
                byte[] iv;
                encrypto = KandaSymmetricAlgorithm.Encrypt(typeof(Rijndael).FullName, PLAIN_TEXT, Encoding.Unicode, stream, out key, out iv);

                var encrypted = stream.ToArray();

                var decrypted = KandaSymmetricAlgorithm.Decrypt(typeof(Rijndael).FullName, encrypted, Encoding.Unicode, key, iv);
                
                Assert.Equal(decrypted, PLAIN_TEXT);
                Assert.True(0 < stream.Length);
            }
            finally
            {
                if (encrypto != null) { encrypto.Close(); }
                if (stream != null) { stream.Close(); }
            }

        }
    }
}