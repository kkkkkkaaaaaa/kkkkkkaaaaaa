using System.Data;
using System.Data.Common;
using Xunit;
using kkkkkkaaaaaa.Web.DataTransferObjects;
using kkkkkkaaaaaa.Web.Repositories;
using kkkkkkaaaaaa.Xunit.Repositories;

namespace kkkkkkaaaaaa.Xunit.Web.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class RoleAuthorizationsRepositoryFacts : KandaXunitRepositoryFacts
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

                var repository = new RoleAuthorizationsRepository();

                long roleId = long.MaxValue;
                long authorizationId = long.MaxValue;
                Assert.NotNull(repository.Get(new RoleAuthorizationEntity() { RoleID  = roleId, AuthorizationID = authorizationId, Enabled = true,}, connection, transaction));
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

                var repository = new RoleAuthorizationsRepository();

                long roleId = long.MaxValue;
                long authorizationId = long.MaxValue;
                Assert.True(repository.Create(new RoleAuthorizationEntity() { RoleID = roleId, AuthorizationID = authorizationId, Enabled = false, }, connection, transaction));
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

                var repository = new RoleAuthorizationsRepository();

                long roleId = long.MaxValue;
                long authorizationId = long.MaxValue;
                Assert.True(repository.Create(new RoleAuthorizationEntity() { RoleID = roleId, AuthorizationID = authorizationId, Enabled = true, }, connection, transaction));
                Assert.True(repository.Update(new RoleAuthorizationEntity() { RoleID = roleId, AuthorizationID = authorizationId, Enabled = false, }, connection, transaction));
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

                var repository = new RoleAuthorizationsRepository();
                Assert.True(repository.Truncate(connection, transaction));
            }
            finally
            {
                if (transaction != null) { transaction.Rollback(); }
                if (connection != null) { connection.Close(); }
            }
        }

        /*
        [Fact()]
        public void FindFact()
        public void GetFact()
        public void SearchFact()
        public void CreateFact()
        public void UpdateFact()
        public void RegisterFact()
        public void DeleteFact()
        public void TruncateFact()
        {
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                //var repository = new
                //Assert.True(repository(, connection, transaction));
            }
            finally
            {
                if (transaction != null) { transaction.Rollback(); }
                if (connection != null) { connection.Close(); }
            }
        }
        */
    }
}