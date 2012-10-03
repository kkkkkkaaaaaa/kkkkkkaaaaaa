using System.Collections.Generic;
using System.Data.Common;
using kkkkkkaaaaaa.Data.Common;
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

        public bool Truncate(DbConnection connection, DbTransaction transaction)
        {
            var error = KandaTableDataGateway.Truncate(@"UserHistories", connection, transaction);

            return (error == 0);
        }

        public IEnumerable<UserHistoryEntity> Get(UserHistoryEntity entity, DbConnection connection, DbTransaction transaction)
        {
            var reader = UserHistoriesGateway.Select(entity, connection, transaction);

            var entities = KandaDbDataMapper.MapToEnumerable<UserHistoryEntity>(reader);

            return entities;
        }
    }
}