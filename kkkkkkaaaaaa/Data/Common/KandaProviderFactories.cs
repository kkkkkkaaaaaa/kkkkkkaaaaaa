using System.Data;
using System.Data.Common;

namespace kkkkkkaaaaaa.Data.Common
{
    /// <summary>
    /// DbProviderFactory クラスの 1 つ以上のインスタンスを作成するための性的メソッドのセットを表わします。
    /// </summary>
    public static class KandaProviderFactories
    {
        /// <summary>
        /// DbProviderFactory のインスタンスを返します。
        /// </summary>
        /// <param name="providerRow">プロバイダーの構成情報を格納している DataRow。</param>
        /// <returns></returns>
        public static DbProviderFactory GetFactory(DataRow providerRow)
        {
            var factory = DbProviderFactories.GetFactory(providerRow);

            return new KandaProviderFactory(factory);
        }

        /// <summary>
        /// DbProviderFactory のインスタンスを返します。
        /// </summary>
        /// <param name="providerInvariantName">プロバイダーの不変名。</param>
        /// <returns></returns>
        public static DbProviderFactory GetFactory(string providerInvariantName)
        {
            var factory = DbProviderFactories.GetFactory(providerInvariantName);

            return new KandaProviderFactory(factory);
        }

        /// <summary>
        /// DbProviderFactory を実装する全てのインストール済みプロバイダーに関する情報を格納している TDataTable を返します。
        /// </summary>
        /// <returns></returns>
        public static DataTable GetFactoryClasses()
        {
            return DbProviderFactories.GetFactoryClasses();
        }
    }
}
