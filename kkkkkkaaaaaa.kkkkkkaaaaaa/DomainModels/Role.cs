using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using kkkkkkaaaaaa.Repositories;
using kkkkkkaaaaaa.DataTransferObjects;

namespace kkkkkkaaaaaa.DomainModels
{
    /// <summary>
    /// 
    /// </summary>
    public class Role : KandaDomainModel
    {
        /// <summary>
        /// 
        /// </summary>
        public event Action<Role, RoleEntity> Found;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public Role(RoleEntity entity)
        {
            this._entity = entity;
            this.Memberships = new Collection<long>();
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
        public ICollection<long> Memberships { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<long> Authorizations { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Role Find()
        {
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                var found = KandaRepository.Roles.Find(this.ID, connection, transaction);

                KandaDataMapper.MapToObject(found, this._entity);

                this.Memberships = KandaRepository.MembershipRoles.Get(new MembershipRolesCriteria() { RoleID = this.ID, }, connection, transaction);
                this.Authorizations = KandaRepository.RoleAuthorizations.Get(new RoleAuthorizationsCriteria() { RoleID = this.ID, }, connection, transaction);

                transaction.Commit();

                if (this.Found != null) { this.Found(this, this._entity); }

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
        public Role Create()
        {
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                this._entity.CreatedOn = KandaRepository.GetUtcDateTime(connection, transaction);
                if (!KandaRepository.Roles.Create(this._entity, connection, transaction)) { transaction.Rollback(); }
                else
                {
                    this._entity.ID = KandaRepository.Roles.IdentCurrent(connection, transaction);
                    if (this._entity.ID < 1) { transaction.Rollback(); }
                    else if (!this.createMemberships(connection, transaction)) { transaction.Rollback(); }
                    else if (!this.createAuthorizations(connection, transaction)) { transaction.Rollback(); }
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
        public Role Update()
        {
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                this._entity.UpdatedOn = KandaRepository.GetUtcDateTime(connection, transaction);
                if (!KandaRepository.Roles.Update(this._entity, connection, transaction)) { transaction.Rollback(); }
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
        internal Role Delete()
        {
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                if (!KandaRepository.Roles.Delete(this.ID, connection, transaction)) { transaction.Rollback(); }
                else if (!KandaRepository.MembershipRoles.Delete(new MembershipRolesCriteria() { RoleID = this.ID, }, connection, transaction)) { transaction.Rollback(); }
                else if (!KandaRepository.RoleAuthorizations.Delete(new RoleAuthorizationsCriteria() { RoleID = this.ID, }, connection, transaction)) { transaction.Rollback(); }
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

        #region Private members...

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private bool createMemberships(DbConnection connection, DbTransaction transaction)
        {
            foreach (var membership in this.Memberships)
            {
                if (KandaRepository.MembershipRoles.Create(new MembershipRoleEntity() { RoleID = this.ID, MembershipID = membership, }, connection, transaction)) { continue; }

                return false;
            }

            // return this.Memberships.All(membership => KandaRepository.MembershipRoles.Create(new MembershipRoleEntity() { RoleID = this.ID, MembershipID = membership, }, connection, transaction));
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private bool createAuthorizations(DbConnection connection, DbTransaction transaction)
        {
            foreach (var authorization in this.Authorizations)
            {
                if (KandaRepository.RoleAuthorizations.Create(new RoleAuthorizationEntity() { RoleID = this.ID, AuthorizationID = authorization }, connection, transaction)) { continue; }

                return false;
            }

            // return this.Authorizations.All(authorization => KandaRepository.RoleAuthorizations.Create(new RoleAuthorizationEntity() { RoleID = this.ID, AuthorizationID = authorization }, connection, transaction));
            return true;
        }

        /// <summary></summary>
        private readonly RoleEntity _entity;

        #endregion
    }
}