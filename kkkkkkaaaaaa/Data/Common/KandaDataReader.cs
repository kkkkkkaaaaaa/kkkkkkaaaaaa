using System;
using System.Collections;
using System.Data;
using System.Data.Common;

namespace kkkkkkaaaaaa.Data.Common
{
    /// <summary>
    /// データソースから行の前方向ストリームを読み取ります。
    /// </summary>
    public class KandaDataReader : DbDataReader
    {
        /// <summary>
        /// コンストラクタ―。
        /// </summary>
        /// <param name="command"></param>
        public KandaDataReader(DbCommand command)
        {
            this._command = command;
        }

        /// <summary>
        /// データソースに対して実行するテキストコマンドを取得または設定します。
        /// </summary>
        public string CommandText
        {
            get { return this._command.CommandText; }
        }

        /// <summary>
        /// DbCommand.CommandText の解釈方法を指示または指定します。
        /// </summary>
        public CommandType CommandType
        {
            get { return this._command.CommandType; }
            set { this._command.CommandType = value; }
        }

        /// <summary>
        /// DbCommand.Connection に対して DbCommand.CommandText を実行し、CommandBehavior の値の 1 つを使用して DbDataReader を実行します。
        /// </summary>
        /// <param name="behavior"></param>
        /// <returns></returns>
        public DbDataReader ExecuteReader(CommandBehavior behavior)
        {
            this._reader = this._command.ExecuteReader(behavior);

            return this;
        }

        public DbDataReader ExecuteReader()
        {
            return this.ExecuteReader(CommandBehavior.Default);
        }

        /// <summary>
        /// DbDataReader オブジェクトを閉じます。
        /// </summary>
        public override void Close()
        {
            this._reader.Close();
        }

        public override DataTable GetSchemaTable()
        {
            throw new NotImplementedException();
        }

        public override bool NextResult()
        {
            throw new NotImplementedException();
        }

        public override bool Read()
        {
            throw new NotImplementedException();
        }

        public override int Depth
        {
            get { throw new NotImplementedException(); }
        }

        public override bool IsClosed
        {
            get { throw new NotImplementedException(); }
        }

        public override int RecordsAffected
        {
            get { throw new NotImplementedException(); }
        }

        public override bool GetBoolean(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override byte GetByte(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override long GetBytes(int ordinal, long dataOffset, byte[] buffer, int bufferOffset, int length)
        {
            throw new NotImplementedException();
        }

        public override char GetChar(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override long GetChars(int ordinal, long dataOffset, char[] buffer, int bufferOffset, int length)
        {
            throw new NotImplementedException();
        }

        public override Guid GetGuid(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override short GetInt16(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override int GetInt32(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override long GetInt64(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override DateTime GetDateTime(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override string GetString(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override object GetValue(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override int GetValues(object[] values)
        {
            throw new NotImplementedException();
        }

        public override bool IsDBNull(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override int FieldCount
        {
            get { throw new NotImplementedException(); }
        }

        public override object this[int ordinal]
        {
            get { throw new NotImplementedException(); }
        }

        public override object this[string name]
        {
            get { throw new NotImplementedException(); }
        }

        public override bool HasRows
        {
            get { throw new NotImplementedException(); }
        }

        public override decimal GetDecimal(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override double GetDouble(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override float GetFloat(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override string GetName(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override int GetOrdinal(string name)
        {
            throw new NotImplementedException();
        }

        public override string GetDataTypeName(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override Type GetFieldType(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #region Private mebers..

        private readonly DbCommand _command;

        private DbDataReader _reader;

        #endregion
    }
}