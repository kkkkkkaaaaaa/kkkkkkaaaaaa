using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class MembershipRolesRepository : KandaRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public ICollection<long> Get(MembershipRolesCriteria criteria, DbConnection connection, DbTransaction transaction)
        {
            var reader = default(KandaDbDataReader);

            try
            {
                reader = MembershipRolesGateway.Select(criteria, connection, transaction);

                var roles = new Collection<long>();
                while (reader.Read()) { roles.Add(reader.GetInt64(@"RoleID")); }

                return roles;
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
        public bool Create(MembershipRoleEntity entity, DbConnection connection, DbTransaction transaction)
        {
            var count = MembershipRolesGateway.Insert(entity, connection, transaction);

            return (count == 1);
        }


        /// <summary>
        /// コンストラクタ―。
        /// </summary>
        internal MembershipRolesRepository()
        {
            this.DoNothing();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        internal bool Delete(MembershipRolesCriteria criteria, DbConnection connection, DbTransaction transaction)
        {
            var deleted = MembershipRolesGateway.Delete(criteria, connection, transaction);

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
            var error = MembershipRolesGateway.Truncate(connection, transaction);

            return (error == 0);
        }
    }
}