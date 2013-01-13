using System.Runtime.InteropServices;
using Xunit;
using kkkkkkaaaaaa.Runtime.InteropServices;

namespace kkkkkkaaaaaa.Xunit.Runtime.InteropServices
{
    public class MarshalFacts
    {
        [Fact()]
        public void GetLastErrorFact()
        {
            var lastError = Kernel32.GetLastError();
            var lastWin32Error = Marshal.GetLastWin32Error();
            Assert.Equal((int)lastError, lastWin32Error);
        } 
    }
}