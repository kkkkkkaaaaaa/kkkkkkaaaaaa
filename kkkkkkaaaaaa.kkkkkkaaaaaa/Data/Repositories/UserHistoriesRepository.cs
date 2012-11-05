using System.Collections.Generic;
using System.Data.Common;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.Data.TableDataGateways;
using kkkkkkaaaaaa.DataTransferObjects;

namespace kkkkkkaaaaaa.Data.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class UserHistoriesRepository : KandaRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public UserHistoryEntity Find(UserHistoriesCriteria criteria, DbConnection connection, DbTransaction transaction)
        {
            var reader = default(KandaDbDataReader);

            try
            {
                reader = UserHistoriesGateway.Select(criteria, connection, transaction);

                var found = reader.Read() ? KandaDbDataMapper.MapToObject<UserHistoryEntity>(reader) : UserHistoryEntity.Empty;

                return found;
            }
            finally
            {
                if (reader != null) { reader.Close(); }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public UserHistoryEntity Find(long userId, DbConnection connection, DbTransaction transaction)
        {
            return this.Find(new UserHistoriesCriteria() { UserID = userId, }, connection, transaction);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="revision"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public UserHistoryEntity Find(long userId, int revision, DbConnection connection, DbTransaction transaction)
        {
            return this.Find(new UserHistoriesCriteria() { UserID = userId, Revision = revision, }, connection, transaction);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public IEnumerable<UserHistoryEntity> Get(long userId, DbConnection connection, DbTransaction transaction)
        {
            var reader = default(DbDataReader);

            try
            {
                reader = UserHistoriesGateway.Select(new UserHistoriesCriteria() { UserID = userId, }, connection, transaction);

                var entities = KandaDbDataMapper.MapToEnumerable<UserHistoryEntity>(reader);

                return entities;

            }
            finally
            {
                if (reader != null) { reader.Close(); }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Create(long userId, DbConnection connection, DbTransaction transaction, out int revision)
        {
            var created = UserHistoriesGateway.InsertSelect(new UserHistoryEntity() { UserID = userId, }, connection, transaction, out revision);

            return (created == 1);
        }


        /// <summary>
        /// コンストラクター。
        /// </summary>
        internal UserHistoriesRepository()
        {
            this.DoNothing();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        internal bool Truncate(DbConnection connection, DbTransaction transaction)
        {
            var error = UserHistoriesGateway.Truncate(connection, transaction);

            return (error == 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        internal bool Delete(long userId, DbConnection connection, DbTransaction transaction)
        {
            var deleted = UserHistoriesGateway.Delete(new UserHistoriesCriteria() { UserID = userId, }, connection, transaction);

            return (deleted == 1);
        }
    }
}