using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using kkkkkkaaaaaa.Repositories;
using kkkkkkaaaaaa.DataTransferObjects;

namespace kkkkkkaaaaaa.DomainModels
{
    public class Authorization : KandaDomainModel
    {
        /// <summary>
        /// 。
        /// </summary>
        public event Action<Authorization, AuthorizationEntity> Found;
        

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="entity"></param>
        public Authorization(AuthorizationEntity entity)
        {
            this._entity = entity;
            this.Memberships = new Collection<long>();
            this.Roles = new Collection<long>();
        }


        /// <summary>
        /// Authorizations.ID。
        /// </summary>
        public long ID
        {
            get { return this._entity.ID; }
        }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<long> Roles { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<long> Memberships { get; private set; }


        public Authorization Find()
        {
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                var found = KandaRepository.Authorizations.Find(this.ID, connection, transaction);

                KandaDataMapper.MapToObject(found, this._entity);

                this.Memberships = KandaRepository.MembershipAuthorizations.Get(new MembershipAuthorizationsCriteria() { AuthorizationID = this.ID, }, connection, transaction);
                this.Roles = KandaRepository.RoleAuthorizations.Get(new RoleAuthorizationsCriteria() { AuthorizationID = this.ID, }, connection, transaction);

                transaction.Commit();

                if (this.Found != null) { this.Found(this, this._entity); }

                return this;

            }
            catch (Exception)
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
        public Authorization Create()
        {
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Authorization Update()
        {
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                this._entity.UpdatedOn = KandaRepository.GetUtcDateTime(connection, transaction);
                if (!KandaRepository.Authorizations.Update(this._entity, connection, transaction)) { transaction.Rollback(); }
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
        internal Authorization Delete()
        {
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                if (!KandaRepository.Authorizations.Delete(this.ID, connection, transaction)) { transaction.Rollback(); }
                else if (!KandaRepository.MembershipAuthorizations.Delete(new MembershipAuthorizationsCriteria() { AuthorizationID = this.ID, }, connection, transaction)) { transaction.Rollback(); }
                else if (!KandaRepository.RoleAuthorizations.Delete(new RoleAuthorizationsCriteria() { AuthorizationID = this.ID, }, connection, transaction)) { transaction.Rollback(); }
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


        /// <summary></summary>
        private readonly AuthorizationEntity _entity;

    }
}