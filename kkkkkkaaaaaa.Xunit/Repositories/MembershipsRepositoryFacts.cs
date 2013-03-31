using System;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Threading;
using System.Web.Security;
using Xunit;
using kkkkkkaaaaaa.Data.Repositories;
using kkkkkkaaaaaa.DataTransferObjects;

namespace kkkkkkaaaaaa.Xunit.Repositories
{
    public class MembershipsRepositoryFacts : KandaXunitRepositoryFacts
    {
        [Fact()]
        public void FindByIDFact()
        {
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                var entity = new MembershipEntity() {Name = new Random().Next().ToString(), Password = null, Enabled = true,};

                var repository = new MembershipsRepository();

                var status = MembershipCreateStatus.ProviderError;
                repository.Create(entity, connection, transaction, out status);

                var found = repository.Find(entity.ID, connection, transaction);

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
        public void FindByNameFact()
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
                var status = MembershipCreateStatus.ProviderError;
                repository.Create(new MembershipEntity() { Name = name, Password = @"", Enabled = false, }, connection, transaction, out status);

                var found = repository.Find(name, connection, transaction);

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

                var name = new Random().Next().ToString(CultureInfo.InvariantCulture);
                var password = new Random().Next().ToString(CultureInfo.InvariantCulture);
                var status = MembershipCreateStatus.ProviderError;
                repository.Create(new MembershipEntity() { Name = name, Password = password, Enabled = true, }, connction, transaction, out status);

                var found = repository.Find(name, password, connction, transaction);

                Assert.NotSame(MembershipEntity.Empty, found);
                Assert.NotEqual(MembershipEntity.Empty, found);
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
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                var repository = new MembershipsRepository();

                var name = new Random().Next().ToString(CultureInfo.InvariantCulture);
                var password = new Random().Next().ToString(CultureInfo.InvariantCulture);
                var status = MembershipCreateStatus.ProviderError;
                repository.Create(new MembershipEntity() { Name = name, Password = password, Enabled = true, CreatedOn = DateTime.Now, }, connection, transaction, out status);

                var id = repository.IdentCurrent(connection, transaction);
                Assert.True(0 < id);
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

                var repository = new MembershipsRepository();

                var name = new Random().Next().ToString(CultureInfo.InvariantCulture);
                var password = new Random().Next().ToString(CultureInfo.InvariantCulture);
                var status = MembershipCreateStatus.ProviderError;
                repository.Create(new MembershipEntity() { Name = name, Password = password, Enabled = true, CreatedOn = DateTime.Now, }, connection, transaction, out status);

                var id = repository.IdentCurrent(connection, transaction);
                var found = repository.Find(name, password, connection, transaction);
                Thread.Sleep(1000);
                found.Password = new Random().Next().ToString(CultureInfo.InvariantCulture);
                found.Enabled = false;
                found.UpdatedOn = DateTime.Now;
                repository.Update(found, connection, transaction);

                found = repository.Find(id, connection, transaction);

                Assert.True(found.CreatedOn.Ticks < found.UpdatedOn.Ticks);
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
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                var repository = new MembershipsRepository();

                var name = new Random().Next().ToString(CultureInfo.InvariantCulture);
                var status = MembershipCreateStatus.ProviderError;
                repository.Create(new MembershipEntity() { Name = name, Password = @"", }, connection, transaction, out status);

                var id = repository.IdentCurrent(connection, transaction);
                Assert.True(repository.Delete(id, connection, transaction));
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

                Assert.Throws<NotSupportedException>(() =>
                                                         {
                                                             var repository = new MembershipsRepository();
                                                             repository.Truncate(connction, transaction);
                                                         });
            }
            finally
            {
                if (transaction != null) { transaction.Rollback(); }
                if (connction != null) { connction.Close(); }
            }
        }
    }
}