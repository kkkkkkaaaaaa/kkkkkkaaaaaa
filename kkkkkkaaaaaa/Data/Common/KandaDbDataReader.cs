using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Diagnostics;

namespace kkkkkkaaaaaa.Data.Common
{
    /// <summary>
    /// データソースから行の前方向ストリームを読み取ります。
    /// </summary>
    public partial class KandaDbDataReader : DbDataReader
    {
        /// <summary>
        /// コンストラクタ―。
        /// </summary>
        /// <param name="command"></param>
        [DebuggerStepThrough()]
        public KandaDbDataReader(DbCommand command)
        {
            this._command = command;
        }

        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        [DebuggerStepThrough()]
        public KandaDbDataReader(DbConnection connection, DbTransaction transaction)
        {
            this._command = connection.CreateCommand();
            this._command.Transaction = transaction;
        }


        /// <summary>
        /// DbParameter オブジェクトのコレクションを返します。
        /// </summary>
        public DbParameterCollection Parameters
        {
            [DebuggerStepThrough()]
            get { return this.InnerCommand.Parameters; }
        }

        /// <summary>
        /// データソースに対して実行するテキストコマンドを取得または設定します。
        /// </summary>
        public string CommandText
        {
            [DebuggerStepThrough()]
            get { return this.InnerCommand.CommandText; }
            [DebuggerStepThrough()]
            set { this.InnerCommand.CommandText = value; }
        }

        /// <summary>
        /// DbCommand.CommandText の解釈方法を指示または指定します。
        /// </summary>
        public CommandType CommandType
        {
            [DebuggerStepThrough()]
            get { return this.InnerCommand.CommandType; }
            [DebuggerStepThrough()]
            set { this.InnerCommand.CommandType = value; }
        }


        /// <summary>
        /// 指定した列の値を Object のインスタンスとして取得します。
        /// </summary>
        /// <param name="ordinal"></param>
        /// <returns></returns>
        public override object this[int ordinal]
        {
            [DebuggerStepThrough()]
            get { return this._reader[ordinal]; }
        }

        /// <summary>
        /// 指定した列の値を Object のインスタンスとして取得します。
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public override object this[string name]
        {
            [DebuggerStepThrough()]
            get { return this._reader[name]; }
        }

        /// <summary>
        /// DbDataReader に 1 行以上の行が格納されているか銅貨を示す値を取得します。
        /// </summary>
        public override bool HasRows
        {
            [DebuggerStepThrough()]
            get { return this._reader.HasRows; }
        }

        /// <summary>
        /// SQL ステートメントの実行によって変更、挿入、または削除された行の数を取得します。
        /// </summary>
        public override int RecordsAffected
        {
            [DebuggerStepThrough()]
            get { return this._reader.RecordsAffected; }
        }

        /// <summary>
        /// 現在の行の列数を取得します。
        /// </summary>
        public override int FieldCount
        {
            [DebuggerStepThrough()]
            get { return this._reader.FieldCount; }
        }

        public override int Depth
        {
            [DebuggerStepThrough()]
            get { return this._reader.Depth; ; }
        }

        public override bool IsClosed
        {
            [DebuggerStepThrough()]
            get { return this._reader.IsClosed; }
        }



        /// <summary>
        /// DbCommand.Connection に対して DbCommand.CommandText を実行し、CommandBehavior の値の 1 つを使用して DbDataReader を実行します。
        /// </summary>
        /// <param name="behavior"></param>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public DbDataReader ExecuteReader(CommandBehavior behavior)
        {
            this._reader = this.InnerCommand.ExecuteReader(behavior);

            return this;
        }

        /// <summary>
        /// DbCommand.Connection に対して DbCommand.CommandText を実行し、CommandBehavior の値の 1 つを使用して DbDataReader を実行します。
        /// </summary>
        [DebuggerStepThrough()]
        public DbDataReader ExecuteReader()
        {
            return this.ExecuteReader(CommandBehavior.Default);
        }


        /// <summary>
        /// データリーダーの行の反復に使用できる IEnumarator を返します。
        /// </summary>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public override IEnumerator GetEnumerator()
        {
            return this._reader.GetEnumerator();
        }

        /// <summary>
        /// DbDataReader の列メタデータを記述する DataTable を返します。
        /// </summary>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public override DataTable GetSchemaTable()
        {
            return this._reader.GetSchemaTable();
        }

        /// <summary>
        /// リーダーを結果セットの次のレコードに進めます。
        /// </summary>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public override bool Read()
        {
            return this._reader.Read();
        }

        /// <summary>
        /// バッチステートメントの結果を読み取るときに、リーダーを次の結果に進めます。
        /// </summary>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public override bool NextResult()
        {
            return this._reader.NextResult();
        }

        /// <summary>
        /// DbDataReader オブジェクトを閉じます。
        /// </summary>
        [DebuggerStepThrough()]
        public override void Close()
        {
            if (this._reader != null) { this._reader.Close(); }
        }

        /// <summary>
        /// 列の名前を指定して、列の序数を取得します。
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public override int GetOrdinal(string name)
        {
            return this._reader.GetOrdinal(name);
        }

        /// <summary>
        /// 0 から始まる列の序数を指定して、列の名前を取得します。
        /// </summary>
        /// <param name="ordinal"></param>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public override string GetName(int ordinal)
        {
            return this._reader.GetName(ordinal);
        }

        /// <summary>
        /// 列に格納されている値が存在しない値または欠損値かどうかを表す値を取得します。
        /// </summary>
        /// <param name="ordinal"></param>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public override bool IsDBNull(int ordinal)
        {
            return this._reader.IsDBNull(ordinal);
        }

        /// <summary>
        /// 指定した列のデータ型を取得します。
        /// </summary>
        /// <param name="ordinal"></param>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public override Type GetFieldType(int ordinal)
        {
            return this._reader.GetFieldType(ordinal);
        }

        /// <summary>
        /// 指定した列のデータ型の名前を取得します。
        /// </summary>
        /// <param name="ordinal"></param>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public override string GetDataTypeName(int ordinal)
        {
            return this._reader.GetDataTypeName(ordinal);
        }

        /// <summary>
        /// 指定した列の値を String のインスタンスとして取得します。
        /// </summary>
        /// <param name="ordinal"></param>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public override string GetString(int ordinal)
        {
            return this._reader.GetString(ordinal);
        }

        /// <summary>
        /// 指定した列の値を Int32 のインスタンスとして取得します。
        /// </summary>
        /// <param name="ordinal"></param>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public override int GetInt32(int ordinal)
        {
            return this._reader.GetInt32(ordinal);
        }

        /// <summary>
        /// 指定した列の値を 64 ビット符号付き整数として取得します。
        /// </summary>
        /// <param name="ordinal"></param>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public override long GetInt64(int ordinal)
        {
            return this._reader.GetInt64(ordinal);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ordinal"></param>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public override decimal GetDecimal(int ordinal)
        {
            return this._reader.GetDecimal(ordinal);
        }

        /// <summary>
        /// 指定した列の値をブール値として取得します。
        /// </summary>
        /// <param name="ordinal"></param>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public override bool GetBoolean(int ordinal)
        {
            return this._reader.GetBoolean(ordinal);
        }

        /// <summary>
        /// 指定した列の値を DateTime オブジェクトとして取得します。
        /// </summary>
        /// <param name="ordinal"></param>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public override DateTime GetDateTime(int ordinal)
        {
            return this._reader.GetDateTime(ordinal);
        }

        [DebuggerStepThrough()]
        public override byte GetByte(int ordinal)
        {
            return this._reader.GetByte(ordinal);
        }

        [DebuggerStepThrough()]
        public override long GetBytes(int ordinal, long dataOffset, byte[] buffer, int bufferOffset, int length)
        {
            return this._reader.GetBytes(ordinal, dataOffset, buffer, bufferOffset, length);
        }

        [DebuggerStepThrough()]
        public override char GetChar(int ordinal)
        {
            return this._reader.GetChar(ordinal);
        }

        [DebuggerStepThrough()]
        public override long GetChars(int ordinal, long dataOffset, char[] buffer, int bufferOffset, int length)
        {
            return this._reader.GetChars(ordinal, dataOffset, buffer, bufferOffset, length);
        }

        [DebuggerStepThrough()]
        public override Guid GetGuid(int ordinal)
        {
            return this._reader.GetGuid(ordinal);
        }

        [DebuggerStepThrough()]
        public override short GetInt16(int ordinal)
        {
            return this._reader.GetInt16(ordinal);
        }

        [DebuggerStepThrough()]
        public override object GetValue(int ordinal)
        {
            return this._reader.GetValue(ordinal);
        }

        [DebuggerStepThrough()]
        public override int GetValues(object[] values)
        {
            return this._reader.GetValues(values);
        }

        [DebuggerStepThrough()]
        public override double GetDouble(int ordinal)
        {
            return this._reader.GetDouble(ordinal);
        }

        [DebuggerStepThrough()]
        public override float GetFloat(int ordinal)
        {
            return this._reader.GetFloat(ordinal);
        }


        #region Internal members...

        /// <summary>
        /// データソースに対して実行する SQL ステートメントまたはストアドプロシージャを取得します。
        /// </summary>
        internal DbCommand InnerCommand
        {
            [DebuggerStepThrough()]
            get { return this._command; }
        }

        #endregion

        #region Protected members...

        /// <summary>
        /// DbDataReader によって使用されているマネージリソースを解放し、オプションでアンマネージリソースも解放します。
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this._command != null) { this._command.Dispose(); }
                if (this._reader != null) { this._reader.Dispose(); }
            }

            base.Dispose(disposing);
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

        #region Private mebers..

        /// <summary>データソースに対して実行する SQL ステートメントまたはストアドプロシージャを表わします。</summary>
        private readonly DbCommand _command;
        /// <summary>データソースから行の前方向ストリームを読み取ります。</summary>
        private DbDataReader _reader;

        #endregion
    }
}
