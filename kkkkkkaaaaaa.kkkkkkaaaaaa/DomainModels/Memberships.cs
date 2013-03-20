using System.Data;
using System.Data.Common;
using System.Linq;
using System.Security;
using kkkkkkaaaaaa.Data;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.Data.Repositories;
using kkkkkkaaaaaa.DataTransferObjects;

namespace kkkkkkaaaaaa.DomainModels
{
    /// <summary>
    /// 
    /// </summary>
    public class Memberships //: KandaDomainModel
    {
        public const long ANONYMOUS = 5L;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool Validate(string name, string password)
        {
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = KandaProviderFactory.Instance.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.ReadUncommitted);

                var criteria = new MembershipsCriteria()
                    {
                        Name = name,
                        Password = password,
                        Enabled = true,

                        //ID = ,
                        //CreatedOn = ,
                        //UpdatedOn = ,
                    };

                var count = KandaRepository.Memberships.Get(criteria, connection, transaction).Count();

                return (count == 1);
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
    }
}