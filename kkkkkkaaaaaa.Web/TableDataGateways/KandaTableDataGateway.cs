using System;
using System.Data;
using System.Data.Common;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.Web.Data;

namespace kkkkkkaaaaaa.Web.TableDataGateways
{
    public class KandaTableDataGateway
    {
        public static DateTime GetUtcDateTime(DbConnection connction, DbTransaction transaction = null)
        {
            var command = KandaTableDataGateway._factory.CreateCommand(connction, transaction);

            var result = KandaTableDataGateway._factory.CreateParameter("Result", DBNull.Value, ParameterDirection.ReturnValue);
            command.Parameters.Add(result);

            command.CommandText = @"GetUTCDateTime";

            command.ExecuteNonQuery();

            return (DateTime)result.Value;
        }

        #region Protected members...

        /// <summary>
        /// 
        /// </summary>
        protected static KandaDbProviderFactory _factory = KandaProviderFactory.Instance;

        #endregion
    }
}