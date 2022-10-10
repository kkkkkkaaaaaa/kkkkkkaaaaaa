using System.Data.Common;
using System.Data.SqlClient;
using Xunit;

namespace kkkkkkaaaaaa.Xunit.Data
{
    public class KandaXunitProviderFactoryFacts : KandaXunitFacts
    {
        static KandaXunitProviderFactoryFacts()
        {
            DbProviderFactories.RegisterFactory(@"System.Data.SqlClient", SqlClientFactory.Instance);
        }


        [Fact()]
        public void CreateConectionFact()
        {
            var connection = default(DbConnection);

            try
            {
                connection = this.Provider.CreateConnection();
                connection.Open();

                Assert.True(true);
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }
    }
}
