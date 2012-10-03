using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.Web.Data;

namespace kkkkkkaaaaaa.Xunit.Web.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class KandaXunitRepositoryFacts
    {
        /// <summary>
        /// 
        /// </summary>
        protected KandaDbProviderFactory _factory = KandaProviderFactory.Instance;


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
             connection,  transaction

            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serialize);

                var repository = new
                Assert.True(repository);
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