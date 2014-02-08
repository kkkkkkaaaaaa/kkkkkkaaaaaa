using System;
using kkkkkkaaaaaa.Runtime.InteropServices;
using Xunit;

namespace kkkkkkaaaaaa.Xunit.System
{
    public class ConvertFacts
    {
        [Fact()]
        public void ToBooleanFact()
        {
            // System.Int32
            this.AssertConvertInt32ToBoolean(int.MinValue, true);
            this.AssertConvertInt32ToBoolean(0, false);
            this.AssertConvertInt32ToBoolean(MinWinDef.FALSE, false);
            this.AssertConvertInt32ToBoolean(1, true);
            this.AssertConvertInt32ToBoolean(MinWinDef.TRUE, true);
            this.AssertConvertInt32ToBoolean(2, true);
            this.AssertConvertInt32ToBoolean(int.MaxValue, true);

            // System.Byte
            this.AssertConvertByteToBoolean(0, false);
            this.AssertConvertByteToBoolean(byte.MinValue, false);
            this.AssertConvertByteToBoolean(1, true);
            this.AssertConvertByteToBoolean(2, true);
            this.AssertConvertByteToBoolean(byte.MaxValue, true);
        }

        #region Private members...

        private void AssertConvertInt32ToBoolean(int value, bool expected)
        {
            var actual = Convert.ToBoolean(value);
            Assert.Equal(expected, actual);
        }

        private void AssertConvertByteToBoolean(byte value, bool expected)
        {
            var actual = Convert.ToBoolean(value);
            Assert.Equal(expected, actual);
        }

        #endregion
    }
}