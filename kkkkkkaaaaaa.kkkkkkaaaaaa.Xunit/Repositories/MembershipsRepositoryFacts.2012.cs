using System.Data.Common;
using System.Threading;
using kkkkkkaaaaaa.DataTransferObjects;
using kkkkkkaaaaaa.Repositories;
using kkkkkkaaaaaa.Xunit.Repositories;
using Xunit;

namespace kkkkkkaaaaaa.kkkkkkaaaaaa.Xunit.Repositories
{
    public partial class MembershipsRepositoryFacs : KandaRepositoryFacts
	{
		[Fact()]
	    public async void FindAsyncFact()
		{
            var connection = this.Factory.CreateConnection();
		    var transaction = default(DbTransaction);
			var criteria = new MembershipsCriteria()
			{
			    ID = 10003,
				Enabled = true,
			};

		    try
		    {
		        await connection.OpenAsync();
		        transaction = connection.BeginTransaction();

		        var entity = await KandaRepository.Memberships.FindAsync(criteria, connection, transaction, CancellationToken.None);

				transaction.Commit();

				Assert.NotEqual(criteria.ID, entity.ID);
		    }
		    catch
		    {
                if (transaction != null) { transaction.Rollback();  }
		        throw;
		    }
		    finally
		    {
                if (connection != null) { connection.Close(); }
		    }
		}
	}
}