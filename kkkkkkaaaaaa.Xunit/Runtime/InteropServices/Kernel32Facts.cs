using System;
using System.Diagnostics;
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

            var architecture = Enum.GetName(typeof(PROCESSOR_ARCHITECTURE), info.wProcessorArchitecture);
            Assert.NotNull(architecture);

            var mask = info.dwActiveProcessorMask;
        }

        [Fact()]
        public void GetNativeSystemInfoFact()
        {
            var info = default(SYSTEM_INFO);

            Kernel32.GetNativeSystemInfo(ref info);

            Assert.NotEqual(default(SYSTEM_INFO), info);
            Assert.NotEqual(PROCESSOR_ARCHITECTURE.UNKNOWN, info.wProcessorArchitecture);
        }

        [Fact()]
        public void IsWow64ProcessFact()
        {
            var current = Process.GetCurrentProcess();
            var wow64 = IntPtr.Zero;
            var result = Kernel32.IsWow64Process(current.Handle, out wow64);

            Assert.Equal(WinDef.TRUE, result);
        }
    }

    /*
    internal enum PROCESSOR_ARCHITECTURE
    {
        AMD64   = 9,
        IA64    = 6,
        INTEL   = 0,
        UNKNOWN = 0xffff,
    }
    */
}