using System.Data.Common;
using Xunit;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.Data.TableDataGateways;

namespace kkkkkkaaaaaa.Xunit.Database
{
    public class NewLineFacts
    {
        [Fact()]
        public void NewLineFact()
        {
            var connection = default(DbConnection);

            try
            {
                connection = KandaProviderFactory.Instance.CreateConnection();
                connection.Open();

                var nl = default(string);

                nl = KandaTableDataGateway.NewLine(connection);
                Assert.Equal(2, nl.Length);

                nl = KandaTableDataGateway.NewLine(-1, connection);
                Assert.Equal(0, nl.Length);

                nl = KandaTableDataGateway.NewLine(0, connection);
                Assert.Equal(0, nl.Length);

                nl = KandaTableDataGateway.NewLine(1, connection);
                Assert.Equal(2, nl.Length);

                nl = KandaTableDataGateway.NewLine(2, connection);
                Assert.Equal(4, nl.Length);

                nl = KandaTableDataGateway.NewLine(3, connection);
                Assert.Equal(6, nl.Length);
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }

        public void NLFact()
        {

        }
    }
}