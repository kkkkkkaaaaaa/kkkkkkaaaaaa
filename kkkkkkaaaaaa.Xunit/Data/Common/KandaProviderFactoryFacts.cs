using System;
using System.Data;
using System.Data.Common;
using Xunit;

namespace kkkkkkaaaaaa.Xunit.Data.Common
{
    public class KandaProviderFactoryFacts : KandaDbXunitFacts
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