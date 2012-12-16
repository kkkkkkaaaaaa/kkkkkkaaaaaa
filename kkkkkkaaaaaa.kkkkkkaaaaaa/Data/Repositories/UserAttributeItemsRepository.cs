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
    public class UserAttributeItemsRepository : KandaRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public UserAttributeItemEntity Find(int id, DbConnection connection, DbTransaction transaction)
        {
            var reader = default(KandaDbDataReader);

            try
            {
                reader = UserAttributeItemsGateway.Select(new UserAttributeItemsCriteria() { ID = id, Enabled = null, }, connection, transaction);
                var found = (reader.Read() ? KandaDbDataMapper.MapToObject<UserAttributeItemEntity>(reader) : UserAttributeItemEntity.Empty);

                return found;
            }
            finally
            {
                if (reader != null) { reader.Close(); }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public IEnumerable<UserAttributeItemEntity> Get(UserAttributeItemsCriteria criteria, DbConnection connection, DbTransaction transaction)
        {
            var reader = default(KandaDbDataReader);

            try
            {
                reader = UserAttributeItemsGateway.Select(criteria, connection, transaction);

                var gotten = KandaDbDataMapper.MapToEnumerable<UserAttributeItemEntity>(reader);

                return gotten;
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
        public bool Create(UserAttributeItemEntity entity, DbConnection connection, DbTransaction transaction)
        {
            var created = UserAttributeItemsGateway.Insert(entity, connection, transaction);

            return (created == 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Update(UserAttributeItemEntity entity, DbConnection connection, DbTransaction transaction)
        {
            var updated = UserAttributeItemsGateway.Update(entity, connection, transaction);

            return (updated == 1);
        }


        /// <summary>
        /// コンストラクター。
        /// </summary>
        internal UserAttributeItemsRepository()
        {
            this.DoNothing();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        internal bool Delete(int id, DbConnection connection, DbTransaction transaction)
        {
            var deleted = UserAttributeItemsGateway.Delete(new UserAttributeItemsCriteria() { ID = id, Enabled = null, }, connection, transaction);

            return (deleted == 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        internal bool Truncate(DbConnection connection, DbTransaction transaction)
        {
            return (UserAttributeItemsGateway.Truncate(connection, transaction) == 0);
        }
    }
}