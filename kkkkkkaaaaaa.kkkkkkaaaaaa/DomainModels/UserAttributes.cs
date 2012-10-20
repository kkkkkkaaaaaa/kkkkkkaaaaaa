using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using kkkkkkaaaaaa.Data.Repositories;
using kkkkkkaaaaaa.DataTransferObjects;

namespace kkkkkkaaaaaa.DomainModels
{
    /// <summary>
    /// 
    /// </summary>
    public class UserAttributes : KandaDomainModel
    {
        /// <summary>
        /// 。
        /// </summary>
        public event Action<UserAttributes, IEnumerable<UserAttributeEntity>> Found;


        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="userId"></param>
        public UserAttributes(long userId)
        {
            this._userId = userId;
            this.Attributes = new Collection<UserAttributeEntity>();
        }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<UserAttributeEntity> Attributes{ get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public UserAttributes Find()
        {
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                this.Attributes = KandaRepository.UserAttributes.Get(this._userId, connection, transaction);

                transaction.Commit();

                if (this.Found != null) { this.Found(this, this.Attributes); }

                return this;
            }
            catch
            {
                if (transaction !=null) { transaction.Rollback(); }
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }

            return this;
        }

        public UserAttributes Create()
        {
            return this;
        }


        #region Private membes...

        private long _userId;

        #endregion
    }
}