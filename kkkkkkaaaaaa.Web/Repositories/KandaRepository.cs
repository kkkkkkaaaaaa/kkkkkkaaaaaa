using System;
using System.Data.Common;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.Web.Data;
using kkkkkkaaaaaa.Web.TableDataGateways;

namespace kkkkkkaaaaaa.Web.Repositories
{
    public class KandaRepository
    {
        /// <summary>
        /// �V�X�e���̌��ݎ������擾���܂��B
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public DateTime GetUtcDateTime(DbConnection connection, DbTransaction transaction = null)
        {
            var utc = KandaTableDataGateway.GetUtcDateTime(connection, transaction);

            return utc;
        }

        protected readonly KandaDbProviderFactory _factory = KandaProviderFactory.Instance;
    }
}