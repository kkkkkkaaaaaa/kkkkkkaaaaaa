using System;
using System.Data;
using System.Data.Common;
using Xunit;
using kkkkkkaaaaaa.Web.DataTransferObjects;
using kkkkkkaaaaaa.Web.Repositories;

namespace kkkkkkaaaaaa.Xunit.Web.Repositories
{
    public class RolesRepositoryFacts : KandaXunitRepositoryFacts
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

                var repository = new RolesRepository();

                var id = long.MaxValue;

                var createdOn = new DateTime(1, 1, 1, 0, 0, 0, 0);
                Assert.True(repository.Create(new RoleEntity() { ID = id, Name = @"Fact", Description = @"Description", Enabled = true, CreatedOn = createdOn, }, connection, transaction));

                Assert.Equal(id, repository.Find(id, connection, transaction).ID);
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
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                var repository = new RolesRepository();

                var id = long.MaxValue;

                var createdOn = new DateTime(1, 1, 1, 0, 0, 0, 0);
                Assert.True(repository.Create(new RoleEntity(){ ID = id, Name = @"Fact", Description = @"Description", Enabled = true, CreatedOn = createdOn, }, connection, transaction));
            }
            finally
            {
                if (transaction != null) { transaction.Rollback(); }
                if (connection != null) { connection.Close(); }
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

                var repository = new RolesRepository();

                var id = long.MaxValue;

                var createdOn = new DateTime(1, 1, 1, 0, 0, 0, 0);
                Assert.True(repository.Create(new RoleEntity() { ID = id, Name = @"Fact", Description = @"Description", Enabled = true, CreatedOn = createdOn, }, connection, transaction));

                var updatedOn = repository.GetUtcDateTime(connection, transaction);
                Assert.True(repository.Update(new RoleEntity() { ID = id, Name = @"Fact", Description = @"Description", Enabled = true, UpdatedOn = updatedOn, }, connection, transaction));
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