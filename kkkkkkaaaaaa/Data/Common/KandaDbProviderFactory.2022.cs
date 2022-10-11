using System.Data;
using System.Data.Common;
using System.Diagnostics;

namespace kkkkkkaaaaaa.Data.Common
{
    /// <summary>
    /// プロバイダーのデータソースクラスの実装のインスタンスを作成するためのメソッドのセットを表わします。
    /// </summary>
    public partial class KandaDbProviderFactory : DbProviderFactory
    {
        /// <summary>
        /// DbProviderFactory が DbDataSourfceEnumarator クラスをサポートするかどうかを示します。
        /// </summary>
        public override bool CanCreateDataSourceEnumerator
        {
            [DebuggerStepThrough()]
            get
            {
                return this._factory.CanCreateDataSourceEnumerator;
            }
        }


        /// <summary>
        /// DbDataSourceEnumarator クラスを実装しているプロバイダーのクラスの新しいインスタンスを返します。
        /// </summary>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public override DbDataSourceEnumerator? CreateDataSourceEnumerator()
        {
            return this._factory.CreateDataSourceEnumerator();
        }

        /// <summary>
        /// DbCommandBuilder クラスを実装しているプロバイダーのクラスの新しいインスタンスを返します。
        /// </summary>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public override DbConnectionStringBuilder? CreateConnectionStringBuilder()
        {
            return this._factory.CreateConnectionStringBuilder();
        }

        /// <summary>
        /// DbConnection クラスをを実装しているプロバイダーのクラスの新しいインスタンスを返します。
        /// </summary>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public override DbConnection? CreateConnection()
        {
            return this._factory.CreateConnection();
        }

        /// <summary>
        /// DbCommand クラスを実装しているプロバイダーのクラスの新しいインスタンスを返します。
        /// </summary>
        /// <returns></returns>
        public override DbCommand CreateCommand()
        {
            return this.CreateCommand(CommandType.StoredProcedure);
        }

        /// <summary></summary>
        [DebuggerStepThrough()]
        public DbCommand CreateCommand(CommandType type)
        {
            var command = this._factory.CreateCommand();
            command.CommandType = type;

            return command;
        }

        /// <summary>
        /// DbParameter クラスを実装しているプロバイダーのクラスの新しいインスタンスを返します。
        /// </summary>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public override DbParameter? CreateParameter()
        {
            return this._factory.CreateParameter();
        }

        /// <summary>
        /// DbCommandBuilder クラスを実装しているプロバイダーのクラスの新しいインスタンスを返します。
        /// </summary>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public override DbCommandBuilder? CreateCommandBuilder()
        {
            return this._factory.CreateCommandBuilder();
        }

        /// <summary>
        /// DbDataAdapter クラスを実装しているプロバイダーのクラスの新しいインスタンスを返します。
        /// </summary>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public override DbDataAdapter? CreateDataAdapter()
        {
            return this._factory.CreateDataAdapter();
        }

        /// <summary>
        /// DbDataReader クラスを実装しているプロバイダーのクラスの新しいインスタンスを返します。
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public virtual KandaDbDataReader CreateDataReader(DbConnection connection, DbTransaction? transaction = default(DbTransaction))
        {
            return new KandaDbDataReader(connection, transaction);
        }

        /// <summary></summary>
        [DebuggerStepThrough()]
        public virtual KandaDbDataReader CreateReader(DbCommand command)
        {
            return new KandaDbDataReader(command);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="dbType"></param>
        /// <param name="size"></param>
        /// <param name="direction"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public DbParameter CreateParameter(string name, DbType dbType, int size, ParameterDirection direction, object value)
        {
            var parameter = this.CreateParameter();

            parameter.ParameterName = name;
            parameter.DbType = dbType;
            parameter.Size = size;
            parameter.Direction = direction;
            parameter.Value = value;

            return parameter;
        }

        /// <summary>
        /// DbParameter クラスを実装しているプロバイダーのクラスの新しいインスタンスを返します。
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public DbParameter CreateParameter(string name, object value)
        {
            return this.CreateParameter(name, default(DbType), 0, ParameterDirection.Input, value);
        }

        #region Protected members...

        /// <summary>
        /// コンストラクタ―。
        /// </summary>
        /// <param name="factory">DbProviderFactory。</param>
        protected KandaDbProviderFactory(DbProviderFactory factory)
        {
            if (factory == null) { throw new ArgumentNullException(string.Format(@"{0}.ctor()", this.GetType().FullName)); }

            this._factory = factory;
        }


        /// <summary>
        /// 何もしません。
        /// </summary>
        [DebuggerStepThrough()]
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
