using System.Data;
using System.Data.Common;
using kkkkkkaaaaaa.DataTransferObjects;
using kkkkkkaaaaaa.Repositories;

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
        public Membership(MembershipEntity entity) : base()
        {
            this._entity = entity;
        }


        /// <summary>
        /// 
        /// </summary>
        public bool Exists
        {
            get { return (0 < this._entity.ID); }
        }

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
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                var result = this;
                if (!KandaRepository.Memberships.Delete(this._entity.ID, connection, transaction)) { transaction.Rollback(); }
                else
                {
                    transaction.Commit();
                    result = new Membership(new MembershipEntity());
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

        /// <summary></summary>
        private readonly MembershipEntity _entity;
    }
}
