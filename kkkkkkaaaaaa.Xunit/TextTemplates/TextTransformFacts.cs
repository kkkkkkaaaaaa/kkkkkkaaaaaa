using System;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Text;
using Xunit;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.TextTemplates.DataTransferObjects;
using kkkkkkaaaaaa.Xunit.Data;

namespace kkkkkkaaaaaa.Xunit.TextTemplates
{
    public class TextTransformFacts : KandaXunitFacts
    {
        [Fact()]
        public void Fact()
        {
            var connection = default(DbConnection);
            var reader = default (DbDataReader);

            try
            {
                connection = KandaXunitProviderFactory.Instance.CreateConnection();
                connection.Open();

                var tables = connection.GetTablesSchema();
                reader = new DataTableReader(tables);
                while (reader.Read())
                {
                    var text = @"";
                    switch (reader.GetString(reader.GetOrdinal(@"TABLE_TYPE")))
                    {
                        case @"BASE TABLE":
                            /*
                            // Stored Procedures
                            text = new InsertTableTemplate().TransformText();
                            text = new UpdateTableTempalte().TransformText();
                            text = new DeleteTableTemplate().TransformText();
                            text = new SelectTableTemplate().TransformText();
                            */

                            // DataTransferObject
                            var template = new TableEntityTemplate(reader.GetString(reader.GetOrdinal(@"TABLE_NAME")));
                            template.Initialize();
                            text = template.TransformText();

                            /*
                            // TableDataGateway
                            text = new TableTableDataGatewayTemplate().TransformText();

                            // Repository
                            text = new TableRepositoryTemplate().TransformText();

                            // DomainModel
                            text = new TableDomainModelsTemplate.TransformText();

                            // Xunit
                            text = new TableXunitFactsTemplate.TransformText();
                            */
                            break;

                        case @"VIEW":
                            /*
                            text = new ViewEntityTemplate().TransformFormat();
                            text = new CriteriaTemplate().TransformFormat();
                            text = new SelectViewTemplate().TransformText();
                            text = new ViewTableDataGatewayTemplate().TransformText();
                            text = new ViewRepositoryTemplate().TransformText();
                            text = new ViewDomainModelTemplate().TransformText();
                            text = new ViewXunitFactsTemplate().TransformText();
                            */
                            break;

                        default:
                            break;
                    }
                }

            }
            finally
            {
                
            }
        }
    }
}