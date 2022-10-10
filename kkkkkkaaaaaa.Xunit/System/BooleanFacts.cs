using System;
using Xunit;

namespace kkkkkkaaaaaa.Xunit.System
{
    /// <summary>
    /// 
    /// </summary>
    public class BooleanFacts
    {
        /// <summary></summary>
        [Fact()]
        public void DefaultBooleanFact()
        {
            Assert.True(default(Boolean) == false);
        }

        /// <summary></summary>
        [Fact()]
        public void TryParseFact()
        {
            this.assertParseTrial(bool.TrueString, true);
            this.assertParseTrial(@"True", true);
            this.assertParseTrial(@"true", true);
            this.assertParseTrial(@"tRUE", true);
            this.assertParseTrial(@"l;kjh", false);
            this.assertParseTrial(null, false);
            this.assertParseTrial(@"", false);
            this.assertParseTrial(@" ", false);
            this.assertParseTrial(@"　", false);
        }

        #region Private members..

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="expected"></param>
        private void assertParseTrial(string? value, bool expected)
        {
            var result = default(bool);
            bool.TryParse(value, out result);

            Assert.Equal(expected, result);
        }

        #endregion

    }
}