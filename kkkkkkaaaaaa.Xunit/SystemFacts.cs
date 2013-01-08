using System;
using Xunit;

namespace kkkkkkaaaaaa.Xunit
{
    public class SystemFacts
    {
        [Fact()]
        public void DefaultIntPtrFact()
        {
            Assert.Equal(IntPtr.Zero, default(IntPtr));
        }
    }
}