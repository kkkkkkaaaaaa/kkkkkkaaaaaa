using System;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.DataTransferObjects;

namespace kkkkkkaaaaaa.Data.TableDataGateways
{
    internal partial class MembershipsGateway
    {
        public static async Task<DbDataReader> SelectAsync(MembershipsCriteria criteria, DbConnection connection, DbTransaction transaction, CancellationToken token)
        {
            var reader = _factory.CreateReader(connection, transaction);
            reader.CommandText = @"usp_SelectMemberships";

			KandaDbDataMapper.MapToParameters(reader, criteria);

            var result = await reader.ExecuteReaderAsync(token);

            return reader;
        }

        public static async Task<long> InsertAsync(MembershipEntity entity, DbConnection connection, DbTransaction transaction, CancellationToken token)
        {
            var command = _factory.CreateCommand(connection, transaction);

            command.CommandText = @"usp_InsertMemberships";

            KandaDbDataMapper.MapToParameters(command, entity);
            var identity = KandaTableDataGateway._factory.CreateParameter(@"identity", DbType.Decimal, sizeof(decimal), ParameterDirection.Output, DBNull.Value);
            command.Parameters.Add(identity);
            var _ = KandaTableDataGateway._factory.CreateParameter(KandaTableDataGateway.RETURN_VALUE, DbType.Int32, sizeof(int), ParameterDirection.ReturnValue, DBNull.Value);
            command.Parameters.Add(_);

            var affected = await command.ExecuteNonQueryAsync(token);

            return Convert.ToInt64(identity.Value);
        }

        public static async Task<int> UpdateAsync(MembershipEntity entity, DbConnection connection, DbTransaction transaction, CancellationToken token)
        {
            var command = _factory.CreateCommand(connection, transaction);
            command.CommandText = @"usp_UpdateMemberships";

            KandaDbDataMapper.MapToParameters(command, entity);
            var _ = KandaTableDataGateway._factory.CreateParameter(KandaTableDataGateway.RETURN_VALUE, DbType.Int32, sizeof(int), ParameterDirection.ReturnValue, null);

            var affected = await command.ExecuteNonQueryAsync(token);

            return affected;
        }

        public static async Task<int> DeleteAsync(long id, DbConnection connection, DbTransaction transaction, CancellationToken token)
        {
            var command = KandaTableDataGateway._factory.CreateCommand(connection, transaction);
            command.CommandText = @"usp_DeleteMemberships";

            command.Parameters.Add(KandaTableDataGateway._factory.CreateParameter("@id", DbType.Int64, sizeof(long), ParameterDirection.Input, id));
            var _ = KandaTableDataGateway._factory.CreateParameter(KandaTableDataGateway.RETURN_VALUE, DbType.Int32, sizeof(int), ParameterDirection.ReturnValue, null);

            var affected = await command.ExecuteNonQueryAsync(token);

            return affected;
        }

        public static async Task<int> TruncateAsync(DbConnection connection, DbTransaction transaction, CancellationToken token)
        {
            return await KandaTableDataGateway.TruncateAsync(MembershipsGateway.TABLE_NAME, connection, transaction, token);
        }
    }
}
