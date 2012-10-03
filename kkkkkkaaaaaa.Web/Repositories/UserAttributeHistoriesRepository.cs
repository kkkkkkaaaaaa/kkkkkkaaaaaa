using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.Web.DataTransferObjects;
using kkkkkkaaaaaa.Web.TableDataGateways;

namespace kkkkkkaaaaaa.Web.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class UserAttributeHistoriesRepository : KandaRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public IEnumerable<UserAttributeHistoryEntity> Get(UserAttributeHistoryEntity entity, DbConnection connection, DbTransaction transaction)
        {
            var reader = default(DbDataReader);

            try
            {
                reader = UserAttributeHistoriesGateway.Select(entity, connection, transaction);

                var entities = KandaDbDataMapper.MapToEnumerable<UserAttributeHistoryEntity>(reader);

                return entities;
            }
            finally
            {
                if (reader != null) { reader.Close(); }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public int Create(UserAttributeHistoryEntity entity, DbConnection connection, DbTransaction transaction)
        {
            var created = UserAttributeHistoriesGateway.Insert(entity, connection, transaction);

            return created;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Truncate(DbConnection connection, DbTransaction transaction)
        {
            var error = UserAttributeHistoriesGateway.Truncate(connection, transaction);

            return (error == 0);
        }
    }
}