using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Threading;
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
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public Membership(MembershipEntity entity)
        {
            this._entity = entity;
            if (this._entity.ID < 1) { return; }

            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                var users = KandaRepository.MembershipUsers.Get(new MembershipUsersCriteria() { MembershipID = this._entity.ID, }, connection, transaction);
                foreach (var user in users) { this.Users.Add(new User(new UserEntity() { ID = user.UserID, })); }

                //var roles 

                //var authorizations

                transaction.Commit();
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
        public override long ID
        {
            get { return this._entity.ID; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Collection<User> Users
        {
            get { return this._users.Value; }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="found"></param>
        /// <returns></returns>
        public Membership Find(out MembershipEntity found)
        {
            found = this._entity;

            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                found = ((0 < this._entity.ID)
                             ? KandaRepository.Memberships.Find(this._entity.ID, connection, transaction)
                             : KandaRepository.Memberships.Find(this._entity.Name, this._entity.Password, connection, transaction));

                transaction.Commit();

                return new Membership(found);
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
                
                this._entity.CreatedOn = KandaRepository.GetUtcDateTime(connection, transaction);
                if (KandaRepository.Memberships.Create(this._entity, connection, transaction))
                {
                    this._entity.ID = KandaRepository.Memberships.IdentCurrent(connection, transaction);

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
                if (!KandaRepository.Memberships.Update(this._entity, connection, transaction))
                {
                    foreach (var user in this.Users)
                    {
                        //KandaRepository.MembershipUsers.Register(new MembershipUserEntity() { this._entity.ID, user.ID, }, connection, transaction);
                    }

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
                
                foreach (var user in this.Users)
                {
                    if (KandaRepository.MembershipUsers.Delete(new MembershipUserEntity() { MembershipID = this.ID, UserID = user.ID, }, connection, transaction))
                    {
                        if (user.Delete().ID < 1) { continue; }
                    } 

                    transaction.Rollback();
                    return result;
                }


                if (!KandaRepository.Memberships.Delete(this.ID, connection, transaction))
                {
                    transaction.Rollback();
                    return result;
                }

                transaction.Rollback();
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
        private readonly MembershipEntity _entity;
        /// <summary></summary>
        private readonly Lazy<Collection<User>> _users = new Lazy<Collection<User>>(LazyThreadSafetyMode.PublicationOnly);

        //private readonly IEnumerable<long> _users;
        //private readonly IEnumerable<long> _roles;
        //private readonly IEnumerable<long> _authorizations;

        #endregion
    }
}
