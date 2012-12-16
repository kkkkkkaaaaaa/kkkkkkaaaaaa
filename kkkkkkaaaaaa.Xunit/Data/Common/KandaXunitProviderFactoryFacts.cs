using System.Data;
using Xunit;

namespace kkkkkkaaaaaa.Xunit.Data.Common
{
    public class KandaXunitProviderFactoryFacts : KandaXunitDataFacts
    {
        [Fact()]
        public void CreataConnectionFact()
        {
            var connection = this._factory.CreateConnection();

            try
            {
                connection.Open();
                Assert.Equal(ConnectionState.Open, connection.State);
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }

        [Fact()]
        public void CreateFact()
        {
            var a = this._factory.CreateDataAdapter();
        }
    }
}