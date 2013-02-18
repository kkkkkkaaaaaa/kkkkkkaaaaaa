using System.Runtime.InteropServices;
using Shell32;
using Xunit;

namespace kkkkkkaaaaaa.Xunit.Shell32
{
    public class ShellFacts
    {
        [Fact()]
        public void s()
        {
            var shell = default(Shell);
            var desktop = default(Folder);

            try
            {
                shell = new Shell();
                desktop = shell.NameSpace(ShellSpecialFolderConstants.ssfDESKTOP);
            }
            finally
            {
                if (desktop != null) { Marshal.ReleaseComObject(desktop); }
                if (shell != null) { Marshal.ReleaseComObject(shell); }
            }
        }
    }
}