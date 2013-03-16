using System.Data;
using System.Data.Common;
using Xunit;
using kkkkkkaaaaaa.Data.TableDataGateways;
using kkkkkkaaaaaa.DataTransferObjects;

namespace kkkkkkaaaaaa.Xunit.Repositories
{
    public class TableRepositoryFacts : KandaXunitRepositoryFacts
    {
         [Fact()]
        public void InsertFact()
         {
             var connection = default(DbConnection);
             var transaction = default(DbTransaction);

             try
             {
                 connection = this._factory.CreateConnection();
                 connection.Open();

                 transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                 var entity = new TableEntity() {  };
                 int affected;
                 var result =  TableGateway.Insert(entity, connection, transaction, out affected);
             }
             finally
             {
                 if (transaction != null) { transaction.Rollback(); }
                 if (connection != null) { connection.Close(); }
             }
         }
    }
}