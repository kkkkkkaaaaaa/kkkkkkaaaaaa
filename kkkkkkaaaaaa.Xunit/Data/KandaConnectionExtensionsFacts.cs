using kkkkkkaaaaaa.Data.Common.Extensions;
using System.Data.Common;
using Xunit;

namespace kkkkkkaaaaaa.Xunit.Data
{
    /// <summary></summary>
    public class KandaConnectionExtensionsFacts : KandaXunitFacts
    {
        /// <summary></summary>
        [Fact()]
        public void Fact()
        {
            var connection = default(DbConnection);

            try
            {
                connection = Provider.CreateConnection();
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

