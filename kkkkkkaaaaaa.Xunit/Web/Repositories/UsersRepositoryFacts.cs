using System;
using System.Data;
using System.Data.Common;
using Xunit;
using kkkkkkaaaaaa.Web.DataTransferObjects;
using kkkkkkaaaaaa.Web.Repositories;

namespace kkkkkkaaaaaa.Xunit.Web.Repositories
{
    public class UsersRepositoryFacts : KandaXunitRepositoryFacts
    {
        [Fact()]
        public void FindFact()
        {
            var connection = default(DbConnection);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                var repository = new UsersRepository();
            }
            finally
            {
                
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

                var repository = new UsersRepository();

                var id = long.MaxValue;
                Assert.True(repository.Create(new UserEntity() { ID = id, }, connction, transaction));
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
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                var repository = new UsersRepository();

                var id = long.MaxValue;
                var createdOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                Assert.True(repository.Create(new UserEntity() { ID = id, FamilyName = @"Fact", GivenName = @"", AdditionalName = @"", Description = @"", Enabled = true, CreatedOn = createdOn }, connection, transaction));

                var updatedOn = KandaRepository.GetUtcDateTime(connection, transaction);
                Assert.True(repository.Update(new UserEntity() { ID = id, FamilyName = @"Fact", GivenName = @"", AdditionalName = @"", Description = @"", Enabled = true, UpdateOn = updatedOn }, connection, transaction));
                Assert.True(repository.Find(id, connection, transaction).UpdateOn == updatedOn);
            }
            finally
            {
                if (transaction != null) { transaction.Rollback(); }
                if (connection != null) { connection.Close(); }
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

                var repository = new UsersRepository();

                Assert.True(repository.Truncate(connction, transaction));

                /*
                var repository = new UsersRepository();

                if (!repository.Truncate(connction, transaction))
                {
                    transaction.Rollback();
                    Assert.False(false);
                }
                else
                {
                    var createdOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                    Assert.True(repository.Create(new UserEntity() { ID = 1, FamilyName = @"System", GivenName = @"", AdditionalName = @"", Description = @"", Enabled = true, CreatedOn = createdOn }, connction, transaction));
                    Assert.True(repository.Create(new UserEntity() { ID = 2, FamilyName = @"Administrator", GivenName = @"", AdditionalName = @"", Description = @"", Enabled = true, CreatedOn = createdOn }, connction, transaction));
                    Assert.True(repository.Create(new UserEntity() { ID = 3, FamilyName = @"User", GivenName = @"", AdditionalName = @"", Description = @"", Enabled = true, CreatedOn = createdOn }, connction, transaction));

                    transaction.Commit();
                    Assert.True(true);
                }
                */
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