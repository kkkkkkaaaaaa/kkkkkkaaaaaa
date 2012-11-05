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
        /// <param name="criteria"></param>
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
            var created = UserHistoryAttributesGateway.InsertSelect(new UserHistoryAttributeEntity() { UserID = userId, Revision = revision, }, connection, transaction);

            return created;
        }


        /// <summary>
        /// コンストラクター。
        /// </summary>
        internal UserHistoryAttributesRepository()
        {
            this.DoNothing();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        internal bool Delete(long userId, DbConnection connection, DbTransaction transaction)
        {
            var deleted = UserHistoryAttributesGateway.Delete(new UserHistoryAttributesCriteria() { UserID = userId, }, connection, transaction);

            return (0 <= deleted);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        internal bool Truncate(DbConnection connection, DbTransaction transaction)
        {
            var error = UserHistoryAttributesGateway.Truncate(connection, transaction);

            return (error == 0);
        }
    }
}