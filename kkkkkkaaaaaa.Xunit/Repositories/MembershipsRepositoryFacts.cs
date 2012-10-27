using System;
using System.Data;
using System.Data.Common;
using System.Globalization;
using Xunit;
using kkkkkkaaaaaa.Data.Repositories;
using kkkkkkaaaaaa.DataTransferObjects;

namespace kkkkkkaaaaaa.Xunit.Repositories
{
    public class MembershipsRepositoryFacts : KandaXunitRepositoryFacts
    {
        [Fact()]
        public void FindByUserIDFact()
        {
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                var repository = new MembershipsRepository();
                var name = new Random().Next().ToString(CultureInfo.InvariantCulture);
                repository.Create(new MembershipEntity() { Name = name, Password = @"", Enabled = true, }, connection, transaction);

                var id = repository.IdentCurrent(connection, transaction);
                var found = repository.Find(id, connection, transaction);

                Assert.NotSame(MembershipEntity.Empty, found);
                Assert.NotEqual(MembershipEntity.Empty, found);
            }
            finally
            {
                if (transaction != null) { transaction.Rollback(); }
                if (connection != null) { connection.Close(); }
            }
        }

        [Fact()]
        public void FindByNameAndPasswordFact()
        {
            var connction = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connction = this._factory.CreateConnection();
                connction.Open();

                transaction = connction.BeginTransaction(IsolationLevel.Serializable);
                
                var repository = new MembershipsRepository();

                var name = @"MembershipsRepositoryFacts.FindByNameAndPasswordFact()";
                var password = @"MembershipsRepositoryFacts.FindByNameAndPasswordFact()";
                repository.Create(new MembershipEntity() { Name = name, Password = password, Enabled = true, }, connction, transaction);

                var found = repository.Find(name, password, connction, transaction);
                Assert.True(0 < found.ID);
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

                var name = @"MembershipsRepositoryFacts.FindByIDFact()";
                var password = @"MembershipsRepositoryFacts.FindByIDFact()";
                repository.Create(new MembershipEntity() { Name = name, Password = password, Enabled = true, }, connction, transaction);

                var id = repository.IdentCurrent(connction, transaction);
                var found = repository.Find(id, connction, transaction);
                Assert.True(0 < found.ID);
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

                var name = @"MembershipsRepositoryFacts.FindByIDFact()";
                var password = @"MembershipsRepositoryFacts.FindByIDFact()";
                repository.Create(new MembershipEntity() { Name = name, Password = password, Enabled = true, }, connction, transaction);

                var id = repository.IdentCurrent(connction, transaction);
                Assert.True(0 < id);
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

                var repository = new MembershipsRepository();

                var id = long.MaxValue;
                var createdOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                repository.Create(new MembershipEntity() { ID = id, Name = @"System", Password = @"", Enabled = true, CreatedOn = createdOn, }, connection, transaction);

                var updatedOn = KandaRepository.GetUtcDateTime(connection, transaction);
                Assert.True(repository.Update(new MembershipEntity() { ID = id, Name = @"System", Password = @"", Enabled = true, UpdatedOn = updatedOn, }, connection, transaction));
                Assert.Equal(id, repository.Find(id, connection, transaction).ID);
            }
            finally
            {
                if (transaction != null) { transaction.Rollback(); }
                if (connection != null) { connection.Close(); }
            }
        }


        [Fact()]
        public void DeleteFact()
        {
            var connction = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connction = this._factory.CreateConnection();
                connction.Open();

                transaction = connction.BeginTransaction(IsolationLevel.Serializable);

                var repository = new MembershipsRepository();

                repository.Create(new MembershipEntity() { Name = @"name", Password = @"password", }, connction, transaction);

                var id = repository.IdentCurrent(connction, transaction);
                Assert.True(repository.Delete(id, connction, transaction));
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
                    //var createdOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                    //Assert.True(repository.Create(new MembershipEntity() { ID = 1, Name = @"System", Password = @"", Enabled = true, CreatedOn = createdOn, }, connction, transaction));
                    //Assert.True(repository.Create(new MembershipEntity() { ID = 2, Name = @"Administrator", Password = @"", Enabled = true, CreatedOn = createdOn, }, connction, transaction));
                    //Assert.True(repository.Create(new MembershipEntity() { ID = 3, Name = @"User", Password = @"", Enabled = true, CreatedOn = createdOn, }, connction, transaction));

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