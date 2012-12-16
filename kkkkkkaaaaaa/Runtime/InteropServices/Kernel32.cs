using System.Runtime.InteropServices;

namespace kkkkkkaaaaaa.Runtime.InteropServices
{
    public class Kernel32
    {
        /// <summary>
        /// �uGetSystemInfo function (Windows)�v
        /// http://msdn.microsoft.com/en-us/library/windows/desktop/ms724381.aspx
        /// 
        /// �uSYSTEM_INFO structure (Windows)�v
        /// http://msdn.microsoft.com/en-us/library/windows/desktop/ms724958.aspx
        /// </summary>
        /// <param name="lpSystemInfo"></param>
        [DllImport(@"kernel32.dll", SetLastError = true, BestFitMapping = true)]
        public static extern void GetSystemInfo(ref SYSTEM_INFO lpSystemInfo);
    }
}