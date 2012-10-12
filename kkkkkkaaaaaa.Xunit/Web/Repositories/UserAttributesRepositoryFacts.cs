using System.Data;
using System.Data.Common;
using Xunit;
using kkkkkkaaaaaa.Web.DataTransferObjects;
using kkkkkkaaaaaa.Web.Repositories;
using kkkkkkaaaaaa.Xunit.Repositories;

namespace kkkkkkaaaaaa.Xunit.Web.Repositories
{
    public class UserAttributesRepositoryFacts : KandaXunitRepositoryFacts
    {
        [Fact()]
        public void GetFact()
        {
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                var repository = new UserAttributesRepository();

                var id = long.MaxValue;
                Assert.NotNull(repository.Get(id, connection, transaction));
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

                var repository = new UserAttributesRepository();

                var userId = long.MaxValue;
                var itemId = int.MaxValue;
                Assert.True(repository.Create(new UserAttributeEntity(){ UserID = userId, ItemID = itemId, Value = @"", }, connection, transaction));
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

                var repository = new UserAttributesRepository();

                var userId = long.MaxValue;
                var itemId = int.MaxValue;
                Assert.True(repository.Create(new UserAttributeEntity() { UserID = userId, ItemID = itemId, Value = @"create", }, connection, transaction));
                Assert.True(repository.Update(new UserAttributeEntity() { UserID = userId, ItemID = itemId, Value = @"update", }, connection, transaction));
            }
            finally
            {
                if (transaction != null) { transaction.Rollback(); }
                if (connection != null) { connection.Close(); }
            }
        }

        [Fact()]
        public void RegisterFact()
        {
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                var repository = new UserAttributesRepository();

                var userID = int.MaxValue;
                var itemId = int.MaxValue;
                Assert.True(repository.Register(new UserAttributeEntity() { UserID = userID, ItemID = itemId, Value = @"create", }, connection, transaction)); // Insert
                Assert.True(repository.Register(new UserAttributeEntity() { UserID = userID, ItemID = itemId, Value = @"update", }, connection, transaction)); // Update
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

                var repository = new UserAttributesRepository();

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