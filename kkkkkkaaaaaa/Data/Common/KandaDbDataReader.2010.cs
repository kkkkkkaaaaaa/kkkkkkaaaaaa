using System.Data;
using System.Data.Common;
using System.Diagnostics;

namespace kkkkkkaaaaaa.Data.Common
{
    /// <summary>
    /// データソースから行の前方向ストリームを読み取ります。
    /// </summary>
    public partial class KandaDbDataReader
    {
        /// <summary>
        /// コンストラクタ―。
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        public KandaDbDataReader(DbConnection connection, DbTransaction transaction = null)
        {
            this._command = connection.CreateCommand();
            this._command.Transaction = transaction;
        }

        /// <summary>
        /// DbCommand.Connection に対して DbCommand.CommandText を実行し、CommandBehavior の値の 1 つを使用して DbDataReader を実行します。
        /// </summary>
        /// <param name="behavior"></param>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public DbDataReader ExecuteReader(CommandBehavior behavior = CommandBehavior.Default)
        {
            this._reader = this.InnerCommand.ExecuteReader(behavior);

            return this;
        }
    }
}
