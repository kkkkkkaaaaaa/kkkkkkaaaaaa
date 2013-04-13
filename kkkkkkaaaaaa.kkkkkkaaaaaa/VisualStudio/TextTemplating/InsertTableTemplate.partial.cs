using System;
using System.Data;
using System.Data.Common;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating
{
    /// <summary>
    /// 
    /// </summary>
    public partial class InsertTableTemplate
    {
        /// <summary>
        /// コンストラクタ―。
        /// </summary>
        /// <param name="context"></param>
        public InsertTableTemplate(InsertTableContext context)
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

                this.Schema = reader.GetSchemaTable();
            }
            finally
            {
                if (reader != null) { reader.Close(); }
                if (connection != null) { connection.Close(); }
            }
        }

        // public string GetParameters { }

        // public string GetIntoClause { }

        // public string GetValuesClause { }

        // public string GetParamsStatement {  }


        #region Protected members...

        /// <summary>
        /// 
        /// </summary>
        protected InsertTableContext Context
        {
            get { return this._context; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected DataTable Schema { get; private set; }

        #endregion

        #region Private members...

        /// <summary></summary>
        private readonly InsertTableContext _context;

        #endregion
    }
}