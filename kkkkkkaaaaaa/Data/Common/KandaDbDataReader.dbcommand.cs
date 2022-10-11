using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using kkkkkkaaaaaa.Data;

namespace kkkkkkaaaaaa.Data.Common
{
    /// <summary>
    /// データソースから行の前方向ストリームを読み取ります。
    /// </summary>
    public partial class KandaDbDataReader : DbDataReader
    {
        /// <summary>
        /// DbParameter オブジェクトのコレクションを返します。
        /// </summary>
        public DbParameterCollection Parameters
        {
            [DebuggerStepThrough()]
            get { return this.InnerCommand.Parameters; }
        }

        /// <summary>
        /// データソースに対して実行するテキストコマンドを取得または設定します。
        /// </summary>
        public string CommandText
        {
            [DebuggerStepThrough()]
            get { return this.InnerCommand.CommandText; }
            [DebuggerStepThrough()]
            set { this.InnerCommand.CommandText = value; }
        }

        /// <summary>
        /// DbCommand.CommandText の解釈方法を指示または指定します。
        /// </summary>
        public CommandType CommandType
        {
            [DebuggerStepThrough()]
            get { return this.InnerCommand.CommandType; }
            [DebuggerStepThrough()]
            set { this.InnerCommand.CommandType = value; }
        }

        /// <summary>
        /// 接続に対してコマンドを実行し、結果へのアクセスに使用できる DbDataReader を返します。
        /// </summary>
        /// <param name="behavior"></param>
        /// <returns></returns>
        public DbDataReader ExecuteReader(CommandBehavior behavior = CommandBehavior.Default)
        {
            this._reader = this.InnerCommand.ExecuteReader(CommandBehavior.Default);

            return this._reader;
        }
    }
}
