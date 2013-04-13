using System;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Text;
using Xunit;
using kkkkkkaaaaaa.Data;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.TextTemplates.DataTransferObjects;
using kkkkkkaaaaaa.TextTemplates.Database.Stored_Procedures;
using kkkkkkaaaaaa.VisualStudio.TextTemplating;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DataTransferObjects;
using kkkkkkaaaaaa.Xunit.Data;

namespace kkkkkkaaaaaa.Xunit.TextTemplates
{
    public class TextTransformFacts : KandaXunitFacts
    {
        [Fact(Skip = @"")]
        public void EntityTempalteFact()
        {
            try
            {

            }
            finally
            {
                
            }
        }

        [Fact()]
        public void TransformSelectTextFact()
        {

        }

        [Fact()]
        public void Fact()
        {
            var connection = default (DbConnection);
            var reader = default(DbDataReader);

            try
            {
                connection = KandaXunitProviderFactory.Instance.CreateConnection();
                connection.Open();

                var schema = connection.GetTablesSchema();
                reader = new DataTableReader(schema);

                while (reader.Read())
                {
                    var name = reader.GetString(reader.GetOrdinal(@"TABLE_NAME"));
                    var type = reader.GetString(reader.GetOrdinal(@"TABLE_TYPE"));

                    //this.transformEntity(name, type);
                    this.transformInsertTable(name, type);
                }
            }
            finally
            {
                if (reader != null) { reader.Close(); }
                if (connection != null) { connection.Close(); }
            }
        }

        private void transformInsertTable(string tableName, string tableType)
        {
            var context = new InsertTableContext(tableName, tableType)
                              {
                                  ProcedureNamePrefix = @"usp_", 
                                  ProcedureNameSuffix = @"",
                              };
            /*
            using (var template = new InsertTableTemplate(context))
            {
                template.Initialize();
                var text = template.TransformText();
            }
            */
        }

        private void transformEntity(string tableName, string tableType)
        {
            var context = new EntityTemplateContext(tableName, tableType)
                              {
                                  TypeNamePrefix = @"", 
                                  TypeNameSuffix = @"Entity", 
                              };
            using (var template = new TableEntityTemplate(context))
            {
                template.Initialize();
                var text = template.TransformText();
                // output
            }

            switch (tableType)
            {
                case @"BASE TABLE":
                    break;

                case @"VIEW":
                    break;

                default:
                    throw new Exception(string.Format(@"transformEntity(""{0}"", ""{1}"")", tableName, tableType));
                    break;
            }

            /*
            try
            {
                reader = new DataTableReader(schema);
                while (reader.Read())
                {
                    var name = reader.GetString(reader.GetOrdinal(@"TABLE_NAME"));
                    var text = @"";
                    switch (reader.GetString(reader.GetOrdinal(@"TABLE_TYPE")))
                    {
                        case @"BASE TABLE":
                            // DataTransferObject
                            var template = new TableEntityTemplate(name);
                            template.Initialize();
                            text = template.TransformText();

                            /*
                            // Stored Procedures
                            text = new InsertTableTemplate().TransformText();
                            text = new UpdateTableTempalte().TransformText();
                            text = new DeleteTableTemplate().TransformText();
                            text = new SelectTableTemplate().TransformText();
                            */


                            /*
                            // TableDataGateway
                            text = new TableTableDataGatewayTemplate().TransformText();

                            // Repository
                            text = new TableRepositoryTemplate().TransformText();

                            // DomainModel
                            text = new TableDomainModelsTemplate.TransformText();

                            // Xunit
                            text = new TableXunitFactsTemplate.TransformText();
                            *//*
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
                            *//*
                            break;

                        default:
                            break;
                    }
                }
            }
            finally
            {
            }
            */
            }
    }
}