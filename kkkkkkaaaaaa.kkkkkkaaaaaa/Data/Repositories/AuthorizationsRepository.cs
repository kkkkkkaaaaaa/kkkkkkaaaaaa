using System.Data.Common;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.Data.TableDataGateways;
using kkkkkkaaaaaa.DataTransferObjects;

namespace kkkkkkaaaaaa.Data.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthorizationsRepository : KandaRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public AuthorizationEntity Find(long id, DbConnection connection, DbTransaction transaction)
        {
            var reader = default(KandaDbDataReader);

            try
            {
                reader = AuthorizationsGateway.Select(new AuthorizationsCriteria() {ID = id,}, connection, transaction);

                var found = KandaDbDataMapper.MapToObject<AuthorizationEntity>(reader);

                return found;
            }
            finally
            {
                if (reader != null) { reader.Close();   }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Create(AuthorizationEntity entity, DbConnection connection, DbTransaction transaction)
        {
            var created = AuthorizationsGateway.Insert(entity, connection, transaction);

            return (created == 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Update(AuthorizationEntity entity, DbConnection connection, DbTransaction transaction)
        {
            var updated = AuthorizationsGateway.Update(entity, connection, transaction);

            return (updated == 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public long IdentCurrent(DbConnection connection, DbTransaction transaction)
        {
            var current = AuthorizationsGateway.IdentCurrent(connection, transaction);

            return decimal.ToInt64(current);
        }


        /// <summary>
        /// コンストラクタ―。
        /// </summary>
        internal AuthorizationsRepository()
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
        internal bool Delete(long id, DbConnection connection, DbTransaction transaction)
        {
            var deleted = AuthorizationsGateway.Delete(id, connection, transaction);

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
            var error = AuthorizationsGateway.Truncate(connection, transaction);

            return (error == 0);
        }
    }
}