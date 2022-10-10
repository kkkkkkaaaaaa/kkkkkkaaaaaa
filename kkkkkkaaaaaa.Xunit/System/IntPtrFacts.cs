using Xunit;

namespace kkkkkkaaaaaa.Xunit.System
{
    /// <summary></summary>
    public class IntPtrFacts
    {
        /// <summary></summary>
        [Fact()]
        public void DefaultIntPtrFact()
        {
            Assert.True(default(IntPtr) == IntPtr.Zero);
        }
    }
}
