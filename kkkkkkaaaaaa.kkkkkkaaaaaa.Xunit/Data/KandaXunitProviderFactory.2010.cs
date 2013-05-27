using System.Data;
using System.Data.Common;

namespace kkkkkkaaaaaa.Xunit.Data
{
    public partial class KandaXunitProviderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public override DbCommand CreateCommand(DbConnection connection, DbTransaction transaction = null)
        {
            var command = base.CreateCommand(connection, transaction);

            command.CommandType = CommandType.StoredProcedure;

            return command;
        }
    }
}