using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Common;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.Web.DataTransferObjects;
using kkkkkkaaaaaa.Web.TableDataGateways;

namespace kkkkkkaaaaaa.Web.Repositories
{
    public class UserAttributesRepository
    {
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

        public bool Create(UserAttributeEntity entity, DbConnection connection, DbTransaction transaction)
        {
            var count = UserAttributesGateway.Insert(entity, connection, transaction);

            return (count == 1);
        }

        public bool Update(UserAttributeEntity entity, DbConnection connection, DbTransaction transaction)
        {
            var count = UserAttributesGateway.Update(entity, connection, transaction);

            return (count == 1);
        }

        public bool Truncate(DbConnection connection, DbTransaction transaction)
        {
            var error = UserAttributesGateway.Truncate(connection, transaction);

            return (error == 0);
        }
    }
}