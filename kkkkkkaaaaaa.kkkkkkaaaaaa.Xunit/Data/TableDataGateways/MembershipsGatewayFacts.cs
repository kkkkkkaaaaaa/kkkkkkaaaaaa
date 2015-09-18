using System;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using kkkkkkaaaaaa.Data.TableDataGateways;
using kkkkkkaaaaaa.DataTransferObjects;
using Xunit;

namespace kkkkkkaaaaaa.kkkkkkaaaaaa.Xunit.Data.TableDataGateways
{
    public class MembershipsGatewayFacts : KandaTableDataGatewayFacts
    {
        [Fact()]
        public async Task InserAsyncFact()
        {
            var entity = new MembershipEntity()
            {
                ID = 0,
                Name = string.Format(@"MembershipsGatewayFacts.InserAsyncFact.{0}", new Random().Next()),
                Password = @"",
                Enabled = true,
                CreatedOn = DateTime.Now,
            };

            var connection = this.Factory.CreateConnection();
            var transaction = default(DbTransaction);
            var token = CancellationToken.None;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                var inserted = await MembershipsGateway.InsertAsync(entity, connection, transaction, token);
                Assert.True(0L < inserted);
            }
            finally
            {
                if (transaction != null) { transaction.Rollback(); }
                if (connection != null) { connection.Close(); }
            }

        }

        [Fact()]
        public async Task SelectAsyncFact()
        {
            var connection = this.Factory.CreateConnection();
            var transaction = default(DbTransaction);
            var token = CancellationToken.None;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                // 登録
                var entity = new MembershipEntity()
                {
                    ID = 0,
                    Name = string.Format("MembershipsGatewayFacts.FindAsyncFact(new MembershipEntity {{ Name={0} }}) ", new Random().Next()),
                    Password = @"password",
                    Enabled = true,
                    Email = @"email@example.com",
                    CreatedOn = DateTime.Now,
                    // UpdatedOn = CreatedOn,
                };
                var inserted = await MembershipsGateway.InsertAsync(entity, connection, transaction, token);
                Assert.True(0 < inserted);

                // 取得
                var criteria = new MembershipsCriteria()
                {
                    ID = inserted,
                };
                var selected = await MembershipsGateway.SelectAsync(criteria, connection, transaction, token);
                Assert.True(selected.Read());
                selected.Close();

                // 削除
                var deleted = await MembershipsGateway.DeleteAsync(inserted, connection, transaction, token);
                Assert.True(deleted == 1);

                transaction.Commit();
            }
            catch
            {
                if (transaction != null) { transaction.Rollback(); }
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }
    }
}