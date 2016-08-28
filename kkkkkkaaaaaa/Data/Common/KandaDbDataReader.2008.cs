using System.Data.Common;

namespace kkkkkkaaaaaa.Data.Common
{
    /// <summary>
    /// データソースから行の前方向ストリームを読み取ります。
    /// </summary>
    public partial class KandaDbDataReader : DbDataReader
    {
        /// <summary>
        /// コンストラクタ―。
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        public KandaDbDataReader(DbConnection connection, DbTransaction transaction)
        {
            this._command = connection.CreateCommand();
            this._command.Transaction = transaction;
        }
        
        /// <summary>
        /// コンストラクタ―。
        /// </summary>
        /// <param name="connection"></param>
        public KandaDbDataReader(DbConnection connection) : this(connection, null)
        {
            this.DoNothing();
        }

        /// <summary>
        /// DbCommand.Connection に対して DbCommand.CommandText を実行し、CommandBehavior の値の 1 つを使用して DbDataReader を実行します。
        /// </summary>
        /// <param name="behavior"></param>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public DbDataReader ExecuteReader(CommandBehavior behavior)
        {
            this._reader = this.InnerCommand.ExecuteReader(behavior);

            return this;
        }

        /// <summary>
        /// DbCommand.Connection に対して DbCommand.CommandText を実行し、CommandBehavior の値の 1 つを使用して DbDataReader を実行します。
        /// </summary>
        [DebuggerStepThrough()]
        public DbDataReader ExecuteReader()
        {
            return this.ExecuteReader(CommandBehavior.Default);
        }
    }
}
