﻿using System;
using System.Data;
using System.Data.Common;
using System.Runtime.InteropServices;
using Xunit;
using kkkkkkaaaaaa.Xunit.Data;

namespace kkkkkkaaaaaa.Xunit.Database
{
    public class SelectUTCDateTimeFacts : KandaXunitDataFacts
    {
        [Fact()]
        public void SelectUTCDateTimeFact()
        {
            var connection = default (DbConnection);
            var command = default(DbCommand);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                command = this._factory.CreateCommand(connection);
                command.CommandText = @"GetUTCDateTime";
                
                //var result = this._factory.CreateParameter("Result", DbType.DateTime2, Marshal.SizeOf(new DateTime()), ParameterDirection.ReturnValue, DBNull.Value);
                var result = this._factory.CreateParameter("Result", DbType.DateTime2, 8, ParameterDirection.ReturnValue, DBNull.Value);
                command.Parameters.Add(result);

                command.ExecuteNonQuery();

                Assert.True(default(DateTime) < (DateTime)result.Value);
            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }
    }
}