using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.Data.TableDataGateways;
using kkkkkkaaaaaa.DataTransferObjects;

namespace kkkkkkaaaaaa.Repositories
{
    public partial class MembershipsRepository
    {
        public async Task<MembershipEntity> FindAsync(MembershipsCriteria criteria, DbConnection connection, DbTransaction transaction, CancellationToken token)
		{
		    var reader = default(DbDataReader);

		    try
		    {
				reader = await MembershipsGateway.SelectAsync(criteria, connection, transaction, token);

				var entity = await reader.ReadAsync()
                    ? KandaDataMapper.MapToObject<MembershipEntity>(reader)
                    : MembershipEntity.Empty;

		        return entity;
		    }
		    finally
		    {
		        if (reader != null) { reader.Close(); }
		    }
        }
    }
}