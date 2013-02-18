using System;
using System.Data;
using System.Data.Common;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.DataTransferObjects;

namespace kkkkkkaaaaaa.Data.TableDataGateways
{
    internal class TableGateway : KandaTableDataGateway
    {
        public static bool Insert(TableEntity entity, DbConnection connection, DbTransaction transaction, out int affected)
        {
            var command = KandaTableDataGateway._factory.CreateCommand(connection, transaction);
            command.CommandText = @"usp_InsertTable";

            KandaDbDataMapper.MapToParameters(command, entity);

            var error = KandaTableDataGateway._factory.CreateParameter(KandaTableDataGateway.RETURN_VALUE, DbType.Int32, sizeof(int), ParameterDirection.ReturnValue, DBNull.Value);
            command.Parameters.Add(error);

            affected = command.ExecuteNonQuery();
            entity.ID = Convert.ToInt64(command.Parameters["@identity"].Value);

            return ((int)error.Value == 0);
        }
    }
}