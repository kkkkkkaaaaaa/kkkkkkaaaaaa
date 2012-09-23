using System.Data;
using System.Data.Common;

namespace kkkkkkaaaaaa.Data.Common
{
    /// <summary>
    /// プロバイダーのデータソースクラスの実装のインスタンスを作成するためのメソッドのセットを表わします。
    /// </summary>
    public partial class KandaProviderFactory
    {
        /// <summary>
        /// DbParameter クラスを実装しているプロバイダーのクラスの新しいインスタンスを返します。
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public DbParameter CreateParameter(string name, object value, ParameterDirection direction)
        {
            var parameter = this.CreateParameter();

            parameter.ParameterName = name;
            parameter.Value = value;
            parameter.Direction = direction;

            return parameter;
        }

        /// <summary>
        /// DbParameter クラスを実装しているプロバイダーのクラスの新しいインスタンスを返します。
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public DbParameter CreateParameter(string name, object value)
        {
            return this.CreateParameter(name, value, ParameterDirection.Input);
        }
    }
}