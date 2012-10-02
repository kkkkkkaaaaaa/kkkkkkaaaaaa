using System.Collections.Generic;
using System.Data.Common;
using System.Web.Security;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.Web.DataTransferObjects;
using kkkkkkaaaaaa.Web.TableDataGateways;

namespace kkkkkkaaaaaa.Web.Repositories
{
    /// <summary>
    /// Memberships の Repository です。
    /// </summary>
    public class MembershipsRepository : KandaRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public MembershipUser Find(string name, string password, DbConnection connection, DbTransaction transaction)
        {
            var reader = default(KandaDbDataReader);

            try
            {
                reader = MembershipsGateway.Select(name, password, connection, transaction);

                var membership = (reader.Read() ? KandaDbDataMapper.MapToObject<MembershipEntity>(reader) : default(MembershipEntity));
                
                return new KandaMembershipUser(membership);
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
            var reader = default(KandaDbDataReader);

            try
            {
                reader = MembershipsGateway.Select(id, connection, transaction);
                if (!reader.Read()) { return null; }
                
                return KandaDbDataMapper.MapToObject<MembershipEntity>(reader);
            }
            finally
            {
                if (reader != null) { reader.Close(); }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MembershipUser> Search(/* SearchMembershipsCriteria criteria */)
        {
            return default(IEnumerable<MembershipUser>);
            //return new MembershipUserCollection();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Create(MembershipEntity entity, DbConnection connection, DbTransaction transaction)
        {
            if (entity.ID <= 0) { entity.ID = MembershipsGateway.SelectNextID(connection, transaction); }

            var affected = MembershipsGateway.Insert(entity, connection, transaction);

            return (affected == 1);
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
            var affected = MembershipsGateway.Update(entity, connection, transaction);

            return (affected == 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connction"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Truncate(DbConnection connction, DbTransaction transaction)
        {
            var error = MembershipsGateway.Truncate(connction, transaction);

            return (error == 0);
        }


        /// <summary>
        /// コンストラクタ―。
        /// </summary>
        internal MembershipsRepository()
        {
            this.DoNothing();
        }
    }
}
