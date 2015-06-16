using System.Security;
using kkkkkkaaaaaa.Security;
using Xunit;

namespace kkkkkkaaaaaa.Xunit.Security
{
    public class KandaSecureStringFacts
    {
        [Fact()]
        public void AppendStringFact()
        {
            const string S = @"朧";
            var secureString = new SecureString();
            secureString.AppendString(S);

            var s = secureString.GetString();

            Assert.Equal(S, s);
        }
    }
}