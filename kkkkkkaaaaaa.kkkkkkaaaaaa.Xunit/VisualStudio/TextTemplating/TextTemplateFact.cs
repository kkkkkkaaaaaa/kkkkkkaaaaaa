using System.Data.Common;
using kkkkkkaaaaaa.Xunit.Data;

namespace kkkkkkaaaaaa.Xunit.VisualStudio.TextTemplating
{
    /// <summary>
    /// kkkkkkaaaaaa.Xunit.VisualStudio.TextTemplating 基底クラス。
    /// </summary>
    public class TextTemplateFact
    {
        #region Protected members...

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected static string GetTableName(DbDataReader reader)
        {
            const string TABLE_NAME = @"TABLE_NAME";

            var ordinal = reader.GetOrdinal(TABLE_NAME);
            var name = reader.GetString(ordinal);

            return name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected static string GetTableType(DbDataReader reader)
        {
            const string TABLE_TYPE = @"TABLE_TYPE";

            var ordinal = reader.GetOrdinal(TABLE_TYPE);
            var type = reader.GetString(ordinal);

            return type;
        }

        /// <summary>
        /// 
        /// </summary>
        protected readonly KandaXunitProviderFactory _factory = KandaXunitProviderFactory.Instance;

        #endregion
    }
}