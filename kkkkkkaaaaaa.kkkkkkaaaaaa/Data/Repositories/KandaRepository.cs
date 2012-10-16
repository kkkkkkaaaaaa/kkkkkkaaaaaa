using System;
using System.Data.Common;
using System.Threading;
using kkkkkkaaaaaa.Data.TableDataGateways;

namespace kkkkkkaaaaaa.Data.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class KandaRepository
    {
        /// <summary>
        /// Memberships の Repository を取得します。
        /// </summary>
        public static MembershipsRepository Memberships
        {
            get { return KandaRepository._memberships.Value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public static MembershipUsersRepository MembershipUsers
        {
            get { return KandaRepository._membershipUsers.Value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public static MembershipRolesRepository MembershipRoles
        {
            get { return KandaRepository._membershipRoles.Value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public static MembershipAuthorizationsRepository MembershipAuthorizations
        {
            get { return KandaRepository._membershipAuthorizations.Value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public static RolesRepository Roles
        {
            get { return KandaRepository._roles.Value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public static AuthorizationsRepository Authorizations
        {
            get { return KandaRepository._authorizations.Value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public static RoleAuthorizationsRepository RoleAuthorizations
        {
            get { return KandaRepository._roleAuthorizations.Value; }
        }


        /// <summary>
        /// Users の Repository を取得します。
        /// </summary>
        public static UsersRepository Users
        {
            get { return KandaRepository._users.Value; }
        }

        /*
        /// <summary>
        /// 
        /// </summary>
        public static UserHistoriesRepository UserHistories
        {
            get { return KandaRepository._userHistories.Value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public static UserAttributeItemsRepository UserAttibuteItems
        {
            get { return KandaRepository._userAttributeItems.Value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public static UserAttributesRepository UserAttributes
        {
            get { return KandaRepository._userAttributes.Value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public static UserAttributeHistoriesRepository UserAttributeHistories
        {
            get { return KandaRepository._userAttributeHistories.Value; }
        }
        */


        /// <summary>
        /// システムの現在時刻を取得します。
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public static DateTime GetUtcDateTime(DbConnection connection, DbTransaction transaction = null)
        {
            var utc = KandaTableDataGateway.GetUtcDateTime(connection, transaction);

            return utc;
        }


        #region Protected members...

        /// <summary>
        /// 何もしません。
        /// </summary>
        protected void DoNothing()
        {
            // 何もしない
        }

        #endregion

        #region Private members...

        /// <summary></summary>
        private static readonly Lazy<MembershipsRepository> _memberships = new Lazy<MembershipsRepository>(() => new MembershipsRepository(), LazyThreadSafetyMode.ExecutionAndPublication);
        /// <summary></summary>
        private static readonly Lazy<MembershipUsersRepository> _membershipUsers = new Lazy<MembershipUsersRepository>(() => new MembershipUsersRepository(), LazyThreadSafetyMode.ExecutionAndPublication);
        /// <summary></summary>
        private readonly static Lazy<MembershipRolesRepository> _membershipRoles = new Lazy<MembershipRolesRepository>(() => new MembershipRolesRepository(), LazyThreadSafetyMode.ExecutionAndPublication);
        /// <summary></summary>
        private readonly static Lazy<MembershipAuthorizationsRepository> _membershipAuthorizations = new Lazy<MembershipAuthorizationsRepository>(() => new MembershipAuthorizationsRepository(), LazyThreadSafetyMode.ExecutionAndPublication);
        /// <summary></summary>
        private readonly static Lazy<AuthorizationsRepository> _authorizations = new Lazy<AuthorizationsRepository>(() => new AuthorizationsRepository(), LazyThreadSafetyMode.ExecutionAndPublication);
        /// <summary></summary>
        private readonly static Lazy<RolesRepository> _roles = new Lazy<RolesRepository>(() => new RolesRepository(), LazyThreadSafetyMode.ExecutionAndPublication);
        /// <summary></summary>
        private readonly static Lazy<RoleAuthorizationsRepository> _roleAuthorizations = new Lazy<RoleAuthorizationsRepository>(() => new RoleAuthorizationsRepository(), LazyThreadSafetyMode.ExecutionAndPublication);

        /// <summary></summary>
        private static readonly Lazy<UsersRepository> _users = new Lazy<UsersRepository>(() => new UsersRepository(), LazyThreadSafetyMode.ExecutionAndPublication);
        /*
        /// <summary></summary>
        private readonly static Lazy<UserHistoriesRepository> _userHistories = new Lazy<UserHistoriesRepository>(LazyThreadSafetyMode.ExecutionAndPublication);
        /// <summary></summary>
        private readonly static Lazy<UserAttributesRepository> _userAttributes = new Lazy<UserAttributesRepository>(LazyThreadSafetyMode.ExecutionAndPublication);
        /// <summary></summary>
        private readonly static Lazy<UserAttributeHistoriesRepository> _userAttributeHistories = new Lazy<UserAttributeHistoriesRepository>(LazyThreadSafetyMode.ExecutionAndPublication);
        /// <summary></summary>
        private readonly static Lazy<UserAttributeItemsRepository> _userAttributeItems = new Lazy<UserAttributeItemsRepository>(LazyThreadSafetyMode.ExecutionAndPublication);
        */

        #endregion

        /*
        public Entity Find(long id, DbConnection connection, DbTransaction transaction)
        {
            var reader = default(DbDataReader);

            try
            {
                reader = Gateway.Select(new Entity(){ ID = id, Enabled = true, }, connection, transaction);

                var entity = (reader.Read() ? KandaDbDataMapper.MapToObject<Entity>(reader) : default(Entity));
            }
            finally
            {
                if (reader != null) { reader.Close(); }
            }
        }
        
        public IEnumerable<Entity> Get(Entity entity, DbConnection connection, DbTransaction transaction)
        {
            var reader = default(DbDataReader);

            try
            {
                reader = sGateway.Select(entity, connection, transaction);

                var entities = KandaDbDataMapper.MapToEnumerable<Entity>(reader);

                return entities;
            }
            finally
            {
                if (reader != null) { reader.Close(); }
            }
        }
        
        public IEnumerable<MembershipAuthorizationEntity> Get(Entity entity, DbConnection connection, DbTransaction transaction)
        {
            var reader = default(DbDataReader);

            try
            {
                reader = sGateway.Select(entity, connection, transaction);

                var entities = KandaDbDataMapper.MapToEnumerable<Entitiy>(reader);

                return entity;
            }
            finally
            {
                if (reader != null) { reader.Close(); }
            }
        }

        public IEnumerable<Entitiy> Search(Criteria criteria, DbConnection connection, DbTransaction transaction)
        {
            var reader = default(DbDataReader);

            try
            {
                reader = KandaTableDataGateway.Select(criteria, connection, transaction);

                var entities = KandaDbDataMapper.MapToEnumerable<UserAttributeItemEntitiy>(reader);

                return entity;
            }
            finally
            {
                if (reader != null) { reader.Close(); }
            }
        }
        
        public bool Create(Entity entity, DbConnection connection, DbTransaction transaction)
        {
            var created = sGateway.Insert(entity, connection, transaction);

            return (created == 1);
        }

        public bool Update(Entity entity, DbConnection connection, DbTransaction transaction)
        {
            var updated = sGateway.Update(entity, connection, transaction);

            return (updated == 1);
        }

        public bool Delete(Entity entity, DbConnection connection, DbTransaction transaction)
        {
            var deleted = sGateway.Delete(entity, connection, transaction);

            return (deleted == 1);
        }

        public bool Truncate(DbConnection connection, DbTransaction transaction)
        {
            var error = Gateway.Truncate(connection, transaction);

            return (error == 0);
        }
        */
    }
}
