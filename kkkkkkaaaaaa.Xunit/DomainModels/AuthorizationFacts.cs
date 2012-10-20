using System;
using System.Globalization;
using Xunit;
using kkkkkkaaaaaa.DataTransferObjects;
using kkkkkkaaaaaa.DomainModels;

namespace kkkkkkaaaaaa.Xunit.DomainModels
{
    public class AuthorizationFacts : KandaXunitDomainModelFacts
    {
        [Fact()]
        public void CreateFact()
        {
            var authorization = default(Authorization);

            try
            {
                var name = new Random().Next().ToString(CultureInfo.InvariantCulture);
                authorization = new Authorization(new AuthorizationEntity() { Name = name, });
                authorization.Found += (sender, e) => Assert.True(0 < e.ID);

                authorization.Create();
            }
            finally
            {
                
            }
        }
    }
}