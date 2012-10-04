using System.Data.Common;
using kkkkkkaaaaaa.Web.TableDataGateways;

namespace kkkkkkaaaaaa.Web.Repositories
{
    public class MembershipAuthorizationsRepository : KandaRepository
    {


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

        public IEnumerable<Entitiy> Get(Entity entity, DbConnection connection, DbTransaction transaction)
        {
            var reader = default(DbDataReader);

            try
            {
                reader = KandaTableDataGateway.Select(entity, connection, transaction);

                var entities = KandaDbDataMapper.MapToEnumerable<UserAttributeItemEntitiy>(reader);

                return entity;
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

        public bool Create(Entitiy entity, DbConnection connection, DbTransaction transaction)
        {
            var count = Gateway.Insert(entity, connection, transaction);

            return (count == 1);
        }

        public bool Update(Entitiy entity, DbConnection connection, DbTransaction transaction)
        {
            var count = Gateway.Update(entity, connection, transaction);

            return (count == 1);
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