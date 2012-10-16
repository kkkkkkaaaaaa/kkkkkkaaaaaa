using System.Data.Common;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.Data.TableDataGateways;
using kkkkkkaaaaaa.DataTransferObjects;

namespace kkkkkkaaaaaa.Data.Repositories
{
    /// <summary>
    /// Roles の Repository。
    /// </summary>
    public class RolesRepository : KandaRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        public RoleEntity Find(long id, DbConnection connection, DbTransaction transaction)
        {
            var reader = default(DbDataReader);

            try
            {
                reader = RolesGateway.Select(new RolesCriteria() { ID = id, }, connection, transaction);

                var role = (reader.Read() ? KandaDbDataMapper.MapToObject<RoleEntity>(reader) : new RoleEntity());

                return role;
            }
            finally
            {
                if (reader != null) { reader.Close(); }
            }
        }

        public long IdentCurrent(DbConnection connection, DbTransaction transaction)
        {
            var current = RolesGateway.IdentCurrent(connection, transaction);

            return decimal.ToInt64(current);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Create(RoleEntity entity, DbConnection connection, DbTransaction transaction)
        {
            var created = RolesGateway.Insert(entity, connection, transaction);

            return (created == 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Update(RoleEntity entity, DbConnection connection, DbTransaction transaction)
        {
            var updated = RolesGateway.Update(entity, connection, transaction);

            return (updated == 1);
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
            var deleted = RolesGateway.Delete(id, connection, transaction);

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
            var error = RolesGateway.Truncate(connection, transaction);

            return (error == 0);
        }


        /// <summary>
        /// コンストラクタ―。
        /// </summary>
        internal RolesRepository()
        {
            this.DoNothing();
        }
    }
}