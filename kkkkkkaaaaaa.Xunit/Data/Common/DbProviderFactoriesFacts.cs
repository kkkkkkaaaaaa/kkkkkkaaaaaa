using System.Data.Common;
using Xunit;

namespace kkkkkkaaaaaa.Xunit.Data.Common
{
    public class DbProviderFactoriesFacts
    {
        [Fact()]
        public void GetProvidersFact()
        {
            DbProviderFactories.RegisterFactory(@"System.Data.SqlClient.SqlProviderFactory", @"Microsoft.Data.SqlClient");

            var classes = DbProviderFactories.GetFactoryClasses();
            Assert.NotNull(classes);
        }
    }
}