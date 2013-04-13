using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using kkkkkkaaaaaa.Data.TableDataGateways;
using kkkkkkaaaaaa.DataTransferObjects;
using kkkkkkaaaaaa.Data.Extensions;

namespace kkkkkkaaaaaa.Data.Repositories
{
    public class MembershipAuthorizationsRepository : KandaRepository
    {
        public ICollection<long> Get(MembershipAuthorizationsCriteria criteria, DbConnection connection, DbTransaction transaction)
        {
            var reader = default(IDataReader);

            try
            {
                reader = MembershipAuthorizationsGateway.Select(criteria, connection, transaction);

                var authorizations = new Collection<long>();

                while (reader.Read()) { authorizations.Add(reader.GetInt64(@"AuthorizationID")); }

                return authorizations;
            }
            finally
            {
                if (reader != null) { reader.Close(); }
            }
        }

        public bool Create(MembershipAuthorizationEntity entity, DbConnection connection, DbTransaction transaction)
        {
            var count = MembershipAuthorizationsGateway.Insert(entity, connection, transaction);

            return (count == 1);
        }
        
        public bool Delete(MembershipAuthorizationsCriteria criteria, DbConnection connection, DbTransaction transaction)
        {
            var deleted = MembershipAuthorizationsGateway.Delete(criteria, connection, transaction);

            return (0 <= deleted);
        }



        public bool Update(MembershipAuthorizationEntity entity, DbConnection connection, DbTransaction transaction)
        {
            var count = MembershipAuthorizationsGateway.Update(entity, connection, transaction);

            return (count == 1);
        }

        /*
        public Entity Find(long id, DbConnection connection, DbTransaction transaction)
        {
            var reader = default(DbDataReader);

            try
            {
                reader = Gateway.Select(new Entity(){ ID = id, Enabled = true, }, connection, transaction);

                var entity = (reader.Read() ? KandaDbDataMapper.MapToObject<Entity>(reader) : default(Entity));
            }
            finally
            {
                if (reader != null) { reader.Close(); }
            }
        }

        public IEnumerable<Entitiy> Search(Criteria criteria, DbConnection connection, DbTransaction transaction)
        {
            var reader = default(DbDataReader);

            try
            {
                reader = KandaTableDataGateway.Select(criteria, connection, transaction);

                var entities = KandaDbDataMapper.MapToEnumerable<UserAttributeItemEntitiy>(reader);

                return entity;
            }
            finally
            {
                if (reader != null) { reader.Close(); }
            }
        }

        public bool Register(Entitiy entity, DbConnection connection, DbTransaction transaction)
        {
            if (Gateway.Udpate(entity, connection, transaction) == 1) { return true; }

            if (Gateway.Insert(entity, connection, transaction) == 1) { return true; }

            return false;
        }

        public bool Delete(Entitiy entity, DbConnection connection, DbTransaction transaction)
        {
            var deleted = Gateway.Delete(entity, connection, transaction);

            return (deleted == 1);
        }
        */

        public bool Truncate(DbConnection connection, DbTransaction transaction)
        {
            var error = MembershipAuthorizationsGateway.Truncate(connection, transaction);

            return (error == 0);
        }
    }
}