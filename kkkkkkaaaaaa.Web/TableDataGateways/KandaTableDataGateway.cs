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

            command.Parameters.Add(KandaTableDataGateway._factory.CreateParameter(@"Result", DBNull.Value, ParameterDirection.ReturnValue));

            command.CommandText = @"SelectUTCDateTime";

            var scalar = command.ExecuteScalar();

            /*
            var result = this._factory.CreateParameter("Result", default(DateTime), ParameterDirection.ReturnValue);
            command.Parameters.Add(result);

            command.ExecuteNonQuery();

            Assert.True(default(DateTime) < (DateTime)result.Value);
            */

            return (DateTime) scalar;
        }

        #region Protected members...

        /// <summary>
        /// 
        /// </summary>
        protected static KandaDbProviderFactory _factory = KandaProviderFactory.Instance;

        #endregion
    }
}