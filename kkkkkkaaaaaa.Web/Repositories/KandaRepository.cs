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
    public class KandaRepository
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

        // public static UsersAttribtuesRepository UserAttibutes

        // public static UsersAttribtueItemsRepository UserAttibuteItems


        /// <summary>
        /// システムの現在時刻を取得します。
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public DateTime GetUtcDateTime(DbConnection connection, DbTransaction transaction = null)
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
        //private readonly static Lazy<UserAttributesRepository> _userAttributes = new Lazy<UserAttributesRepository>(LazyThreadSafetyMode.ExecutionAndPublication);
        /// <summary></summary>
        //private readonly static Lazy<UserAttributeItemsRepository> _userAttributeItems = new Lazy<UserAttributeItemsRepository>(LazyThreadSafetyMode.ExecutionAndPublication);

        #endregion
    }
}

