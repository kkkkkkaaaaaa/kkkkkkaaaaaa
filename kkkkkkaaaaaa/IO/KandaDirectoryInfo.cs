using System.IO;
using System.Runtime.InteropServices;
using Shell32;

namespace kkkkkkaaaaaa.IO
{
    /// <summary>
    /// 
    /// </summary>
    public static class KandaDirectoryInfo
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceDirInfo"></param>
        /// <param name="destDirName"></param>
        /// <param name="overwrite"></param>
        /// <returns></returns>
        public static DirectoryInfo CopyTo(this DirectoryInfo sourceDirInfo, string destDirName, bool overwrite)
        {
            KandaDirectory.Copy(sourceDirInfo.FullName, destDirName, overwrite);

            return new DirectoryInfo(destDirName);
        }
    }
}