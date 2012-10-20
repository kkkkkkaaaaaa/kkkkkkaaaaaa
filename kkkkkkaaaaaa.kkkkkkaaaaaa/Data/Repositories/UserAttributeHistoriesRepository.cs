using System.Collections.Generic;
using System.Data.Common;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.Data.TableDataGateways;
using kkkkkkaaaaaa.DataTransferObjects;

namespace kkkkkkaaaaaa.Data.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class UserHistoryAttributesRepository : KandaRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public IEnumerable<UserHistoryAttributeEntity> Get(UserHistoryAttributesCriteria criteria, DbConnection connection, DbTransaction transaction)
        {
            var reader = default(DbDataReader);

            try
            {
                reader = UserHistoryAttributesGateway.Select(criteria, connection, transaction);

                var entities = KandaDbDataMapper.MapToEnumerable<UserHistoryAttributeEntity>(reader);

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
        /// <param name="userId"></param>
        /// <param name="revision"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public int Create(long userId, int revision, DbConnection connection, DbTransaction transaction)
        {
            var created = UserHistoryAttributesGateway.Insert(new UserHistoryAttributeEntity() { UserID = userId, Revision = revision, }, connection, transaction);

            return created;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public int Create(UserHistoryAttributeEntity entity, DbConnection connection, DbTransaction transaction)
        {
            var created = UserHistoryAttributesGateway.Insert(entity, connection, transaction);

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
            var error = UserHistoryAttributesGateway.Truncate(connection, transaction);

            return (error == 0);
        }


        /// <summary>
        /// コンストラクター。
        /// </summary>
        internal UserHistoryAttributesRepository()
        {
            this.DoNothing();
        }
    }
}