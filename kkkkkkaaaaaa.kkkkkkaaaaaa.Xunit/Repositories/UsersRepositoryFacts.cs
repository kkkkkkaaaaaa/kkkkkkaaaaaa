using System;
using System.Data;
using System.Data.Common;
using Xunit;
using kkkkkkaaaaaa.Repositories;
using kkkkkkaaaaaa.DataTransferObjects;

namespace kkkkkkaaaaaa.Xunit.Repositories
{
    public class UsersRepositoryFacts : KandaXunitRepositoryFacts
    {
        [Fact()]
        public void FindFact()
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
                Assert.NotNull(repository.Find(id, connection, transaction));
            }
            finally
            {
                if (transaction != null) { transaction.Rollback(); }
                if (connection != null) { connection.Close(); }
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
                Assert.True(repository.Update(new UserEntity() { ID = id, FamilyName = @"Fact", GivenName = @"", AdditionalName = @"", Description = @"", Enabled = true, UpdatedOn = updatedOn }, connection, transaction));
                Assert.Equal(id, repository.Find(id, connection, transaction).ID);
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

                transaction.Commit();
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