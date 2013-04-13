namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects
{
    public class InsertTableContext : TextTemplateContext
    {
        public InsertTableContext(string tableName, string tableType) : base(tableName, tableType)
        {

        }

        public string ProcedureName
        {
            get
            {
                var name = string.Format(@"{0}{1}{2}", this.ProcedureNamePrefix, this.TableName, ProcedureNameSuffix);

                return name;
            }
        }

        public string ProcedureNamePrefix { get; set; }

        public string ProcedureNameSuffix { get; set; }
    }
}