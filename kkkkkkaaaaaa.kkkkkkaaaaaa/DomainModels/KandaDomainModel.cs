using System;
using System.Data;
using System.Data.Common;
using System.Threading;
using kkkkkkaaaaaa.Data;
using kkkkkkaaaaaa.Data.Repositories;
using kkkkkkaaaaaa.DataTransferObjects;

namespace kkkkkkaaaaaa.DomainModels
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class KandaDomainModel
    {
        public static bool Reset()
        {
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = KandaProviderFactory.Instance.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                var result = false;
                if (!KandaDomainModel.resetMemberships(connection, transaction)) { transaction.Rollback(); }
                //else if (!KandaDomainModel.resetMemberships(connection, transaction)) { transaction.Rollback(); }
                else
                {
                    transaction.Commit();
                    result = true;
                }
                return result;
            }
            catch
            {
                if (transaction != null) { transaction.Rollback(); }
                throw;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }

        public abstract long ID { get; }

        #region Protected members...

        /// <summary>
        /// もしません。
        /// </summary>
        protected void DoNothing()
        {
            // もしない
        }

        /// <summary></summary>
        protected readonly KandaProviderFactory _factory = KandaProviderFactory.Instance;

        #endregion

        #region Private members...

        private static bool resetMemberships(DbConnection connection, DbTransaction transaction)
        {
            if (!KandaRepository.Memberships.Truncate(connection, transaction)) { return false; }

            var createdOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            if (!KandaRepository.Memberships.Create(new MembershipEntity() { ID = 1, Name = @"System", Password = @"", CreatedOn = createdOn, }, connection, transaction)) { return false; }
            if (!KandaRepository.Memberships.Create(new MembershipEntity() { ID = 2, Name = @"Administrator", Password = @"", CreatedOn = createdOn, }, connection, transaction)) { return false; }
            if (!KandaRepository.Memberships.Create(new MembershipEntity() { ID = 3, Name = @"User", Password = @"", CreatedOn = createdOn, }, connection, transaction)) { return false; }
            if (!KandaRepository.Memberships.Create(new MembershipEntity() { ID = 4, Name = @"Tester", Password = @"", CreatedOn = createdOn, }, connection, transaction)) { return false; }

            return true;
        }

        /*
        private static bool reset(DbConnection connection, DbTransaction transaction)
        {
            if (!KandaRepository..Truncate(connection, transaction)) { return false; }
            if (!KandaRepository..Create(new MembershipEntity() { }, connection, transaction)) { return false; };

            return true;
        }
        */

        #endregion
    }
}