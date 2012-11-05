using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using kkkkkkaaaaaa.Data.Repositories;
using kkkkkkaaaaaa.DataTransferObjects;

namespace kkkkkkaaaaaa.DomainModels
{
    /// <summary>
    /// 
    /// </summary>
    public class User : KandaDomainModel
    {
        /// <summary>
        /// 
        /// </summary>
        public event Action<User, UserEntity> Found;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public User(UserEntity entity)
        {
            this._entity = entity;
            this.MembershipID = new long();
            this.Attributes = new Collection<UserAttributeEntity>();
            this.Histories = new Collection<UserHistoryEntity>();
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
        public long MembershipID { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<UserAttributeEntity> Attributes { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<UserHistoryEntity> Histories { get; private set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public User Find()
        {
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                var found = KandaRepository.Users.Find(this.ID, connection, transaction);
                KandaDataMapper.MapToObject(found, this._entity);

                this.MembershipID = KandaRepository.MembershipUsers.Find(this.ID, connection, transaction);
                this.Attributes = KandaRepository.UserAttributes.Get(this.ID, connection, transaction);
                this.Histories = KandaRepository.UserHistories.Get(this.ID, connection, transaction);

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
        public User Create()
        {
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                this._entity.CreatedOn = KandaRepository.GetUtcDateTime(connection, transaction);
                if (!KandaRepository.Users.Create(this._entity, connection, transaction)) { transaction.Rollback(); }
                else
                {
                    this._entity.ID = KandaRepository.Users.IdentCurrent(connection, transaction);
                    if (!this.createAttributes(connection, transaction)) { transaction.Rollback(); }
                    else if (!this.createHistory(connection, transaction)) { transaction.Rollback(); }
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
        public User Update()
        {
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                this._entity.UpdatedOn = KandaRepository.GetUtcDateTime(connection, transaction);
                if (!KandaRepository.Users.Update(this._entity, connection, transaction)) { transaction.Rollback(); }
                else if (!this.createAttributes(connection, transaction)) { transaction.Rollback(); }
                else if (!this.createHistory(connection, transaction)) { transaction.Rollback(); }
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
        internal User Delete()
        {
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                
                if (!KandaRepository.MembershipUsers.Delete(new MembershipUsersCriteria() { UserID = this.ID, }, connection, transaction)) { transaction.Rollback(); }
                else if (!KandaRepository.UserHistoryAttributes.Delete(this.ID, connection, transaction)) { transaction.Rollback(); }
                else if (!KandaRepository.UserHistories.Delete(this.ID, connection, transaction)) { transaction.Rollback(); }
                else if (!KandaRepository.UserAttributes.Delete(this.ID, connection, transaction)) { transaction.Rollback(); }
                else if (!KandaRepository.Users.Delete(this.ID, connection, transaction)) { transaction.Rollback(); }
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
        private bool createAttributes(DbConnection connection, DbTransaction transaction)
        {
            if (!KandaRepository.UserAttributes.Delete(this.ID, connection, transaction)) { return false; }
            else
            {
                foreach (var attribute in this.Attributes)
                {
                    attribute.UserID = this.ID;
                    if (!KandaRepository.UserAttributes.Create(attribute, connection, transaction)) { return false; }
                }
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private bool createHistory(DbConnection connection, DbTransaction transaction)
        {
            var revision = default(int);
            if (!KandaRepository.UserHistories.Create(this.ID, connection, transaction, out revision)) { return false; }
            if (KandaRepository.UserHistoryAttributes.Create(this.ID, revision, connection, transaction) != this.Attributes.Count) { return false; }
            
            return true;
        }


        /// <summary></summary>
        private readonly UserEntity _entity;

        #endregion
    }
}
