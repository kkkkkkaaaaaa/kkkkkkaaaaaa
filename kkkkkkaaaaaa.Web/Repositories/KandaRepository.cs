using System;
using System.Data.Common;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.Web.Data;
using kkkkkkaaaaaa.Web.TableDataGateways;

namespace kkkkkkaaaaaa.Web.Repositories
{
    public class KandaRepository
    {
        public DateTime GetUtcDateTime(DbConnection connection, DbTransaction transaction)
        {
            var utc = KandaTableDataGateway.GetUtcDateTime(connection, transaction);

            return utc;
        }

        protected readonly KandaDbProviderFactory _factory = KandaProviderFactory.Instance;
    }
}