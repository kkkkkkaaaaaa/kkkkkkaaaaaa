using System.Data;
using System.Data.Common;
using Xunit;
using kkkkkkaaaaaa.Web.Repositories;

namespace kkkkkkaaaaaa.Xunit.Web.Repositories
{
    public class MembershipsRepositoryFacts : KandaRepositoryFacts
    {

        [Fact()]
        public void FindFact()
        {
            var connction = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connction = this._factory.CreateConnection();
                transaction = connction.BeginTransaction(IsolationLevel.Serializable);

                var repository = new MembershipsRepository();
                var entity = repository.Find(@"System", @"", connction, transaction);

                Assert.Equal(1, entity.ProviderUserKey);
            }
            finally
            {
                if (transaction != null) { transaction.Rollback(); }
                if (connction != null) { connction.Close(); }
            }
        }

    }
}