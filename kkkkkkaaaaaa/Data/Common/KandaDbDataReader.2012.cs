using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace kkkkkkaaaaaa.Data.Common
{
    public partial class KandaDbDataReader
    {
        /// <summary>
        /// これは Read() の非同期バージョンです。
        /// プロバイダーは、適切な実装でオーバーライドする必要があります。
        /// オプションで cancellationToken を無視できます。
        /// 既定の実装は、Read() 同期メソッドを呼び出し、完了したタスクを返します。
        /// 呼び出し元のスレッドはブロックされます。
        /// 既定の実装は、既に取り消された cancellationToken を渡した場合、取り消されたタスクを返します。
        /// Read() によってスローされる例外は、返されたタスクの Exception プロパティを介して通信されます。
        /// 返されたタスクが完了するまで DbDataReader オブジェクトの他のメソッドとプロパティを呼び出さないでください。
        /// </summary>
        /// <param name="token">取り消し命令。</param>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public override async Task<bool> ReadAsync(CancellationToken token)
        {
            return await this._reader.ReadAsync(token);
        }

        /// <summary>
        /// 指定された列の値を型として非同期的に取得します。
        /// </summary>
        /// <typeparam name="T">返される値の型。 </typeparam>
        /// <param name="ordinal">返される値の型。</param>
        /// <param name="token">
        /// 操作を取り消すことを示す通知を反映する取り消し命令。
        /// これは取り消しを保証しません。
        /// CancellationToken.None の設定は、このメソッドを GetFieldValueAsync(int) と同じにします。
        /// 返されたタスクを取り消し済みとしてマークする必要があります。
        /// </param>
        /// <returns>返される値の型。</returns>
        [DebuggerStepThrough()]
        public override async Task<T> GetFieldValueAsync<T>(int ordinal, CancellationToken token)
        {
            return await this._reader.GetFieldValueAsync<T>(ordinal, token);
        }

        [DebuggerStepThrough()]
        public async Task<T> GetFieldValueAsync<T>(string name, CancellationToken token)
        {
            var ordinal = this.GetOrdinal(name);

            return await this.GetFieldValueAsync<T>(ordinal, token);
        }

        [DebuggerStepThrough()]
        public override async Task<bool> IsDBNullAsync(int ordinal, CancellationToken token)
        {
            return await this._reader.IsDBNullAsync(ordinal, token);
        }

        [DebuggerStepThrough()]
        public async Task<bool> IsDBNullAsync(string name, CancellationToken token)
        {
            var ordinal = this.GetOrdinal(name);

            return await this.IsDBNullAsync(ordinal, token);
        }

        [DebuggerStepThrough()]
        public override async Task<bool> NextResultAsync(CancellationToken cancellationToken)
        {
            return await this._reader.NextResultAsync(cancellationToken);
        }


        /// <summary>
        /// ExecuteDbReaderAsync を呼び出します。
        /// </summary>
        /// <param name="behavior"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<DbDataReader> ExecuteReaderAsync(CommandBehavior behavior, CancellationToken token)
        {
            this._reader = await this._command.ExecuteReaderAsync(behavior, token);

            return this._reader;
        }

        [DebuggerStepThrough()]
        public async Task<DbDataReader> ExecuteReaderAsync(CommandBehavior behavior)
        {
            return await this.ExecuteReaderAsync(behavior, CancellationToken.None);
        }

        [DebuggerStepThrough()]
        public async Task<DbDataReader> ExecuteReaderAsync(CancellationToken token)
        {
            return await this.ExecuteReaderAsync(CommandBehavior.Default, token);
        }

        [DebuggerStepThrough()]
        public async Task<DbDataReader> ExecuteReaderAsync()
        {
            return await this.ExecuteReaderAsync(CommandBehavior.Default, CancellationToken.None);
        }
    }
}
