using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.Data.TableDataGateways;
using kkkkkkaaaaaa.DataTransferObjects;

namespace kkkkkkaaaaaa.Data.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class UserAttributesRepository : KandaRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public ICollection<UserAttributeEntity> Get(long userId, DbConnection connection, DbTransaction transaction)
        {
            var reader = default (DbDataReader);

            try
            {
                reader = UserAttributesGateway.Select(new UserAttributesCriteria() { UserID = userId, }, connection, transaction);

                var attributes = KandaDbDataMapper.MapToCollection<UserAttributeEntity>(reader);

                return attributes;
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
        public bool Create(UserAttributeEntity entity, DbConnection connection, DbTransaction transaction)
        {
            var created = UserAttributesGateway.Insert(entity, connection, transaction);

            return (created == 1);
        }


        /// <summary>
        /// コンストラクター。
        /// </summary>
        internal UserAttributesRepository()
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
            var deleted = UserAttributesGateway.Delete(new UserAttributesCriteria() { UserID = userId, }, connection, transaction);

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
            var error = UserAttributesGateway.Truncate(connection, transaction);

            return (error == 0);
        }
    }
}