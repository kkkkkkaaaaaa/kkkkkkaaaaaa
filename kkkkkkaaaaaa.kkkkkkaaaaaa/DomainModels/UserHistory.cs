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
    public class UserHistory : KandaDomainModel
    {
        /// <summary>
        /// 。
        /// </summary>
        public event Action<UserHistory, UserHistoryEntity> Found;

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="entity"></param>
        public UserHistory(UserHistoryEntity entity)
        {
            this._entity = entity;
            this.Attributes = new Collection<UserHistoryAttributeEntity>();
        }

        /// <summary>
        /// 
        /// </summary>
        public long UserID
        {
            get { return this._entity.UserID; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Revision
        {
            get { return this._entity.Revision; }
        }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<UserHistoryAttributeEntity> Attributes { get; private set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public UserHistory Create()
        {
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                /*
                var revision = default(int);
                if (!KandaRepository.UserHistories.Create(this.UserID, connection, transaction, out revision)) { transaction.Rollback(); }
                else
                {
                    this._entity.Revision = revision;
                    if (KandaRepository.UserHistoryAttributes.Create(this.UserID, this.Revision, connection, transaction)) { transaction.Rollback(); }
                    else { transaction.Commit(); }
                }
                */

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
        public UserHistory Find()
        {
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                var found = KandaRepository.UserHistories.Find(this.UserID, this.Revision, connection, transaction);
                KandaDataMapper.MapToObject(found, this._entity);

                this.Attributes = KandaRepository.UserHistoryAttributes.Get(new UserHistoryAttributesCriteria() { UserID = this.UserID, Revision = this.Revision }, connection, transaction);

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
        internal UserHistory Delete()
        {
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);



                transaction.Commit();
                
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

        /// <summary></summary>
        private readonly UserHistoryEntity _entity;

        #endregion
    }
}