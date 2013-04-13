namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects
{
    /// <summary>
    /// 
    /// </summary>
    public class TextTemplateContext
    {
        /// <summary>
        /// コンストラクタ―。
        /// </summary>
        /// <param name="outputPath"></param>
        /// <param name="tableName"></param>
        /// <param name="tableType"></param>
        /// <param name="ns"></param>
        public TextTemplateContext(string tableName, string tableType)
        {
            this.TableName = tableName;
            this.TableType = tableType;
        }


        /// <summary>
        /// 
        /// </summary>
        public string TableName { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string TableType { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string OutputPath { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string Namespace { get; private set; }

        /*
        public string TypeName { get; set; }
        public string TypeNamePrefix { get; set; }
        public string TypeSuffix { get; set; }
        */


        /// <summary>
        /// 何もしません。
        /// </summary>
        protected void DoNothing()
        {
            // 何もしない
        }
    }
}