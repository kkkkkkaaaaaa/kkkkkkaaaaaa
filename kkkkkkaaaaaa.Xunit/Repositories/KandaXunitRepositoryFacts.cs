using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.Web.Data;

namespace kkkkkkaaaaaa.Xunit.Repositories
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