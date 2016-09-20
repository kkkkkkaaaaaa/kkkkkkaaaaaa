using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Xunit;
using kkkkkkaaaaaa.Runtime.InteropServices;

namespace kkkkkkaaaaaa.Xunit.Runtime.InteropServices
{
    /// <summary></summary>
    public class Advapi32Facts
    {
        /// <summary></summary>
        [Fact()]
        public void IsTextUnicodeFact()
        {
            var c = Assembly.GetExecutingAssembly().CodeBase;
            //var c = Assembly.GetEntryAssembly().CodeBase;
            //var reader = new StreamReader();

            var source = Encoding.Unicode.GetBytes(@"using System;
using System.Runtime.InteropServices;
using System.Text;
using Xunit;
using kkkkkkaaaaaa.Runtime.InteropServices;

namespace kkkkkkaaaaaa.Xunit.Runtime.InteropServices
{
    public class AdvApi32Facts
    {
        [Fact()]
        public void IsTextUnicodeFact()
        {
            var source = Encoding.Unicode.GetBytes(@);
            var lpv = default(IntPtr);

            try
            {
                lpv = Marshal.AllocHGlobal(source.Length);
                Marshal.Copy(source, 0, lpv, source.Length);

                var lpiResult = WinNT.IS_TEXT_UNICODE_STATISTICS;
                var result = AdvApi32.IsTextUnicode(lpv, source.Length, ref lpiResult);
                Assert.True(result);
            }
            finally
            {
                if (lpv != IntPtr.Zero) { Marshal.FreeHGlobal(lpv); }
            }



        }
    }
}");
            var lpv = default(IntPtr);

            try
            {
                lpv = Marshal.AllocHGlobal(source.Length);
                Marshal.Copy(source, 0, lpv, source.Length);

                var lpiResult = WinNT.IS_TEXT_UNICODE_STATISTICS;
                var result = Advapi32.IsTextUnicode(lpv, source.Length, ref lpiResult);
                Assert.True(result);
            }
            finally
            {
                if (lpv != IntPtr.Zero) { Marshal.FreeHGlobal(lpv); }
            }
        }


        /// <summary></summary>
        [Fact()]
        public void EnumDynamicTimeZoneInformationFact()
        {
            uint index = 0;
            while (true)
            {
                var zone = default(_TIME_DYNAMIC_ZONE_INFORMATION);
                var error = Advapi32.EnumDynamicTimeZoneInformation(index, out zone);
                if (error != WinError.ERROR_SUCCESS) { break; }

                index++;
            }

            Assert.True(0 < index);
            Assert.True(true);
        }
    }
}