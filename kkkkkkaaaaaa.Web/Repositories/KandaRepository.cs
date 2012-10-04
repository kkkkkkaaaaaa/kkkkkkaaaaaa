using System;
using System.Collections.Generic;
using System.Data;
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
        
        /// <summary>
        /// 
        /// </summary>
        public static UserAttributeItemsRepository UserAttibuteItems
        {
            get { return KandaRepository._userAttributeItems.Value; }
        }


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
        private readonly static Lazy<UserAttributeItemsRepository> _userAttributeItems = new Lazy<UserAttributeItemsRepository>(LazyThreadSafetyMode.ExecutionAndPublication);

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

        public IEnumerable<Entitiy> Get(Entity entity, DbConnection connection, DbTransaction transaction)
        {
            var reader = default(DbDataReader);

            try
            {
                reader = KandaTableDataGateway.Select(entity, connection, transaction);

                var entities = KandaDbDataMapper.MapToEnumerable<UserAttributeItemEntitiy>(reader);

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

        public bool Create(Entitiy entity, DbConnection connection, DbTransaction transaction)
        {
            var count = Gateway.Insert(entity, connection, transaction);

            return (count == 1);
        }

        public bool Update(Entitiy entity, DbConnection connection, DbTransaction transaction)
        {
            var count = Gateway.Update(entity, connection, transaction);

            return (count == 1);
        }

        public bool Register(Entitiy entity, DbConnection connection, DbTransaction transaction)
        {
            if (Gateway.Udpate(entity, connection, transaction) == 1) { return true; }

            if (Gateway.Insert(entity, connection, transaction) == 1) { return true; }

            return false;
        }

        public bool Delete(Entitiy entity, DbConnection connection, DbTransaction transaction)
        {
            var deleted = Gateway.Delete(entity, connection, transaction);

            return (deleted == 1);
        }

        public bool Truncate(DbConnection connection, DbTransaction transaction)
        {
            return Gateway.Truncate(connection, transaction);
        }
        */
    }
}

