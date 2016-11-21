using kkkkkkaaaaaa.Runtime.InteropServices;
using Xunit;

namespace kkkkkkaaaaaa.Xunit.Runtime.InteropServices
{
    /// <summary></summary>
    public class ShLwApiFacts
    {
        /// <summary></summary>
        [Theory()]
        [InlineData(@"01", @"01")]
        public void StrCmpLogicalWExpectsEqualsPsz2Theory(string psz1, string psz2)
        {
            var result = ShLwApi.StrCmpLogicalW(psz1, psz2);

            Assert.True(result == 0);
        }

        /// <summary></summary>
        [Theory()]
        [InlineData(@"01", @"1")]
        public void StrCmpLogicalWExpectsGreaterThanPsz2Theory(string psz1, string psz2)
        {
            var result = ShLwApi.StrCmpLogicalW(psz1, psz2);

            Assert.True(result < 0);
        }

        /// <summary></summary>
        [Theory()]
        [InlineData(@"1", @"01")]
        public void StrCmpLogicalWExpectsLessThanPsz2Theory(string psz1, string psz2)
        {
            var result = ShLwApi.StrCmpLogicalW(psz1, psz2);

            Assert.True(0 < result);
        }
    }
}