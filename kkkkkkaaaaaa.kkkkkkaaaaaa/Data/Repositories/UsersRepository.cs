using System.Data.Common;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.Data.TableDataGateways;
using kkkkkkaaaaaa.DataTransferObjects;

namespace kkkkkkaaaaaa.Data.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class UsersRepository : KandaRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public UserEntity Find(long id, DbConnection connection, DbTransaction transaction)
        {
            var reader = default(DbDataReader);

            try
            {
                reader = UsersGateway.Select(new UsersCriteria(){ ID = id, }, connection, transaction);

                var found = reader.Read() ? KandaDbDataMapper.MapToObject<UserEntity>(reader) : new UserEntity();

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
        /// <param name="entity"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Create(UserEntity entity, DbConnection connection, DbTransaction transaction)
        {
            var created = UsersGateway.Insert(entity, connection, transaction);

            return (created == 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Update(UserEntity entity, DbConnection connection, DbTransaction transaction)
        {
            var affected = UsersGateway.Update(entity, connection, transaction);

            return (affected == 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        internal long IdentCurrent(DbConnection connection, DbTransaction transaction)
        {
            var current= UsersGateway.IdentCurrent(connection, transaction);

            return decimal.ToInt64(current);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        internal bool Delete(long id, DbConnection connection, DbTransaction transaction)
        {
            var deleted = UsersGateway.Delete(id, connection, transaction);

            return (deleted == 1);
        }
    }
}