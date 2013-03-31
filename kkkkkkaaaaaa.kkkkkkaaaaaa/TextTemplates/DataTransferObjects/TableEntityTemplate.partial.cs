using System.Data.Common;

namespace kkkkkkaaaaaa.TextTemplates.DataTransferObjects
{
    public partial class TableEntityTemplate
    {
        public TableEntityTemplate(string tableName)
        {
            this._tableName = tableName;
        }

        public void Initialize()
        {

        }

        private readonly string _tableName;
    }
}