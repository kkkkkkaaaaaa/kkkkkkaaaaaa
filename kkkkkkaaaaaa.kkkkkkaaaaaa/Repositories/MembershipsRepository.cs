﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.Data.TableDataGateways;
using kkkkkkaaaaaa.DataTransferObjects;
using kkkkkkaaaaaa.Security;
using kkkkkkaaaaaa.Security.Cryptography;

namespace kkkkkkaaaaaa.Repositories
{
    /// <summary>
    /// Memberships の Repository です。
    /// </summary>
    public partial class MembershipsRepository : KandaRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public MembershipEntity Find(MembershipsCriteria criteria, DbConnection connection, DbTransaction transaction)
        {
            var password = criteria.Password;
            if (password == null) { this.DoNothing(); }
            else
            {
                if (criteria.Password is SecureString) { password = ((SecureString)criteria.Password).GetString(); }

                var hash = KandaHashAlgorithm.ComputeHash( typeof(SHA512Managed).FullName, (string)password, Encoding.Unicode);
                password = hash;
            }
            criteria.Password = password;

            var reader = default(KandaDbDataReader);

            try
            {
                reader = MembershipsGateway.Select(criteria, connection, transaction);

                var found = (reader.Read() ? KandaDbDataMapper.MapToObject<MembershipEntity>(reader) : MembershipEntity.Empty);

                return found;
            }
            finally
            {
                if (reader != null) { reader.Close(); }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public MembershipEntity Find(long id, DbConnection connection, DbTransaction transaction)
        {
            return this.Find(new MembershipsCriteria() { ID = id, }, connection, transaction);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public MembershipEntity Find(string name, DbConnection connection, DbTransaction transaction)
        {
            return this.Find(new MembershipsCriteria() { Name = name, Password = null, Enabled = null, }, connection, transaction);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public MembershipEntity Find(string name, string password, DbConnection connection, DbTransaction transaction)
        {
            return this.Find(new MembershipsCriteria() { Name = name, Password = password, Enabled = true, }, connection, transaction);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public MembershipEntity Find(string name, object password, DbConnection connection, DbTransaction transaction)
        {
            return this.Find(new MembershipsCriteria() { Name = name, Password = password, Enabled = true, }, connection, transaction);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MembershipEntity> Get(MembershipsCriteria criteria, DbConnection connection, DbTransaction transaction)
        {
            var reader = default(DbDataReader);

            try
            {
                reader = MembershipsGateway.Select(criteria, connection, transaction);

                var memberships = KandaDbDataMapper.MapToEnumerable<MembershipEntity>(reader);

                return memberships;
            }
            finally
            {
                if (reader != null) { reader.Close(); }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool Create(MembershipEntity entity, DbConnection connection, DbTransaction transaction, out MembershipCreateStatus status)
        {
            status = MembershipCreateStatus.ProviderError;

            entity.Password = KandaHashAlgorithm.ComputeHash(typeof(SHA512Managed).FullName, ((SecureString)entity.Password).GetString(), Encoding.Unicode);

            var error = MembershipsGateway.Insert(entity, connection, transaction);

            switch (error)
            {
                case KandaTableDataGateway.NO_ERRORS:
                    status = MembershipCreateStatus.Success;
                    return true;

                case KandaTableDataGateway.DUPLICATE_USER_NAME:
                    status = MembershipCreateStatus.DuplicateUserName;
                    break;

                //case KandaTableDataGateway.DUPLICATE_PROVIDER_USER_KEY:
                //    status = MembershipCreateStatus.DuplicateProviderUserKey;
                //    break;

                default:
                    break;
            }

            return false;

            //return (error == KandaTableDataGateway.NO_ERRORS);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Update(MembershipEntity entity, DbConnection connection, DbTransaction transaction)
        {
            var updated = MembershipsGateway.Update(entity, connection, transaction);

            return (updated == 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public long IdentCurrent(DbConnection connection, DbTransaction transaction)
        {
            var current = MembershipsGateway.IdentCurrent(connection, transaction);

            return decimal.ToInt64(current);
        }

        #region Internal members...


        /// <summary>
        /// コンストラクタ―。
        /// </summary>
        internal MembershipsRepository()
        {
            this.DoNothing();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        internal bool Delete(long id, DbConnection connection, DbTransaction transaction)
        {
            var deleted = MembershipsGateway.Delete(id, connection, transaction);

            return (deleted == KandaTableDataGateway.NO_ERRORS);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        internal bool Delete(DbConnection connection, DbTransaction transaction)
        {
            var deleted = MembershipsGateway.Delete(connection, transaction);

            return (0 <= deleted);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connction"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        internal bool Truncate(DbConnection connction, DbTransaction transaction)
        {
            var error = MembershipsGateway.Truncate(connction, transaction);

            return (error == 0);
        }

        #endregion
    }
}
