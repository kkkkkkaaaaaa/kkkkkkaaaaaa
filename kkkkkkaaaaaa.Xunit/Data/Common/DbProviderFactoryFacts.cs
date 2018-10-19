using System.Data;
using System.Data.Common;
using Xunit;

namespace kkkkkkaaaaaa.Xunit.Data.Common
{
    public class DbProviderFactoryFacts
    {
        [Fact(Skip="")]
        public void OpenMicrosoftAceOleDb120ProviderFact()
        {
            var factory = DbProviderFactories.GetFactory(@"System.Data.OleDb");
            
            var builder = factory.CreateConnectionStringBuilder();
            builder.Add(@"Provider", @"Microsoft.ACE.OLEDB.12.0");
            builder.Add(@"Data Source", @"C:\Users\lalupin4\Desktop");
            builder.Add(@"Extended Properties", @"Text;HDR=Yes");

            var connection = factory.CreateConnection();
            connection.ConnectionString = builder.ConnectionString;

            try
            {
                connection = factory.CreateConnection();
                connection.ConnectionString = builder.ConnectionString;
                connection.Open();

                Assert.Equal(ConnectionState.Open, connection.State);
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }

            // ;
        }

    }
}