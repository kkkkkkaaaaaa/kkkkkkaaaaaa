using System.Data.Common;
using kkkkkkaaaaaa.Web.DataTransferObjects;
using kkkkkkaaaaaa.Web.TableDataGateways;

namespace kkkkkkaaaaaa.Web.Repositories
{
    public class UserHistoriesRepository : KandaRepository
    {
        public bool Create(UserHistoryEntity entity, DbConnection connection, DbTransaction transaction)
        {
            var created = UserHistoriesGateway.Insert(entity, connection, transaction);

            return (created == 1);
        }
    }
}