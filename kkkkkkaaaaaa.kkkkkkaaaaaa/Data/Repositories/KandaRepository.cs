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
        public static UserHistoriesRepository UserHistories
        {
            get { return KandaRepository._userHistories.Value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public static UserHistoryAttributesRepository UserHistoryAttributes
        {
            get { return KandaRepository._userHistoryAttributes.Value; }
        }

        /*

        /// <summary>
        /// 
        /// </summary>
        public static UserAttributeItemsRepository UserAttibuteItems
        {
            get { return KandaRepository._userAttributeItems.Value; }
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
        private readonly static Lazy<MembershipsRepository> _memberships = new Lazy<MembershipsRepository>(() => new MembershipsRepository(), LazyThreadSafetyMode.ExecutionAndPublication);
        /// <summary></summary>
        private readonly static Lazy<MembershipUsersRepository> _membershipUsers = new Lazy<MembershipUsersRepository>(() => new MembershipUsersRepository(), LazyThreadSafetyMode.ExecutionAndPublication);
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
        private readonly static Lazy<UsersRepository> _users = new Lazy<UsersRepository>(() => new UsersRepository(), LazyThreadSafetyMode.ExecutionAndPublication);
        /// <summary></summary>
        private readonly static Lazy<UserAttributesRepository> _userAttributes = new Lazy<UserAttributesRepository>(() => new UserAttributesRepository(), LazyThreadSafetyMode.ExecutionAndPublication);
        /// <summary></summary>
        private readonly static Lazy<UserHistoriesRepository> _userHistories = new Lazy<UserHistoriesRepository>(() => new UserHistoriesRepository(), LazyThreadSafetyMode.ExecutionAndPublication);
        /// <summary></summary>
        private readonly static Lazy<UserHistoryAttributesRepository> _userHistoryAttributes = new Lazy<UserHistoryAttributesRepository>(() => new UserHistoryAttributesRepository(), LazyThreadSafetyMode.ExecutionAndPublication);

        /*
        /// <summary></summary>
        private readonly static Lazy<UserAttributeItemsRepository> _userAttributeItems = new Lazy<UserAttributeItemsRepository>(LazyThreadSafetyMode.ExecutionAndPublication);
        */

        #endregion
    }
}
