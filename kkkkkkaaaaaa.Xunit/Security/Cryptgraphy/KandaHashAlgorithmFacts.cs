using System.Security.Cryptography;
using System.Text;
using kkkkkkaaaaaa.Security.Cryptography;
using Xunit;

namespace kkkkkkaaaaaa.Xunit.Security.Cryptgraphy
{
    public class KandaHashAlgorithmFacts
    {
        [Fact()]
        public void ComputeHashFact()
        {
            var hash = KandaHashAlgorithm.ComputeHash(typeof (SHA256).FullName, @"s", Encoding.Default);
        }

    }
}