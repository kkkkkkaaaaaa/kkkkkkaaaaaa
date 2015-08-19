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

            var result = await reader.ExecuteReaderAsync(CommandBehavior.Default, token);

            return result;
        }
    }
}