using System.Data.Common;
using kkkkkkaaaaaa.Web.DataTransferObjects;
using kkkkkkaaaaaa.Web.TableDataGateways;

namespace kkkkkkaaaaaa.Web.Repositories
{
    public class MembershipRolesRepository : KandaRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Create(MembershipRoleEntity entity, DbConnection connection, DbTransaction transaction)
        {
            var count = MembershipRolesGateway.Insert(entity, connection, transaction);

            return (count == 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Truncate(DbConnection connection, DbTransaction transaction)
        {
            var error = MembershipRolesGateway.Truncate(connection, transaction);

            return (error == 0);
        }

        /// <summary>
        /// コンストラクタ―。
        /// </summary>
        internal MembershipRolesRepository()
        {
            this.DoNothing();
        }
    }
}