using System.Data.Common;
using System.Data.SqlClient;
using kkkkkkaaaaaa.Data;
using kkkkkkaaaaaa.Data.Common.Extensions;
using Xunit;

namespace kkkkkkaaaaaa.Xunit.Data
{
    public class KandaDataTableExtensionsFacts : KandaXunitFacts
    {
        /// <summary>
        /// 静的コンストラクター。
        /// </summary>
        static KandaDataTableExtensionsFacts()
        {
            DbProviderFactories.RegisterFactory(@"System.Data.SqlClient", SqlClientFactory.Instance);
        }

        [Fact()]
        public void AsDynamicFact()
        {
            var connection = this._factory.CreateConnection();

            try
            {
                connection.Open();

                var schema = connection.GetTablesSchema();
                var d = schema.AsDynamic();
            }
	        finally
	        {
                if (connection != null) { connection.Close(); }
	        }
        }

        #region Private members...

        /// <summary></summary>
        private readonly KandaXunitProviderFactory _factory = KandaXunitProviderFactory.Instance;

        #endregion
    }
}
