using System;
using System.Linq;
using System.Data;
using System.Data.Common;
using kkkkkkaaaaaa.Data;
using kkkkkkaaaaaa.Data.Common;
using Xunit;

namespace kkkkkkaaaaaa.Xunit.Data
{
    public class KandaDataTableExtensionsFacts
    {
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
