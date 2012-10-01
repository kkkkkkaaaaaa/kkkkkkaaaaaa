using System.Data.Common;
using kkkkkkaaaaaa.Web.DataTransferObjects;
using kkkkkkaaaaaa.Web.TableDataGateways;

namespace kkkkkkaaaaaa.Web.Repositories
{
    /// <summary>
    /// Roles の Repository。
    /// </summary>
    public class RolesRepository : KandaRepository
    {
        public bool Create(RoleEntity entity, DbConnection connection, DbTransaction transaction)
        {
            var affected = RolesGateway.Insert(entity, connection, transaction);

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