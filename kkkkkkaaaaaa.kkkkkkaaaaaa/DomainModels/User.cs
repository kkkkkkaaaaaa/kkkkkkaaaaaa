using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Threading;
using kkkkkkaaaaaa.Data.Repositories;
using kkkkkkaaaaaa.DataTransferObjects;

namespace kkkkkkaaaaaa.DomainModels
{
    public class User : KandaDomainModel
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public User(UserEntity entity)
        {
            this._entity = entity;
        }

        /// <summary>
        /// 
        /// </summary>
        public override long ID
        {
            get { return this._entity.ID; }
        }

        /*
        /// <summary>
        /// 
        /// </summary>
        public Collection<UsrAttributes> Attributes
        {
            get { return this._attributes; }
        }
        */

        /// <summary>
        /// 
        /// </summary>
        public bool Exists
        {
            get { return (0 < this._entity.ID); }
        }

        public User Find(out UserEntity found)
        {
            found = this._entity;

            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                found = KandaRepository.Users.Find(this._entity.ID, connection, transaction);

                transaction.Commit();

                return new User(found);
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
                if (KandaRepository.Users.Create(this._entity, connection, transaction))
                {
                    this._entity.ID = KandaRepository.Users.IdentCurrent(connection, transaction);
                    transaction.Commit();
                }
                else { transaction.Rollback(); }

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
        public User Delete()
        {
            var result = this;
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                if (KandaRepository.Users.Delete(this._entity.ID, connection, transaction))
                {
                    transaction.Commit();
                    result = new User(new UserEntity());
                }
                else { transaction.Rollback(); }

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

        /// <summary></summary>
        private readonly UserEntity _entity;

        //private readonly Lazy<Collection<UserAttribute>> _attributes = new Lazy<Collection<UserAttribute>>(LazyThreadSafetyMode.ExecutionAndPublication);

        #endregion
    }
}
