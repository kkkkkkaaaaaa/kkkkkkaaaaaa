using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.Data.Extensions;
using kkkkkkaaaaaa.Data.TableDataGateways;
using kkkkkkaaaaaa.DataTransferObjects;

namespace kkkkkkaaaaaa.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class MembershipUsersRepository : KandaRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public long Find(long userId, DbConnection connection, DbTransaction transaction)
        {
            var reader = default(IDataReader);

            try
            {
                reader = MembershipUsersGateway.Select(new MembershipUsersCriteria() { UserID = userId, }, connection, transaction);

                var found = (reader.Read() ? reader.GetInt64(@"MembershipID") : -1L);

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
        /// <param name="membershipId"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public ICollection<long> Get(long membershipId, DbConnection connection, DbTransaction transaction)
        {
            var reader = default(KandaDbDataReader);

            try
            {
                reader = MembershipUsersGateway.Select(new MembershipUsersCriteria() { MembershipID = membershipId, }, connection, transaction);

                var gotten = new Collection<long>();
                while (reader.Read()) { gotten.Add(reader.GetInt64(@"UserID")); }

                return gotten;
            }
            finally
            {
                if (reader != null) { reader.Close(); }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Create(MembershipUserEntity entity, DbConnection connection, DbTransaction transaction)
        {
            var error = MembershipUsersGateway.Insert(entity, connection, transaction);

            return (error == KandaTableDataGateway.NO_ERRORS);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        internal bool Delete(MembershipUsersCriteria criteria, DbConnection connection, DbTransaction transaction)
        {
            var deleted = MembershipUsersGateway.Delete(criteria, connection, transaction);

            return (0 <= deleted);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        internal bool Truncate(DbConnection connection, DbTransaction transaction)
        {
            var error = MembershipUsersGateway.Truncate(connection, transaction);

            return (error == 0);
        }


        /// <summary>
        /// コンストラクター。
        /// </summary>
        internal MembershipUsersRepository()
        {
            this.DoNothing();
        }
    }
}