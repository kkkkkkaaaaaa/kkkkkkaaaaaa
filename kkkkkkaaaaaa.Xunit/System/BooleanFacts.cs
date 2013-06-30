using System;
using Xunit;

namespace kkkkkkaaaaaa.Xunit.System
{
    public class BooleanFacts
    {
        [Fact()]
        public void DefaultBooleanFact()
        {
            Assert.Equal(false, default(Boolean));
        }

        [Fact()]
        public void TryParseFact()
        {
            this.assertParseTrial(true, bool.TrueString, true);
            this.assertParseTrial(true, @"True", true);
            this.assertParseTrial(true, @"true", true);
            this.assertParseTrial(true, @"tRUE", true);
            this.assertParseTrial(true, @"l;kjh", false);
            this.assertParseTrial(true, null, false);
            this.assertParseTrial(true, @"", false);
            this.assertParseTrial(true, @" ", false);
            this.assertParseTrial(true, @"　", false);
        }

        #region Private members..

        /// <summary>
        /// 
        /// </summary>
        /// <param name="default"></param>
        /// <param name="value"></param>
        /// <param name="expects"></param>
        private void assertParseTrial(bool @default, string value, bool expects)
        {
            var result = @default;
            bool.TryParse(value, out result);

            if (expects) { Assert.True(result); }
            else { Assert.False(result); }
        }

        #endregion

    }
}