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
    }
}
