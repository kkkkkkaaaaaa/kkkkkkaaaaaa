using System;
using System.Data;
using System.Data.Common;
using Xunit;
using kkkkkkaaaaaa.Web.DataTransferObjects;
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

        [Fact()]
        public void TruncateFact()
        {
            var connction = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connction = this._factory.CreateConnection();
                connction.Open();

                transaction = connction.BeginTransaction(IsolationLevel.Serializable);

                var repository = new MembershipsRepository();

                if (!repository.Truncate(connction, transaction))
                {
                    transaction.Rollback();
                    Assert.False(false);
                }
                else
                {
                    var createdOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                    Assert.True(repository.Create(new MembershipEntity() { ID = 1, Name = @"System", Password = @"", Enabled = true, CreatedOn = createdOn, }, connction, transaction));
                    Assert.True(repository.Create(new MembershipEntity() { ID = 2, Name = @"Administrator", Password = @"", Enabled = true, CreatedOn = createdOn, }, connction, transaction));
                    Assert.True(repository.Create(new MembershipEntity() { ID = 3, Name = @"User", Password = @"", Enabled = true, CreatedOn = createdOn, }, connction, transaction));

                    transaction.Commit();
                    Assert.True(true);
                }
                
            }
            finally
            {
                if (connction != null) { connction.Close(); }
            }
        }
    }
}