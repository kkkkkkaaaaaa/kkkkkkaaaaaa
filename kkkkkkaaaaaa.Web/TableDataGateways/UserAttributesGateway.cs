using System;
using System.Data;
using System.Data.Common;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.Web.DataTransferObjects;

namespace kkkkkkaaaaaa.Web.TableDataGateways
{
    public class UserAttributesGateway : KandaTableDataGateway
    {
        public static DbDataReader Select(UserAttributeEntity entity, DbConnection connection, DbTransaction transaction)
        {
            var reader = KandaTableDataGateway._factory.CreateReader(connection, transaction);

            reader.CommandText = @"usp_SelectUserAttributes";

            KandaDbDataMapper.MapToParameters(reader, entity);

            reader.ExecuteReader();

            return reader;
        }

        public static int Insert(UserAttributeEntity entity, DbConnection connection, DbTransaction transaction)
        {
            var command = KandaTableDataGateway._factory.CreateCommand(connection, transaction);

            command.CommandText = @"usp_InsertUserAttributes";

            KandaDbDataMapper.MapToParameters(command, entity);

            var result = KandaTableDataGateway._factory.CreateParameter(KandaTableDataGateway.RETURN_VALUE, DbType.Int32, sizeof(int), ParameterDirection.ReturnValue, DBNull.Value);
            command.Parameters.Add(result);
            
            command.ExecuteNonQuery();

            return (int)result.Value;

        }

        public static int Truncate(DbConnection connection, DbTransaction transaction)
        {
            return KandaTableDataGateway.Truncate(@"UserAttributes", connection, transaction);
        }
    }
}