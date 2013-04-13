using System;
using System.Data;
using System.Data.Common;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.VisualStudio.TextTemplating;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;

namespace kkkkkkaaaaaa.TextTemplates.Database.Stored_Procedures
{
    public partial class InsertTableTemplate : IDisposable
    {
        public InsertTableTemplate(InsertTableContext context)
        {
            this._context = context;
        }
        public void Initialize()
        {
            var connection = default(DbConnection);
            var reader = default(KandaDbDataReader);
            try
            {
                connection = KandaProviderFactory.Instance.CreateConnection();
                connection.Open();

                reader = KandaProviderFactory.Instance.CreateReader(connection);
                reader.CommandType = CommandType.Text;
                reader.CommandText = string.Format(@"SELECT * FROM [{0}] WHERE 1 <> 1", this.Context.TableName);
                reader.ExecuteReader(CommandBehavior.SchemaOnly);

                this.Schema = reader.GetSchemaTable();
            }
            finally
            {
                if (reader != null) { reader.Close(); }
                if (connection != null) { connection.Close(); }
            }
        }

        /// <summary>
        /// アンマネージ リソースの解放およびリセットに関連付けられているアプリケーション定義のタスクを実行します。
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            //
        }

        protected DataTable Schema { get; private set; }

        protected InsertTableContext Context
        {
            get { return this._context; }
        }

        private readonly InsertTableContext _context;
    }
}