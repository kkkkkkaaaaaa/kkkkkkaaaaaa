using System.Collections.Generic;
using System.Linq;
using System.Security;
using Xunit;
using kkkkkkaaaaaa.Security;

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