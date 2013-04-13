using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating
{
    public class EntityTemplateContext : TextTemplateContext
    {
        /// <summary>
        /// コンストラクタ―。
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="tableType"></param>
        public EntityTemplateContext(string tableName, string tableType)
            : base(tableName, tableType)
        {
            this.DoNothing();
        }

        /// <summary>
        /// 
        /// </summary>
        public string TypeName
        {
            get
            {
                var value = string.Format(@"{0}{1}{2}", this.TypeNamePrefix, this.TableName, this.TypeNameSuffix);

                return value;
            }
            set { this._typeName = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string TypeNamePrefix { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TypeNameSuffix { get; set; }

        #region Private members...

        /// <summary></summary>
        private string _typeName = @"";

        #endregion
    }
}