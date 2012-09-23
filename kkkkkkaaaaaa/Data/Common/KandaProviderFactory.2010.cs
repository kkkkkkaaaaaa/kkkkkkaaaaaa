using System.Data;
using System.Data.Common;

namespace kkkkkkaaaaaa.Data.Common
{
    public partial class KandaProviderFactory
    {
        public DbParameter CreateParameter(string name, object value, ParameterDirection direction = ParameterDirection.Input)
        {
            var parameter = this.CreateParameter();

            parameter.ParameterName = name;
            parameter.Value = value;
            parameter.Direction = direction;

            return parameter;
        }
    }
}