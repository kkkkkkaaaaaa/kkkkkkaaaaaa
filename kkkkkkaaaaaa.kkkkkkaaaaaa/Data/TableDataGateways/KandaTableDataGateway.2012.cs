using System;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace kkkkkkaaaaaa.Data.TableDataGateways
{
    internal partial class KandaTableDataGateway
    {
        protected static async Task<int> TruncateAsync(string tableName, DbConnection connection, DbTransaction transaction, CancellationToken token)
        {
            var command = KandaTableDataGateway._factory.CreateCommand(connection, transaction);

            command.CommandText = @"usp_TruncateTable";

            command.Parameters.Add(KandaTableDataGateway._factory.CreateParameter("@tableName", tableName));

            var result = KandaTableDataGateway._factory.CreateParameter(KandaTableDataGateway.RETURN_VALUE, DbType.Int32, sizeof(int), ParameterDirection.ReturnValue, DBNull.Value);
            command.Parameters.Add(result);

            var affected = await command.ExecuteNonQueryAsync();

            return (int)result.Value;
        }
    }
}