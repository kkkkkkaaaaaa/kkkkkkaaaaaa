using System;
using System.Data;
using System.Data.Common;
using System.Security;
using System.Security.Permissions;

namespace kkkkkkaaaaaa.Data.Common
{
    /// <summary>
    /// プロバイダーのデータソースクラスの実装のインスタンスを作成するためのメソッドのセットを表わします。
    /// </summary>
    public partial class KandaProviderFactory : DbProviderFactory
    {
        /// <summary>
        /// DbProviderFactory が DbDataSourfceEnumarator クラスをサポートするかどうかを示します。
        /// </summary>
        public override bool CanCreateDataSourceEnumerator
        {
            get
            {
                return this._factory.CanCreateDataSourceEnumerator;
            }
        }


        /// <summary>
        /// DbDataSourceEnumarator クラスを実装しているプロバイダーのクラスの新しいインスタンスを返します。
        /// </summary>
        /// <returns></returns>
        public override DbDataSourceEnumerator CreateDataSourceEnumerator()
        {
            return this._factory.CreateDataSourceEnumerator();
        }

        /// <summary>
        /// DbCommandBuilder クラスを実装しているプロバイダーのクラスの新しいインスタンスを返します。
        /// </summary>
        /// <returns></returns>
        public override DbConnectionStringBuilder CreateConnectionStringBuilder()
        {
            return this._factory.CreateConnectionStringBuilder();
        }

        /// <summary>
        /// DbConnection クラスをを実装しているプロバイダーのクラスの新しいインスタンスを返します。
        /// </summary>
        /// <returns></returns>
        public override DbConnection CreateConnection()
        {
            return this._factory.CreateConnection();
        }

        /// <summary>
        /// DbCommand クラスを実装しているプロバイダーのクラスの新しいインスタンスを返します。
        /// </summary>
        /// <returns></returns>
        public override DbCommand CreateCommand()
        {
            return this._factory.CreateCommand();
        }

        /// <summary>
        /// DbParameter クラスを実装しているプロバイダーのクラスの新しいインスタンスを返します。
        /// </summary>
        /// <returns></returns>
        public override DbParameter CreateParameter()
        {
            return this._factory.CreateParameter();
        }

        /// <summary>
        /// DbCommandBuilder クラスを実装しているプロバイダーのクラスの新しいインスタンスを返します。
        /// </summary>
        /// <returns></returns>
        public override DbCommandBuilder CreateCommandBuilder()
        {
            return this._factory.CreateCommandBuilder();
        }

        /// <summary>
        /// DbDataAdapter クラスを実装しているプロバイダーのクラスの新しいインスタンスを返します。
        /// </summary>
        /// <returns></returns>
        public override DbDataAdapter CreateDataAdapter()
        {
            return this._factory.CreateDataAdapter();
        }

        /// <summary>
        /// プロバイダーのバージョンの CodeAccessPermission クラスを実装しているプロバイダーのクラスの新しいインスタンスを返します。
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public override CodeAccessPermission CreatePermission(PermissionState state)
        {
            return this._factory.CreatePermission(state);
        }

        /// <summary>
        /// DbDataReader クラスを実装しているプロバイダーのクラスの新しいインスタンスを返します。
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public virtual KandaDataReader CreateReader(DbCommand command)
        {
            return new KandaDataReader(command);
        }


        /// <summary>
        /// コンストラクタ―。
        /// </summary>
        /// <param name="factory">DbProviderFactory。</param>
        internal KandaProviderFactory(DbProviderFactory factory)
        {
            if (factory == null) { throw new ArgumentNullException(string.Format(@"{0}.ctor()", this.GetType().FullName)); }

            this._factory = factory;
        }

        #region Protected members...

        /// <summary>
        /// 何もしません。
        /// </summary>
        protected void DoNothing()
        {
            // 何もしない
        }

        #endregion

        #region Private members...

        /// <summary>プロバイダーのデータソースクラスの実装のインスタンスを作成するためのメソッドのセットを表わします。</summary>f
        private readonly DbProviderFactory _factory;

        #endregion
    }
}
