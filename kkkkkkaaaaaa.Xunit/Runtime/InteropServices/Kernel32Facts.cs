using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using Xunit;
using kkkkkkaaaaaa.Runtime.InteropServices;

namespace kkkkkkaaaaaa.Xunit.Runtime.InteropServices
{
    public class Kernel32Facts : KandaXunitFacts
    {
        [Fact()]
        public void GetLastErrorFact()
        {
            var lastWin32Error = Marshal.GetLastWin32Error();
            var lastError = Kernel32.GetLastError();
            Assert.Equal((uint)lastWin32Error, lastError);
            Assert.True(true, string.Format(@"Kernel32.GetLastError() == {0}", lastError));
        }

        [Fact()]
        public void FormatMessage()
        {
            var messageId = Kernel32.GetLastError();
            var languageId = WinNT.MAKELANGID(WinNT.LANG_NEUTRAL, WinNT.SUBLANG_DEFAULT);
            var buffer = default(IntPtr);

            var length = Kernel32.FormatMessage((WinBase.FORMAT_MESSAGE_ALLOCATE_BUFFER | WinBase.FORMAT_MESSAGE_FROM_SYSTEM | WinBase.FORMAT_MESSAGE_IGNORE_INSERTS), IntPtr.Zero, messageId, languageId, out buffer, 0, null);
            var message = Marshal.PtrToStringAnsi(buffer, (int)length);
            Assert.False(length <= 0, message);
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

            var wow64 = default(bool);
            var result = Kernel32.IsWow64Process(current.Handle, out wow64);
            Assert.True(result);
        }

        [Fact()]
        public void LoadLibraryFact()
        {
            var fileName = new Uri(this.TestData, @"./kkkkkkaaaaaa.testdata.library/kkkkkkaaaaaa.testdata.library.dll");

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
            var fileName = new Uri(this.TestData, @"./kkkkkkaaaaaa.testdata.library/kkkkkkaaaaaa.testdata.library.dll");
            var module = Kernel32.LoadLibrary(fileName.LocalPath);

            var result = Kernel32.FreeLibrary(module);
            Assert.True(result);
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
            var fileName = new Uri(this.TestData, @"./kkkkkkaaaaaa.testdata.library/kkkkkkaaaaaa.testdata.library.dll");

            var module = IntPtr.Zero;

            try
            {
                module = Kernel32.LoadLibrary(fileName.LocalPath);

                var api = Kernel32.GetProcAddress(module, @"Function");
                Assert.NotEqual(IntPtr.Zero, api);

                var d = (Function)Marshal.GetDelegateForFunctionPointer(api, typeof(Function));
                var info = default(_SYSTEM_INFO);
                d.Invoke();
            }
            finally
            {
                if (module != IntPtr.Zero) { var freed = Kernel32.FreeLibrary(module); }
            }
        }

        #region Private members...

        /// <summary></summary>
        private delegate void Function();

        #endregion
    }
}