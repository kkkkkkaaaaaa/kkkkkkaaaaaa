using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using kkkkkkaaaaaa.DataTransferObjects;
using kkkkkkaaaaaa.Repositories;

namespace kkkkkkaaaaaa.DomainModels
{
    public class Membership : KandaDomainModel
    {
        public Membership()
        {
            this._users = new Collection<UserEntity>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public Membership(MembershipEntity entity) : base()
        {
            this._entity = entity;
        }

        public IEnumerable<UserEntity> Users
        {
            get { return this._users; }
            set { this._users = value; }
        }

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
                if (!KandaRepository.Memberships.Create(this._entity, connection, transaction)) { return null; }

                var id = KandaRepository.Memberships.GetIdentCurrent(connection, transaction);
                var result = KandaRepository.Memberships.Find(id, connection, transaction);

                transaction.Commit();

                return new Membership(result);
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

        private readonly MembershipEntity _entity;
        private IEnumerable<UserEntity> _users;
    }
}
