using System;
using System.Data;
using System.Data.Common;
using Xunit;
using kkkkkkaaaaaa.Web.Repositories;

namespace kkkkkkaaaaaa.Xunit.Web.Repositories
{
    public class RolesRepositoryFacts : KandaRepositoryFacts
    {
        [Fact()]
        public void TruncateFact()
        {
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                var repository = new RolesRepository();

                Assert.True(repository.Truncate(connection, transaction));
            }
            finally
            {
                if (transaction != null) { transaction.Rollback(); }
                if (connection != null) { connection.Close(); }
            }

        }
    }
}