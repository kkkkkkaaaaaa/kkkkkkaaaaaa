using System.Data.Common;

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
    }
}
