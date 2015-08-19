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
		/// 
		/// </summary>
		/// <param name="ordinal"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
        public override Task<bool> IsDBNullAsync(int ordinal, CancellationToken cancellationToken)
        {
            return this._reader.IsDBNullAsync(ordinal, cancellationToken);
        }

        public override Task<bool> ReadAsync(CancellationToken cancellationToken)
        {
            return this._reader.ReadAsync(cancellationToken);
        }

        public override Task<T> GetFieldValueAsync<T>(int ordinal, CancellationToken cancellationToken)
        {
            return this._reader.GetFieldValueAsync<T>(ordinal, cancellationToken);
        }

        public override Task<bool> NextResultAsync(CancellationToken cancellationToken)
        {
            return this._reader.NextResultAsync(cancellationToken);
        }


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
