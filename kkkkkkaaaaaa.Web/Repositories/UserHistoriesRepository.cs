using System.Collections.Generic;
using System.Data.Common;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.Web.DataTransferObjects;
using kkkkkkaaaaaa.Web.TableDataGateways;

namespace kkkkkkaaaaaa.Web.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class UserHistoriesRepository : KandaRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public IEnumerable<UserHistoryEntity> Get(UserHistoryEntity entity, DbConnection connection, DbTransaction transaction)
        {
            var reader = default(DbDataReader);
            try
            {
                reader = UserHistoriesGateway.Select(entity, connection, transaction);

                var entities = KandaDbDataMapper.MapToEnumerable<UserHistoryEntity>(reader);

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
        public bool Create(UserHistoryEntity entity, DbConnection connection, DbTransaction transaction)
        {
            var created = UserHistoriesGateway.Insert(entity, connection, transaction);

            return (created == 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Truncate(DbConnection connection, DbTransaction transaction)
        {
            var error = UserHistoriesGateway.Truncate(connection, transaction);

            return (error == 0);
        }


        /// <summary>
        /// コンストラクター。
        /// </summary>
        internal UserHistoriesRepository()
        {
            this.DoNothing();
        }
    }
}