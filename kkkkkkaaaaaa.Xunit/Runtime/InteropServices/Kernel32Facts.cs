using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using Xunit;
using kkkkkkaaaaaa.Runtime.InteropServices;

namespace kkkkkkaaaaaa.Xunit.Runtime.InteropServices
{
    public class Kernel32Facts
    {
        [Fact()]
        public void GetLastErrorFact()
        {
            var lastWin32Error = Marshal.GetLastWin32Error();
            var lastError = Kernel32.GetLastError();
            Assert.Equal((uint)lastWin32Error, lastError);
        }

        [Fact()]
        public void GetSystemInfoFact()
        {
            var info = default(_SYSTEM_INFO);
            Kernel32.GetSystemInfo(out info);

            var oemId = info.DUMMYUNIONNAME.dwOemId;
            var architecture = info.DUMMYUNIONNAME.DUMMYSTRUCTNAME.wProcessorArchitecture;
            var reserved = info.DUMMYUNIONNAME.DUMMYSTRUCTNAME.wReserved;

            var size = info.dwPageSize;
            var minimumAddress = info.lpMinimumApplicationAddress;
            var maximunAddress = info.lpMaximumApplicationAddress;
            var mask = info.dwActiveProcessorMask;
            var processors = info.dwNumberOfProcessors;
            var type = info.dwProcessorType;
            var granularity = info.dsAllocationGranularity;
            var level = info.wProcessorLevel;
            var revision = info.wProcessorRevision;
        }

        [Fact()]
        public void GetNativeSystemInfoFact()
        {
            var info = default(_SYSTEM_INFO);

            Kernel32.GetNativeSystemInfo(out info);

            Assert.NotEqual(default(_SYSTEM_INFO), info);
        }

        [Fact()]
        public void IsWow64ProcessFact()
        {
            var current = Process.GetCurrentProcess();
            var wow64 = IntPtr.Zero;
            var result = Kernel32.IsWow64Process(current.Handle, out wow64);

            Assert.NotEqual(WinDef.FALSE, result);
        }

        [Fact()]
        public void LoadLibraryFact()
        {
            var fileName = new Uri(this._testData, @"./kkkkkkaaaaaa.testdata.library/kkkkkkaaaaaa.testdata.library.dll");

            var module = IntPtr.Zero;

            try
            {
                module = Kernel32.LoadLibrary(fileName.LocalPath);
                Assert.NotEqual(IntPtr.Zero, module);
            }
            finally
            {
                if (module != IntPtr.Zero) { var freed = Kernel32.FreeLibrary(module); }
            }
        }

        [Fact()]
        public void LoadLibraryExFact()
        {
            var fileName = @"kernel32.dll";
            //var fileName = new long(Uri);

            var module = IntPtr.Zero;

            try
            {
                module = Kernel32.LoadLibraryEx(fileName, IntPtr.Zero, WinBase.LOAD_LIBRARY_AS_DATAFILE);
                Assert.NotEqual(IntPtr.Zero, module);
            }
            finally
            {
                if (module != IntPtr.Zero) { var freed = Kernel32.FreeLibrary(module); }
            }
        }

        [Fact()]
        public void FreeLibraryFact()
        {
            var fileName = new Uri(this._testData, @"./kkkkkkaaaaaa.testdata.library/kkkkkkaaaaaa.testdata.library.dll");

            var module = Kernel32.LoadLibrary(fileName.LocalPath);
            var result = Kernel32.FreeLibrary(module);

            Assert.NotEqual(WinDef.FALSE, result);
        }

        [Fact()]
        public void GetModuleHandleFact()
        {
            var handle = Kernel32.GetModuleHandle(@"kernel32.dll");
            Assert.NotEqual(IntPtr.Zero, handle);
        }

        [Fact()]
        public void GetModuleFileName()
        {
            var handle = Kernel32.GetModuleHandle(@"kernel32.dll");

            var filename = new StringBuilder(0, 260);
            var length = Kernel32.GetModuleFileName(handle, filename, (uint)filename.MaxCapacity);

            Assert.True(0 < length);
        }

        [Fact()]
        public void GetProcAddressFact()
        {
            var fileName = new Uri(this._testData, @"./kkkkkkaaaaaa.testdata.library/kkkkkkaaaaaa.testdata.library.dll");

            var module = IntPtr.Zero;

            try
            {
                module = Kernel32.LoadLibrary(@"kernel32.dll");
                //module = Kernel32.LoadLibrary(fileName.LocalPath);

                var api = Kernel32.GetProcAddress(module, @"GetNativeSystemInfo");
                Assert.NotEqual(IntPtr.Zero, api);

                var d = (GetNativeSystemInfo)Marshal.GetDelegateForFunctionPointer(api, typeof(GetNativeSystemInfo));
                var info = default(_SYSTEM_INFO);
                d.Invoke(out info);
            }
            finally
            {
                if (module != IntPtr.Zero) { var freed = Kernel32.FreeLibrary(module); }
            }
        }
        /*
         * C:\csvn\bin\
         * ;C:\csvn\Python25\
         * ;%SystemRoot%\system32
         * ;%SystemRoot%;%SystemRoot%\System32\Wbem
         * ;C:\Program Files\Justsystems\JSLIB32
         * ;C:\Program Files\Common Files\Roxio Shared\10.0\DLLShared\
         * ;C:\Program Files\Common Files\Roxio Shared\DLLShared\
         * ;C:\Program Files\Common Files\Roxio Shared\DLLShared\
         * ;C:\Program Files\Common Files\Roxio Shared\10.0\DLLShared\
         * ;\C:\Program Files\Sony\VAIO One Touch Startup Tool
         * ;C:\Program Files\Intel\WiFi\bin\
         * ;c:\Program Files\Microsoft SQL Server\90\Tools\binn\
         * ;C:\Program Files\Microsoft SQL Server\80\Tools\Binn\
         * ;C:\Program Files\Microsoft SQL Server\90\DTS\Binn\
         * ;%SYSTEMROOT%\System32\WindowsPowerShell\v1.0\
         * ;C:\Program Files\Apache\Ant\1.8.2\bin\
         * ;C:\Program Files\Microsoft Windows Performance Toolkit\
         * ;C:\Program Files\Adobe\Adobe Flash CS4
         * ;C:\Program Files\EmEditor
         * ;c:\Program Files\Microsoft ASP.NET\ASP.NET Web Pages\v1.0\
         * ;C:\Program Files\TortoiseSVN\bin
         * ;C:\Program Files\Microsoft SQL Server\110\Tools\Binn\
         * ;c:\Program Files\Microsoft SQL Server\110\Tools\Binn\ManagementStudio\
         * ;c:\Program Files\Microsoft SQL Server\110\DTS\Binn\
         * ;C:\Program Files\Microsoft\Web Platform Installer\
         * ;C:\Program Files\QuickTime\QTSystem\
         * ;C:\Program Files\TortoiseGit\bin
         * ;C:\Program Files\Git\cmd
         */

        #region Private members...

        /// <summary></summary>
        private readonly Uri _testData = new Uri(new Uri(AppDomain.CurrentDomain.BaseDirectory), @"../../TestData/");

        #endregion
    }
}