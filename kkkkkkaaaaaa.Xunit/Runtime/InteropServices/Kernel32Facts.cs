using Xunit;
using kkkkkkaaaaaa.Runtime.InteropServices;

namespace kkkkkkaaaaaa.Xunit.Runtime.InteropServices
{
    public class Kernel32Facts
    {
        [Fact()]
        public void GetsystemInfoFact()
        {
            var info = default(SYSTEM_INFO);
            Kernel32.GetSystemInfo(ref info);

            Assert.NotEqual(default(SYSTEM_INFO), info);
        }
    }
}