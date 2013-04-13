using System;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.VisualStudio.TextTemplating;

namespace kkkkkkaaaaaa.TextTemplates.DataTransferObjects
{
    /// <summary>
    /// 
    /// </summary>
    public partial class TableEntityTemplate : IDisposable
    {
        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="context"></param>
        public TableEntityTemplate(EntityTemplateContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// このインスタンスを初期化します。
        /// </summary>
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

                var schema = reader.GetSchemaTable();
                this.Schema = new DataTableReader(schema);
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
            if (this.Schema != null) { this.Schema.Close(); }
        }

        #region Protected members...

        /// <summary>
        /// 
        /// </summary>
        protected EntityTemplateContext Context
        {
            get { return this._context; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected DataTableReader Schema { get; private set; }

        #endregion

        #region Private members...

        /// <summary>
        /// 
        /// </summary>
        private readonly EntityTemplateContext _context;

        #endregion
    }
}