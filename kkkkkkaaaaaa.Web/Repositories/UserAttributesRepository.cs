using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Common;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.Web.DataTransferObjects;
using kkkkkkaaaaaa.Web.TableDataGateways;

namespace kkkkkkaaaaaa.Web.Repositories
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
        public IEnumerable<UserAttributeEntity> Get(long userId, DbConnection connection, DbTransaction transaction)
        {
            var reader = default (DbDataReader);

            try
            {
                reader = UserAttributesGateway.Select(new UserAttributeEntity() { UserID = userId, }, connection, transaction);

                var attribtues = KandaDbDataMapper.MapToEnumerable<UserAttributeEntity>(reader);

                return attribtues;
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
        public bool Register(UserAttributeEntity entity, DbConnection connection, DbTransaction transaction)
        {
            if (UserAttributesGateway.Update(entity, connection, transaction) == 1) { return true; }

            if (UserAttributesGateway.Insert(entity, connection, transaction) == 1) { return true; }

            return false;
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
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Update(UserAttributeEntity entity, DbConnection connection, DbTransaction transaction)
        {
            var updated = UserAttributesGateway.Update(entity, connection, transaction);

            return (updated == 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Truncate(DbConnection connection, DbTransaction transaction)
        {
            var error = UserAttributesGateway.Truncate(connection, transaction);

            return (error == 0);
        }


        /// <summary>
        /// コンストラクター。
        /// </summary>
        internal UserAttributesRepository()
        {
            this.DoNothing();
        }
    }
}