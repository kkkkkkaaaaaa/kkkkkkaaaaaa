using System;
using Xunit;

namespace kkkkkkaaaaaa.Xunit.System
{
    class IntPtrFacts
    {
        [Fact()]
        public void DefaultIntPtrFact()
        {
            Assert.Equal(IntPtr.Zero, default(IntPtr));
        }
    }
}
