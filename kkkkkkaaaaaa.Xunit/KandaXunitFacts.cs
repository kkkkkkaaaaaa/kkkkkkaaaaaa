using System;

namespace kkkkkkaaaaaa.Xunit
{
    public class KandaXunitFacts
    {
        #region Protected members...

        #endregion

        /// <summary>
        /// コンストラクター。
        /// </summary>
        protected KandaXunitFacts()
        {
            this.TestData = new Uri(new Uri(AppDomain.CurrentDomain.BaseDirectory), @"../../TestData/");
        }

        /// <summary>
        /// テストデータのフォルダのルートを返します。
        /// </summary>
        protected Uri TestData { get; private set; }
    }
}