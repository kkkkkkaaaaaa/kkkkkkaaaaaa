using System.Data.Common;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.Web.DataTransferObjects;
using kkkkkkaaaaaa.Web.TableDataGateways;

namespace kkkkkkaaaaaa.Web.Repositories
{
    public class UsersRepository : KandaRepository
    {
        public UserEntity Find(long id, DbConnection connection, DbTransaction transaction)
        {
            var reader = default(DbDataReader);

            try
            {
                reader = UsersGateway.Select(new UserEntity(){ ID = id, }, connection, transaction);

                var found = reader.Read() ? KandaDbDataMapper.MapToObject<UserEntity>(reader) : default(UserEntity);

                return found;
            }
            finally
            {
                if (reader != null) { reader.Close(); }
            } 
        }

        public bool Create(UserEntity entity, DbConnection connection, DbTransaction transaction)
        {
            var created = UsersGateway.Insert(entity, connection, transaction);

            return (created == 1);
        }

        public bool Update(UserEntity entity, DbConnection connection, DbTransaction transaction)
        {
            var affected = UsersGateway.Update(entity, connection, transaction);

            return (affected == 1);
        }

        public bool Truncate(DbConnection connection, DbTransaction transaction)
        {
            var error = UsersGateway.Truncate(connection, transaction);

            return (error == 0);
        }

        /// <summary>
        /// コンストラクタ―。
        /// </summary>
        internal UsersRepository()
        {
            this.DoNothing();
        }
    }
}