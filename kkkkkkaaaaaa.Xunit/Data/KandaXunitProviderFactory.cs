using System;
using System.Data;
using System.Data.Common;
using System.Threading;
using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa.Xunit.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class KandaXunitProviderFactory : KandaDbProviderFactory
    {
        /// <summary>
        /// Singleton �C���X�^���X�B
        /// </summary>
        public static KandaXunitProviderFactory Instance
        {
            get { return KandaXunitProviderFactory._instance; }
        }

        /// <summary>
        /// DbConnection �N���X�����������Ă���v���o�C�_�[�̃N���X�̐V�����C���X�^���X��Ԃ��܂��B
        /// </summary>
        /// <returns></returns>
        public override DbConnection CreateConnection()
        {
            var builder = base.CreateConnectionStringBuilder();
            //builder.ConnectionString = @"Data Source=(localdb)\kkkkkkaaaaaa_2010;Initial Catalog=kkkkkkaaaaaa.Database.2012;Integrated Security=True;Pooling=False;Connect Timeout=30";
            builder.Add(@"Data Source", @"(localdb)\kkkkkkaaaaaa_2010");
            builder.Add(@"Initial Catalog", @"kkkkkkaaaaaa.Database.2012");
            builder.Add(@"Integrated Security", @"True");
            builder.Add(@"Pooling", @"False");
            builder.Add(@"Connect Timeout", @"30");

            var connection = base.CreateConnection();
            connection.ConnectionString = builder.ConnectionString;

            return connection;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public override DbCommand  CreateCommand(DbConnection connection, DbTransaction transaction = null)
        {
            var command = base.CreateCommand(connection, transaction);

            command.CommandType = CommandType.StoredProcedure;

            return command;
        }

        /// <summary>
        /// DbConnectionReader �N���X���������Ă���N���X�̐V�����C���X�^���X��Ԃ��܂��B
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public KandaDbDataReader CreateReader(DbConnection connection)
        {
            var reader = base.CreateReader(connection);

            reader.CommandType = CommandType.StoredProcedure;

            return reader;
        }

        #region Private members...

        /// <summary>
        /// �R���X�g���N�^�B
        /// </summary>
        /// <param name="factory"></param>
        private KandaXunitProviderFactory()
            : base(DbProviderFactories.GetFactory(@"System.Data.SqlClient"))
        {
            this.DoNothing();
        }

        /// <summary></summary>
        private readonly static KandaXunitProviderFactory _instance = new KandaXunitProviderFactory();

        #endregion

    }
}