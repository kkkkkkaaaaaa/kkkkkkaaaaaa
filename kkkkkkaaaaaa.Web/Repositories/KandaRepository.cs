using System;
using System.Data.Common;
using System.Threading;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.Web.Data;
using kkkkkkaaaaaa.Web.TableDataGateways;

namespace kkkkkkaaaaaa.Web.Repositories
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

        //public static MembershipRoleRepository MembershipRoles

        //public static MembershipAuthorizationsRepository MembershipAuthorizations

        /// <summary>
        /// 
        /// </summary>
        public static RolesRepository Roles
        {
            get { return KandaRepository._roles.Value; }
        }

        // public static RolesAuthorizationsRepository RoleAuthorizations

        /// <summary>
        /// 
        /// </summary>
        public static AuthorizationsRepository Authorization
        {
            get { return KandaRepository._authorizations.Value; }
        }

        /// <summary>
        /// Users の Repository を取得します。
        /// </summary>
        public static UsersRepository Users
        {
            get { return KandaRepository._users.Value; }
        }

        public static UserHistoriesRepository UserHistories
        {
            get { return KandaRepository._userHistories.Value; }
        }

        public static UserAttributesRepository UserAttributes
        {
            get { return KandaRepository._userAttributes.Value; }
        }
            
        public static UserAttributeHistoriesRepository UserAttributeHistories
        {
            get { return KandaRepository._userAttributeHistories.Value; }
        }
        
        /*
        public static UsersAttribtueItemsRepository UserAttibuteItems
        {
            get { return KandaRepository._userAttributeItems; }
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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        // public abstract bool Truncate(DbConnection connection, DbTransaction transaction);

        // public abstract T Find<T>(long id, DbConnection connection, DbTransaction transaction)

        // public abstract IEnumerable<T> Get<T>(T entity DbConnection connection, DbTransaction transaction) where T : Entity, new()

        // public abstract IEnumerable<T> Search<T>(T criteria, DbConnection connection, DbTransaction transaction)

        // public abstract bool Create(entity, DbConnection connection, DbTransaction transaction)

        // public abstract bool Update(entity, DbConnection connection, DbTransaction transaction)

        // public abstract bool Register(entity, DbConnection connection, DbTransaction transaction)

        // public abstract bool Delete(entity, DbConnection connection, DbTransaction transaction)

        // public abstract bool Truncate(entity, DbConnection connection, DbTransaction transaction)

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
        private readonly static Lazy<MembershipsRepository> _memberships = new Lazy<MembershipsRepository>(LazyThreadSafetyMode.ExecutionAndPublication);
        /// <summary></summary>
        //private readonly static Lazy<MembershipsAuthorizationsRepository> _membershipAuthorizations = new Lazy<MembershipsAuthorizationsRepository>(LazyThreadSafetyMode.ExecutionAndPublication);
        /// <summary></summary>
        private readonly static Lazy<AuthorizationsRepository> _authorizations = new Lazy<AuthorizationsRepository>(LazyThreadSafetyMode.ExecutionAndPublication);
        /// <summary></summary>
        //private readonly static Lazy<AuthorizationRolesRepository> _authorizationRoles = new Lazy<AuthorizationRolesRepository>(LazyThreadSafetyMode.ExecutionAndPublication);
        /// <summary></summary>
        private readonly static Lazy<RolesRepository> _roles = new Lazy<RolesRepository>(LazyThreadSafetyMode.ExecutionAndPublication);
        /// <summary></summary>
        //private readonly static Lazy<RoleMembershipsRepository> _rolesMemberships = new Lazy<RoleMembershipsRepositoryRepository>(LazyThreadSafetyMode.ExecutionAndPublication);

        /// <summary></summary>
        private readonly static Lazy<UsersRepository> _users = new Lazy<UsersRepository>(LazyThreadSafetyMode.ExecutionAndPublication);
        /// <summary></summary>
        private readonly static Lazy<UserHistoriesRepository> _userHistories = new Lazy<UserHistoriesRepository>(LazyThreadSafetyMode.ExecutionAndPublication);
        /// <summary></summary>
        private readonly static Lazy<UserAttributesRepository> _userAttributes = new Lazy<UserAttributesRepository>(LazyThreadSafetyMode.ExecutionAndPublication);
        /// <summary></summary>
        private readonly static Lazy<UserAttributeHistoriesRepository> _userAttributeHistories = new Lazy<UserAttributeHistoriesRepository>(LazyThreadSafetyMode.ExecutionAndPublication);
        /// <summary></summary>
        //private readonly static Lazy<UserAttributeItemsRepository> _userAttributeItems = new Lazy<UserAttributeItemsRepository>(LazyThreadSafetyMode.ExecutionAndPublication);

        #endregion
    }
}

