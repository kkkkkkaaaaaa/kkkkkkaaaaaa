using Xunit;

namespace kkkkkkaaaaaa.Xunit.System
{
    public class UInt32Facts
    {
        [Fact()]
        public void Is0x80000000Fact()
        {
            Assert.True(0x80000000 == ((uint)int.MaxValue + 1));
        }
    }
}