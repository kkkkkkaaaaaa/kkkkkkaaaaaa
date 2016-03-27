using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace kkkkkkaaaaaa.Data.Common
{
    /// <summary>
    /// 
    /// </summary>
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
        /// 列に格納されている値が存在しない値または欠損値かどうかを示す値を取得する <see cref="M:System.Data.Common.DbDataReader.IsDBNull(System.Int32)"/> の非同期バージョン。
        /// 必要に応じて、操作を取り消す必要があるという通知を送信します。
        /// </summary>
        /// <param name="ordinal">取得する、0 から始まる列。</param>
        /// <param name="token">
        /// 操作を取り消すことを示す通知を反映する取り消し命令。
        /// これは取り消しを保証しません。
        /// CancellationToken.None の設定は、このメソッドを <see cref="M:System.Data.Common.DbDataReader.IsDBNullAsync(System.Int32)"/> と同じにします。
        /// 返されたタスクを取り消し済みとしてマークする必要があります。</param>
        /// <returns>
        /// 指定した列の値が DBNull と等価である場合は true。それ以外の場合は false。
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">
        /// データの取得中、接続は破棄されるか、または閉じられます。
        /// <see cref="T:System.Data.Common.DbDataReader"/> は、データの取得時に閉じます。
        /// 読み取ることのできるデータはありません (たとえば、最初の <see cref="M:System.Data.Common.DbDataReader.Read"/> は呼び出されなかったか、false を返しました)。
        /// 以前に読み取られた列をシーケンシャル モードで読み取ろうとしています。
        /// 非同期操作が進行中でした。シーケンシャル モードで実行中、これはすべての Get* メソッドに適用されます。
        /// ストリームの読み取り中に呼び出すことができるためです。
        /// </exception>
        /// <exception cref="T:System.IndexOutOfRangeException">存在しない列を読み取ろうとしています。</exception>
        [DebuggerStepThrough()]
        public override async Task<bool> IsDBNullAsync(int ordinal, CancellationToken token)
        {
            return await this._reader.IsDBNullAsync(ordinal, token);
        }

        public async Task<T> GetFieldValueAsync<T>(string name, CancellationToken token)
        {
            var value = Task.FromResult(default(T));

            var ordinal = this.GetOrdinal(name);
            if (!await this.IsDBNullAsync(ordinal, token)) { value = this.GetFieldValueAsync<T>(ordinal, token); }

            return await value;
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
        public override async Task<bool> NextResultAsync(CancellationToken token)
        {
            return await this._reader.NextResultAsync(token);
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
        public async Task<DbDataReader> ExecuteReaderAsync()
        {
            return await this.ExecuteReaderAsync(CommandBehavior.Default, CancellationToken.None);
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
    }
}
