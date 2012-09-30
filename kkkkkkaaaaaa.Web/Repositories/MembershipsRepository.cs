using System;
using System.Data.Common;
using System.Web.Security;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.Web.DataTransferObjects;
using kkkkkkaaaaaa.Web.TableDataGateways;

namespace kkkkkkaaaaaa.Web.Repositories
{
    /// <summary>
    /// 
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

                var membership = default(MembershipEntity);
                KandaDbDataMapper.MapToObject(reader, membership);
                
                var user = new KandaMembershipUser(membership);

                /*
                var user = new MembershipUser (
                    Membership.Provider.GetType().FullName
                    , reader.GetString(@"Name")
                    , reader.GetInt64(@"ID")
                    , default(string)
                    , default(string)
                    , reader.GetString(@"Description")
                    , default(bool)
                    , default(bool)
                    , reader.GetDateTime(@"CreatedOn")
                    , default(DateTime)
                    , default(DateTime)
                    , default(DateTime)
                    , default(DateTime));
                */

                return user;
            }
            finally
            {
                if (reader != null) { reader.Close(); }
            }
        }

        public MembershipUserCollection Search(/* SearchMembershipsCriteria criteria */)
        {
            return new MembershipUserCollection();
        }

        public bool Create(MembershipEntity entity, DbConnection connection, DbTransaction transaction)
        {
            if (entity.ID <= 0) { entity.ID = MembershipsGateway.SelectNextID(connection, transaction); }

            var affected = MembershipsGateway.Insert(entity, connection, transaction);

            return (affected == 1);
        }

        public bool Update(MembershipEntity entity, DbConnection connection, DbTransaction transaction)
        {
            entity.UpdatedOn = MembershipsGateway.GetUtcDateTime(connection, transaction);

            var affected = MembershipsGateway.Update(entity, connection, transaction);

            return (affected == 1);
        }

        public bool Truncate(DbConnection connction, DbTransaction transaction)
        {
            var count = MembershipsGateway.Truncate(connction, transaction);

            return (0 == count);
        }
    }
}
