using System;
using System.Runtime.InteropServices;
using kkkkkkaaaaaa.Runtime.InteropServices;
using Xunit;

namespace kkkkkkaaaaaa.Xunit.Runtime.InteropServices
{
    public class Shell32Facts
    {
        [Fact()]
        public void SHGetKnownFolderPathFact()
        {
            var folder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop, Environment.SpecialFolderOption.None);

            var ppszPath = default(IntPtr);
            var result = Shell32.SHGetKnownFolderPath(KnownFolders.FOLDERID_Desktop, KNOWN_FOLDER_FLAG.KF_FLAG_DEFAULT_PATH, IntPtr.Zero, out ppszPath);
            Assert.Equal(WinError.S_OK, result);

            try
            {
                var path = Marshal.PtrToStringAuto(ppszPath);
                Assert.Equal(folder, path);
            }
            finally
            {
                if (ppszPath != IntPtr.Zero) { Marshal.FreeCoTaskMem(ppszPath); }
            }

        }

    }
}
