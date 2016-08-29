using System.Configuration;
using System.Data;
using System.Data.Common;
using kkkkkkaaaaaa.Data.Common;
using System;

namespace kkkkkkaaaaaa.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class KandaXunitProviderFactory : KandaDbProviderFactory
    {
        /// <summary>
        /// Singleton インスタンス。
        /// </summary>
        public static KandaXunitProviderFactory Instance
        {
            get { return KandaXunitProviderFactory._instance; }
        }


        /// <summary>
        /// 接続を生成して返します。
        /// </summary>
        /// <returns></returns>
        public override DbConnection CreateConnection()
        {
            var connection = base.CreateConnection();
            connection.ConnectionString = wwi.ConnectionString;

            return connection;
        }

        /// <summary>
        /// コマンドを生成して返します。
        /// </summary>
        /// <returns></returns>
        public override DbCommand CreateCommand()
        {
            var command = base.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;

            return command;
        }

        #region Protected members...

        /// <summary>
        /// コンストラクター。
        /// </summary>
        protected KandaXunitProviderFactory() : base(DbProviderFactories.GetFactory(_wwi.ProviderName))
        {
            this.DoNothing();
        }

        #endregion

        #region Private members...

        /// <summary>Instance のバッキングフィールド。</summary>
        private readonly static KandaXunitProviderFactory _instance = new Lazy<KandaXunitProviderFactory>().Value;
        /// <summary>接続文字列。</summary>
        private static readonly ConnectionStringSettings _wwi = ConfigurationManager.ConnectionStrings["wwi"];

        #endregion


    }
}
