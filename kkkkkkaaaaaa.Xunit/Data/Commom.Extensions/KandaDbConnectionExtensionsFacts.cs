using kkkkkkaaaaaa.Data.Common.Extensions;
using System.Data.Common;
using Xunit;

namespace kkkkkkaaaaaa.Xunit.Data.Commom.Extensions
{
    public class KandaDbConnectionExtensionsFacts : KandaXunitFacts
    {
        [Fact()]
        public void Fact()
        {
            var connection = default(DbConnection);

            try
            {
                connection = this.Provider.CreateConnection();
                connection?.Open();

                var tables = connection?.GetTablesSchema();

                Assert.NotNull(tables);
                Assert.True(0 < tables?.Rows.Count);
            }
            finally
            {
                connection?.Close();
            }
                
                
        }
    }
}
