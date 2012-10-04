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
    public class UserAttributeItemsRepository : KandaRepository
    {
        public IEnumerable<UserAttributeItemEntity> Get(UserAttributeItemEntity entity, DbConnection connection, DbTransaction transaction)
        {
            var reader = default(DbDataReader);

            try
            {
                reader = UserAttributeItemsGateway.Select(entity, connection, transaction);

                var entities = KandaDbDataMapper.MapToEnumerable<UserAttributeItemEntity>(reader);

                return entities;
            }
            finally
            {
                if (reader != null) { reader.Close(); }
            }
        }

        public bool Create(UserAttributeItemEntity entity, DbConnection connection, DbTransaction transaction)
        {
            var count = UserAttributeItemsGateway.Insert(entity, connection, transaction);

            return (count == 1);
        }

        public bool Truncate(DbConnection connection, DbTransaction transaction)
        {
            var error = UserAttributeItemsGateway.Truncate(connection, transaction);

            return (error == 0);
        }

        /// <summary>
        /// コンストラクター。
        /// </summary>
        internal UserAttributeItemsRepository()
        {
            this.DoNothing();
        }
    }
}