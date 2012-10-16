using System.Data;
using System.Data.Common;
using kkkkkkaaaaaa.Data.Repositories;
using kkkkkkaaaaaa.DataTransferObjects;

namespace kkkkkkaaaaaa.DomainModels
{
    public class Authorization : KandaDomainModel
    {
        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="entity"></param>
        public Authorization(AuthorizationEntity entity)
        {
            this._entity = entity;
        }

        /// <summary>
        /// Authorizations.ID。
        /// </summary>
        public override long ID
        {
            get { return this._entity.ID; }
        }

        public Authorization Create()
        {
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal Authorization Delete()
        {
            var result = this;
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                if (KandaRepository.Authorizations.Create(this._entity, connection, transaction))
                {
                    this._entity.ID = KandaRepository.Authorizations.IdentCurrent(connection, transaction);

                    transaction.Commit();
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

        /// <summary></summary>
        private readonly AuthorizationEntity _entity;
    }
}