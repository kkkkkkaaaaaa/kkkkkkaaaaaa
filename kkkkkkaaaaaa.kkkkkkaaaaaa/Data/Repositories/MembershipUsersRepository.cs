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
    public class MembershipUsersRepository : KandaRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public IEnumerable<MembershipUserEntity> Get(MembershipUsersCriteria criteria, DbConnection connection, DbTransaction transaction)
        {
            var reader = default(DbDataReader);

            try
            {
                reader = MembershipUsersGateway.Select(criteria, connection, transaction);

                var gotten = KandaDbDataMapper.MapToEnumerable<MembershipUserEntity>(reader);

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
        public bool Register(MembershipUserEntity entity, DbConnection connection, DbTransaction transaction)
        {
            return (this.Update(entity, connection, transaction) || this.Create(entity, connection, transaction));
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

            return (error == 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Update(MembershipUserEntity entity, DbConnection connection, DbTransaction transaction)
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Delete(MembershipUserEntity entity, DbConnection connection, DbTransaction transaction)
        {
            var deleted = MembershipUsersGateway.Delete(entity, connection, transaction);

            return (0 < deleted);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Truncate(DbConnection connection, DbTransaction transaction)
        {
            var error = MembershipUsersGateway.Truncate(connection, transaction);

            return (error == 0);
        }

        /// <summary>
        /// 
        /// </summary>
        internal MembershipUsersRepository()
        {
            this.DoNothing();
        }
    }
}