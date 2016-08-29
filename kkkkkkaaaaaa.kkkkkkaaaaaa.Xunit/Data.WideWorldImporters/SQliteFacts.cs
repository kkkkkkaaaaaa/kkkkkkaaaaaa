using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kkkkkkaaaaaa.Data.Common;
using Xunit;

namespace kkkkkkaaaaaa.Data.WideWorldImporters
{
    class SQliteFacts : KandaXunitProviderFactory
    {
        [Fact()]
        public void Fact()
        {
            var schema = connection.GetTablesSchema();
            var reader = new DataTableReader(schema);

            var tables = KandaDbDataMapper.MapToEnumerable(reader);

            //return tables;
        }
    }
}
