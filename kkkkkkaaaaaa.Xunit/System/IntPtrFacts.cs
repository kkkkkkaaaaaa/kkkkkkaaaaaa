using System;
using Xunit;

namespace kkkkkkaaaaaa.Xunit.System
{
    public class IntPtrFacts
    {
        [Fact()]
        public void DefaultIntPtrFact()
        {
            Assert.Equal(IntPtr.Zero, default(IntPtr));
        }
    }
}
