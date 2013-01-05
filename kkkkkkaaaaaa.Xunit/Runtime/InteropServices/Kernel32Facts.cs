﻿using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Xunit;
using kkkkkkaaaaaa.Runtime.InteropServices;

namespace kkkkkkaaaaaa.Xunit.Runtime.InteropServices
{
    public class Kernel32Facts
    {
        [Fact()]
        public void GetSystemInfoFact()
        {
            /*
            var info = default(SYSTEM_INFO);
            Kernel32.GetSystemInfo(ref info);

            Assert.NotEqual(default(SYSTEM_INFO), info);

            var architecture = Enum.GetName(typeof(PROCESSOR_ARCHITECTURE), info.wProcessorArchitecture);
            Assert.NotNull(architecture);

            var mask = info.dwActiveProcessorMask;
            */
        }

        [Fact()]
        public void GetSystemInfoOemIdFact()
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

            Kernel32.GetNativeSystemInfo(ref info);

            Assert.NotEqual(default(_SYSTEM_INFO), info);
            //Assert.NotEqual(PROCESSOR_ARCHITECTURE.UNKNOWN, info.wProcessorArchitecture);
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
        public void FreeLibraryFact()
        {
            var fileName = new Uri(this._testData, @"./kkkkkkaaaaaa.testdata.library/kkkkkkaaaaaa.testdata.library.dll");

            var module = Kernel32.LoadLibrary(fileName.LocalPath);
            var result = Kernel32.FreeLibrary(module);

            Assert.NotEqual(WinDef.FALSE, result);
        }

        [Fact()]
        public void GetProcAddressFact()
        {
            var fileName = new Uri(this._testData, @"./kkkkkkaaaaaa.testdata.library/kkkkkkaaaaaa.testdata.library.dll");

            var module = IntPtr.Zero;

            try
            {
                //module = Kernel32.LoadLibrary(@"kernel32.dll");
                module = Kernel32.LoadLibrary(fileName.LocalPath);

                var api = Kernel32.GetProcAddress(module, @"Function");

                if (api == IntPtr.Zero) { var error = Marshal.GetLastWin32Error(); }
            }
            finally
            {
                if (module != IntPtr.Zero) { var freed = Kernel32.FreeLibrary(module); }
            }

        }

        #region Private members...

        /// <summary></summary>
        private readonly Uri _testData = new Uri(new Uri(AppDomain.CurrentDomain.BaseDirectory), @"../../TestData/");

        #endregion
    }
}