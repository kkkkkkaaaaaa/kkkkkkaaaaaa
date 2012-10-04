using System.Data.Common;

namespace kkkkkkaaaaaa.Web.TableDataGateways
{
    /// <summary>
    /// 
    /// </summary>
    public class MembershipAuthorizationsGateway : KandaTableDataGateway
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public static int Truncate(DbConnection connection, DbTransaction transaction)
        {
            return KandaTableDataGateway.Truncate(@"MembershipAuthorizations", connection, transaction);
        }
    }
}