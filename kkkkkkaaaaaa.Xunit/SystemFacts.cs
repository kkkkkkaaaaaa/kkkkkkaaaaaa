using System;
using Xunit;

namespace kkkkkkaaaaaa.Xunit
{
    public class SystemFacts
    {
        [Fact()]
        public void DefaultBooleanFact()
        {
            Assert.Equal(false, default(Boolean));
        }

        [Fact()]
        public void DefaultIntPtrFact()
        {
            Assert.Equal(IntPtr.Zero, default(IntPtr));
        }
    }
}