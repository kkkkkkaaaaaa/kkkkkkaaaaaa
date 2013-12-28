using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using kkkkkkaaaaaa.Data;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.Data.TableDataGateways;
using kkkkkkaaaaaa.DataTransferObjects;

namespace kkkkkkaaaaaa.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class RoleAuthorizationsRepository : KandaRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public ICollection<long> Get(RoleAuthorizationsCriteria criteria, DbConnection connection, DbTransaction transaction)
        {
            var reader = default(KandaDbDataReader);

            try
            {
                reader = RoleAuthorizationsGateway.Select(criteria, connection, transaction);

                var authorizations = new Collection<long>();
                while (reader.Read()) { authorizations.Add(reader.GetInt64(@"AuthorizationID")); }

                return authorizations;
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
        public bool Create(RoleAuthorizationEntity entity, DbConnection connection, DbTransaction transaction)
        {
            var created = RoleAuthorizationsGateway.Insert(entity, connection, transaction);

            return (created == 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        internal bool Delete(RoleAuthorizationsCriteria criteria, DbConnection connection, DbTransaction transaction)
        {
            var deleted = RoleAuthorizationsGateway.Delete(criteria, connection, transaction);

            return (0 <= deleted);
        }

        internal bool Truncate(DbConnection connection, DbTransaction transaction)
        {
            var error = RoleAuthorizationsGateway.Truncate(connection, transaction);

            return (error == 0);
        }
    }
}
