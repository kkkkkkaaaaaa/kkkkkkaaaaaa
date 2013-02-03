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
            var secure = new SecureString();
            secure.AppendChars(@"a");
        }
    }
}