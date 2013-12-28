using System.Data.Common;
using Xunit;

namespace kkkkkkaaaaaa.Xunit.Data
{
    public class KandaXunitProviderFactoryFacts
    {
        [Fact()]
        public void CreateConectionFact()
        {
            var connection = default(DbConnection);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                Assert.True(true);
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }

        /// <summary></summary>
        private readonly DbProviderFactory _factory = new KandaXunitProviderFactory();
    }
}
