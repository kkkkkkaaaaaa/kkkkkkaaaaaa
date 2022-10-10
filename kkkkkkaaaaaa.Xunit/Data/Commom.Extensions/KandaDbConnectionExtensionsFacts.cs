using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kkkkkkaaaaaa.Data.Common.Extensions;
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

                ;
            }
            finally
            {
                connection?.Close();
            }
                
                
        }
    }
}
