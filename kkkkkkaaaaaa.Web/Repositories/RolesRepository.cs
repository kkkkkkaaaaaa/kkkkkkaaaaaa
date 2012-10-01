using System.Data.Common;
using kkkkkkaaaaaa.Web.TableDataGateways;

namespace kkkkkkaaaaaa.Web.Repositories
{
    /// <summary>
    /// Roles の Repository。
    /// </summary>
    public class RolesRepository : KandaRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Truncate(DbConnection connection, DbTransaction transaction)
        {
            var result = RolesGateway.Truncate(connection, transaction);

            return (result == 0);
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