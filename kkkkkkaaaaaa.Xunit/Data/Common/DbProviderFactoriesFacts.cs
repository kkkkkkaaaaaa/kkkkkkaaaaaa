using System.Data.Common;
using System.Data.SqlClient;
using Xunit;

namespace kkkkkkaaaaaa.Xunit.Data.Common
{
    public class DbProviderFactoriesFacts
    {
        [Fact()]
        public void GetProvidersFact()
        {
            // DbProviderFactories.RegisterFactory(@"System.Data.SqlClient.SqlClientFactory", SqlClientFactory.Instance);
            DbProviderFactories.RegisterFactory(@"System.Data.SqlClient", SqlClientFactory.Instance);

            var classes = DbProviderFactories.GetFactoryClasses();
            Assert.NotNull(classes);
        }
    }
}