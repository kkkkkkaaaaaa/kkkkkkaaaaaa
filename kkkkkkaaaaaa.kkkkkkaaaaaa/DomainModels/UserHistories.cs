using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using kkkkkkaaaaaa.Data.Repositories;
using kkkkkkaaaaaa.DataTransferObjects;

namespace kkkkkkaaaaaa.DomainModels
{
    public class UserHistories : KandaDomainModel
    {
        private long _userId;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        public UserHistories(long userId)
        {
            this._userId = userId;
        }

        public long UserID { get { return this._userId; } }

        public ICollection<UserHistory> Histories { get; set; }

        public UserHistories Get()
        {
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                var histories = KandaRepository.UserHistories.Get(this.UserID, connection, transaction);
                foreach (var history in histories)
                {
                    this.Histories.Add(new UserHistory(new UserHistoryEntity() { UserID = this.UserID, Revision = history.Revision, }));
                }

                transaction.Commit();

                return this;
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

        public UserHistory Find(int revision)
        {

            return this;
        }

        public UserHistory Create()
        {
            return this;
        }
    }
}