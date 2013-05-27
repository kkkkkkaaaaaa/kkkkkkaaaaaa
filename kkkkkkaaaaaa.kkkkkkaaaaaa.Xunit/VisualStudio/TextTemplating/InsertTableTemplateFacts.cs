using System.Data;
using System.Data.Common;
using Xunit;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.VisualStudio.TextTemplating;
using kkkkkkaaaaaa.Xunit.Data;
using InsertTableContext = kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects.InsertTableContext;

namespace kkkkkkaaaaaa.Xunit.VisualStudio.TextTemplating
{
    public class InsertTableTemplateFacts : TextTemplateFact
    {
        [Fact()]
        public void TransformTextFact()
        {
            var connection = default(DbConnection);
            var reader = default(DbDataReader);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                var schema = connection.GetTablesSchema();
                reader = new DataTableReader(schema);

                while (reader.Read())
                {
                    var name = TextTemplateFact.GetTableName(reader);
                    var type = TextTemplateFact.GetTableType(reader);

                    var context = new InsertTableContext(name, type)
                                      {
                                          ProcedureNamePrefix = @"usp_", 
                                          ProcedureNameSuffix = @"", 
                                      };
                    var template = new InsertTableTemplate(context);
                    template.Initialize();
                    var text = template.TransformText();
                    // TODO : 
                }
            }
            finally
            {
                if (reader != null) { reader.Close(); }
                if (connection != null) { connection.Close(); }
            }
        }
    }
}