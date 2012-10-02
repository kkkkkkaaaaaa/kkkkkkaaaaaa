using System;
using System.Data;
using System.Data.Common;
using Xunit;
using kkkkkkaaaaaa.Web.DataTransferObjects;
using kkkkkkaaaaaa.Web.Repositories;

namespace kkkkkkaaaaaa.Xunit.Web.Repositories
{
    public class MembershipsRepositoryFacts : KandaXunitRepositoryFacts
    {
        [Fact()]
        public void FindByMembershipFact()
        {
            var connction = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connction = this._factory.CreateConnection();
                connction.Open();

                transaction = connction.BeginTransaction(IsolationLevel.Serializable);

                var repository = new MembershipsRepository();

                var id = long.MaxValue;
                var createdOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                Assert.True(repository.Create(new MembershipEntity() { ID = id, Name = @"System", Password = @"", Enabled = true, CreatedOn = createdOn, }, connction, transaction));

                var user = repository.Find(@"System", @"", connction, transaction);
                Assert.Equal(1L, user.ProviderUserKey);
            }
            finally
            {
                if (transaction != null) { transaction.Rollback(); }
                if (connction != null) { connction.Close(); }
            }
        }

        [Fact()]
        public void FindByIDFact()
        {
            var connction = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connction = this._factory.CreateConnection();
                connction.Open();

                transaction = connction.BeginTransaction(IsolationLevel.Serializable);

                var repository = new MembershipsRepository();

                var id = long.MaxValue;
                var createdOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                Assert.True(repository.Create(new MembershipEntity() { ID = id, Name = @"System", Password = @"", Enabled = true, CreatedOn = createdOn, }, connction, transaction));

                var entity = repository.Find(1L, connction, transaction);
                Assert.Equal(1L, entity.ID);
            }
            finally
            {
                if (transaction != null) { transaction.Rollback(); }
                if (connction != null) { connction.Close(); }
            }
        }

        [Fact()]
        public void CreateFact()
        {
            var connction = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connction = this._factory.CreateConnection();
                connction.Open();

                transaction = connction.BeginTransaction(IsolationLevel.Serializable);

                var repository = new MembershipsRepository();

                var id = long.MaxValue;
                var createdOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                Assert.True(repository.Create(new MembershipEntity() { ID = id, Name = @"System", Password = @"", Enabled = true, CreatedOn = createdOn, }, connction, transaction));
                Assert.Equal(id, repository.Find(id, connction, transaction).ID);
            }
            finally
            {
                if (transaction != null) { transaction.Rollback(); }
                if (connction != null) { connction.Close(); }
            }
        }

        [Fact()]
        public void UpdateFact()
        {
            var connction = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connction = this._factory.CreateConnection();
                connction.Open();

                transaction = connction.BeginTransaction(IsolationLevel.Serializable);

                var repository = new MembershipsRepository();

                var id = long.MaxValue;
                var createdOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                repository.Create(new MembershipEntity() { ID = id, Name = @"System", Password = @"", Enabled = true, CreatedOn = createdOn, }, connction, transaction);

                var updatedOn = repository.GetUtcDateTime(connction, transaction);
                Assert.True(repository.Update(new MembershipEntity() { ID = id, Name = @"System", Password = @"", Enabled = true, UpdatedOn = updatedOn, }, connction, transaction));
                Assert.True(createdOn < repository.Find(id, connction, transaction).UpdatedOn);
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
            catch
            {
                if (transaction != null) { transaction.Rollback(); }
                throw;
            }
            finally
            {
                if (connction != null) { connction.Close(); }
            }
        }
    }
}