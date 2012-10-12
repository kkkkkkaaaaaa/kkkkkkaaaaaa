using System;
using System.Data;
using System.Data.Common;
using Xunit;
using kkkkkkaaaaaa.Web.Repositories;
using kkkkkkaaaaaa.Xunit.Data;
using kkkkkkaaaaaa.Xunit.Repositories;

namespace kkkkkkaaaaaa.Xunit.Web.Repositories
{
    public class KandaRepositoryFacts : KandaXunitRepositoryFacts
    {
        [Fact()]
        public void GetUtcDateTimeFact()
        {
            var connection = default(DbConnection);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                var result = KandaRepository.GetUtcDateTime(connection);
                Assert.True(default(DateTime) < result);

            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }


        /*
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

                //var repository = new
                //Assert.NotNull(repository.Find(, connection, transaction))
            }
            finally
            {
                if (transaction != null) { transaction.Rollback(); }
                if (connection != null) { connection.Close(); }
            }
        }

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

                //id = int.MaxValue;
                //var repository = new
                //Assert.NotNull(repository.Get, connection, transaction))
            }
            finally
            {
                if (transaction != null) { transaction.Rollback(); }
                if (connection != null) { connection.Close(); }
            }
        }

        [Fact()]
        public void SearchFact()
        {
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                //var repository = new
                //Assert.NotNull(repository.Search, connection, transaction))
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

                //var repository = new
                //Assert.True(repository.Create)
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

                //var repository = new
                //Assert.True(repository.Update(, connection, transaction))
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

                //var repository = new
                //Assert.True(repository.Register(, connection, transaction))
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

                //var repository = new
                //Assert.True(repository.Delete(, connection, transaction))
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

                //var repository = new
                //Assert.True(repository.Truncate(, connection, transaction))
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