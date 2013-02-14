using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading;
using kkkkkkaaaaaa.Data;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.Data.Repositories;
using kkkkkkaaaaaa.DataTransferObjects;

namespace kkkkkkaaaaaa.DomainModels
{
    /// <summary>
    /// 
    /// </summary>
    public class Membership : KandaDomainModel
    {
        /// <summary>
        /// 。
        /// </summary>
        public event Action<Membership, MembershipEntity> Found;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public Membership(MembershipEntity entity)
        {
            this._entity = entity;
            this.Users = new Collection<long>();
            this.Roles = new Collection<long>();
            this.Authorizations = new Collection<long>();
        }


        /// <summary>
        /// 
        /// </summary>
        public long ID
        {
            get { return this._entity.ID; }
        }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<long> Users { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<long> Roles { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<long> Authorizations { get; private set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool Exists(string name)
        {
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = KandaProviderFactory.Instance.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                var found = KandaRepository.Memberships.Find(name, connection, transaction);

                transaction.Commit();

                return (0 < found.ID);
            }
            catch
            {
                if (transaction != null) { transaction.Rollback(); }
                throw;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Exists()
        {
            return Membership.Exists(this._entity.Name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Membership Find()
        {
            var result = this;
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                var found = ((0 < this.ID)
                             ? KandaRepository.Memberships.Find(this.ID, connection, transaction)
                             : KandaRepository.Memberships.Find(this._entity.Name, this._entity.Password, connection, transaction));

                KandaDataMapper.MapToObject(found, this._entity);

                this.Users = KandaRepository.MembershipUsers.Get(this.ID, connection, transaction);
                this.Roles = KandaRepository.MembershipRoles.Get(new MembershipRolesCriteria() { MembershipID = this.ID, }, connection, transaction);
                this.Authorizations = KandaRepository.MembershipAuthorizations.Get(new MembershipAuthorizationsCriteria() { MembershipID = this.ID, }, connection, transaction);

                transaction.Commit();

                if (this.Found != null) { this.Found(this, found); }

                return result;
            }
            catch
            {
                if (transaction != null) { transaction.Rollback(); }
                throw;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Membership Create()
        {
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                this._entity.Enabled = true;
                this._entity.CreatedOn = KandaRepository.GetUtcDateTime(connection, transaction);
                if (!KandaRepository.Memberships.Create(this._entity, connection, transaction)) { transaction.Rollback(); }
                else
                {
                    this._entity.ID = KandaRepository.Memberships.IdentCurrent(connection, transaction);
                    if (this.ID < 1) { transaction.Rollback(); }
                    else if (!this.createUsers(connection, transaction)) { transaction.Rollback(); }
                    else if (!this.createRoles(connection, transaction)) { transaction.Rollback(); }
                    else if (!this.createAuthorization(connection, transaction)) { transaction.Rollback(); }
                    else { transaction.Commit(); }
                }

                return this;
            }
            catch
            {
                if (transaction != null) { transaction.Rollback(); }
                throw;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Membership Update()
        {
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                this._entity.UpdatedOn = KandaRepository.GetUtcDateTime(connection, transaction);
                if (!KandaRepository.Memberships.Update(this._entity, connection, transaction)) { transaction.Rollback(); }
                else if (!this.updateUsers(connection, transaction)) { transaction.Rollback(); }
                else if (!this.updateRoles(connection, transaction)) { transaction.Rollback(); }
                else if (!this.updateAuthorizations(connection, transaction)) { transaction.Rollback(); }
                else { transaction.Commit(); }

                return this;
            }
            catch
            {
                if (transaction != null) { transaction.Rollback(); }
                throw;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal Membership Delete()
        {
            var result = this;
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                if (!this.deleteUsers(connection, transaction)) { transaction.Rollback(); }
                else if (!this.deleteRoles(connection, transaction)) { transaction.Rollback(); }
                else if (!this.deleteAuthorizations(connection, transaction)) { transaction.Rollback(); }
                else if (!KandaRepository.Memberships.Delete(this.ID, connection, transaction)) { transaction.Rollback(); }
                else
                {
                    result = new Membership(new MembershipEntity());
                    transaction.Commit();
                }

                return result;
            }
            catch
            {
                if (transaction != null) { transaction.Rollback(); }
                throw;
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }


        #region Private members...

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transction"></param>
        /// <returns></returns>
        private bool createUsers(DbConnection connection, DbTransaction transction)
        {
            foreach (var user in this.Users)
            {
                if (KandaRepository.MembershipUsers.Create(new MembershipUserEntity() { MembershipID = this.ID, UserID = user, }, connection, transction)) { continue; }

                return false;
            }

            // return this.Users.All(user => KandaRepository.MembershipUsers.Create(new MembershipUserEntity() { MembershipID = this.ID, UserID = user, }, connection, transction));
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transction"></param>
        /// <returns></returns>
        private bool createRoles(DbConnection connection, DbTransaction transction)
        {
            foreach (var role in this.Roles)
            {
                if (KandaRepository.MembershipRoles.Create(new MembershipRoleEntity() { MembershipID = this.ID, RoleID = role, }, connection, transction)) { continue; }

                return false;
            }

            // return this.Roles.All(role => KandaRepository.MembershipRoles.Create(new MembershipRoleEntity() { MembershipID = this.ID, RoleID = role, }, connection, transction));
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transction"></param>
        /// <returns></returns>
        private bool createAuthorization(DbConnection connection, DbTransaction transction)
        {
            foreach (var authorization in this.Authorizations)
            {
                if (KandaRepository.MembershipAuthorizations.Create(new MembershipAuthorizationEntity() { MembershipID = this.ID, AuthorizationID = authorization, }, connection, transction)) { continue; }

                return false;
            }
            // return this.Authorizations.All(authorization => KandaRepository.MembershipAuthorizations.Create(new MembershipAuthorizationEntity() { MembershipID = this.ID, AuthorizationID = authorization, }, connection, transction));
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private bool updateMemberships(DbConnection connection, DbTransaction transaction)
        {
            return KandaRepository.Memberships.Update(this._entity, connection, transaction);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private bool updateUsers(DbConnection connection, DbTransaction transaction)
        {
            if (!KandaRepository.MembershipUsers.Delete(new MembershipUsersCriteria() { MembershipID = this.ID, }, connection, transaction)) { return false; }

            foreach (var user in this.Users)
            {
                if (!KandaRepository.MembershipUsers.Create(new MembershipUserEntity() { MembershipID = this.ID, UserID = user, }, connection, transaction)) { return false; }
            }

            // return this.Users.All(user => KandaRepository.MembershipUsers.Create(new MembershipUserEntity() { MembershipID = this.ID, UserID = user, }, connection, transaction));
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private bool updateRoles(DbConnection connection, DbTransaction transaction)
        {
            if (!KandaRepository.MembershipRoles.Delete(new MembershipRolesCriteria() { MembershipID = this.ID, }, connection, transaction)) { return false; }

            foreach (var role in this.Roles)
            {
                if (!KandaRepository.MembershipRoles.Create(new MembershipRoleEntity() { MembershipID = this.ID, RoleID = role, }, connection, transaction)) { return false; }
            }

            //return this.Roles.All(role => KandaRepository.MembershipRoles.Create(new MembershipRoleEntity() { MembershipID = this.ID, RoleID = role, }, connection, transaction));
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private bool updateAuthorizations(DbConnection connection, DbTransaction transaction)
        {
            if (!KandaRepository.MembershipAuthorizations.Delete(new MembershipAuthorizationsCriteria() { MembershipID = this.ID, }, connection, transaction)) { return false; }

            foreach (var authorization in this.Authorizations)
            {
                if (!KandaRepository.MembershipAuthorizations.Create(new MembershipAuthorizationEntity() { MembershipID = this.ID, AuthorizationID = authorization, }, connection, transaction)) { return false; }
            }

            // return this.Authorizations.All(authorization => KandaRepository.MembershipAuthorizations.Create(new MembershipAuthorizationEntity() { MembershipID = this.ID, AuthorizationID = authorization, }, connection, transaction));
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private bool deleteUsers(DbConnection connection, DbTransaction transaction)
        {
            foreach (var user in this.Users)
            {
                //if (!KandaRepository.Users.Delete(user, connection, transaction)) { return false; }
                if (!KandaRepository.MembershipUsers.Delete(new MembershipUsersCriteria() { MembershipID = this.ID, UserID = user, }, connection, transaction)) { return false; }
            }

            this.Users.Clear();

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private bool deleteRoles(DbConnection connection, DbTransaction transaction)
        {
            foreach (var role in this.Roles)
            {
                //if (!KandaRepository.Roles.Delete(role, connection, transaction)) { return false; }
                if (!KandaRepository.MembershipRoles.Delete(new MembershipRolesCriteria() { MembershipID = this.ID, RoleID = role, }, connection, transaction)) { return false; }
            }

            this.Roles.Clear();

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private bool deleteAuthorizations(DbConnection connection, DbTransaction transaction)
        {
            foreach (var authorization in this.Authorizations)
            {
                //if (!KandaRepository.Authorizations.Delete(authorization, connection, transaction)) { return false; }
                if (!KandaRepository.MembershipAuthorizations.Delete(new MembershipAuthorizationsCriteria() { MembershipID = this.ID, AuthorizationID = authorization, }, connection, transaction)) { return false; }
            }

            this.Authorizations.Clear();

            return true;
        }

        /// <summary></summary>
        private readonly MembershipEntity _entity;

        #endregion
    }
}
