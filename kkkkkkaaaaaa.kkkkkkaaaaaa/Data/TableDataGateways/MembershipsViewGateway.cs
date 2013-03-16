using System;
using System.Data;
using System.Data.Common;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.DataTransferObjects;

namespace kkkkkkaaaaaa.Data.TableDataGateways
{
    /// <summary>
    /// 
    /// </summary>
    internal class MembershipsViewGateway : KandaTableDataGateway
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public KandaDbDataReader Select(MembershipsCriteria criteria, DbConnection connection, DbTransaction transaction)
        {
            var reader = KandaTableDataGateway._factory.CreateReader(connection, transaction);

            reader.CommandText = @"usp_SelectMembershipsView";

            KandaDbDataMapper.MapToParameters(reader, criteria);

            var result = KandaTableDataGateway._factory.CreateParameter(KandaTableDataGateway.RETURN_VALUE, DbType.Int32, sizeof(int), ParameterDirection.Output, DBNull.Value);
            reader.Parameters.Add(result);

            reader.ExecuteReader();

            return reader;
        }
        
        public KandaDbDataReader Count(MembershipsCriteria criteria, DbConnection connection, DbTransaction transaction)
        {
            throw new NotImplementedException(@"MembershipsViewGateway.Count()");
        }


    }
}