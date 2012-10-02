using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using kkkkkkaaaaaa.Web.TableDataGateways;

namespace kkkkkkaaaaaa.Web.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthorizationsRepository : KandaRepository
    {
        public bool Truncate(DbConnection connection, DbTransaction transaction)
        {
            var error = AuthorizationsGateway.Truncate(connection, transaction);

            return (error == 0);
        }

        /// <summary>
        /// コンストラクタ―。
        /// </summary>
        internal AuthorizationsRepository()
        {
            this.DoNothing();
        }
    }
}