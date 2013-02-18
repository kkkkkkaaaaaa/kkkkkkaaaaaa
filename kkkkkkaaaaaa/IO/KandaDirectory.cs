using System;
using System.IO;
using kkkkkkaaaaaa.Runtime.InteropServices;

namespace kkkkkkaaaaaa.IO
{
    public static class KandaDirectory
    {
        public static event Action<object, EventArgs> BeforeCopy;
        public static event Action<object, EventArgs> AfterCopy;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceDirName"></param>
        /// <param name="destDirName"></param>
        /// <param name="overwrite"></param>
        public static void Copy(string sourceDirName, string destDirName, bool overwrite)
        {
            if (!Directory.Exists(sourceDirName)) { throw new DirectoryNotFoundException(string.Format(@"{0}", sourceDirName)); }
            if (!Directory.Exists(destDirName)) { Directory.CreateDirectory(destDirName); }
            //else if (!overwrite) { /* 上書きしますか？ */ }

            if (KandaDirectory.BeforeCopy != null) { KandaDirectory.BeforeCopy(null, EventArgs.Empty); }

            var entries = Directory.EnumerateFileSystemEntries(sourceDirName);
            foreach (var entry in entries)
            {
                var attributes = WinBase.GetFileAttributes(entry);
                if ((attributes & WinNT.FILE_ATTRIBUTE_DIRECTORY) == WinNT.FILE_ATTRIBUTE_DIRECTORY)
                {
                    KandaDirectory.Copy(entry, Path.Combine(destDirName, new DirectoryInfo(entry).Name), overwrite);
                }
                else
                {
                    var destFileName = Path.Combine(destDirName, new FileInfo(entry).Name);
                    File.Copy(entry, destFileName, overwrite);
                }

                if (KandaDirectory.AfterCopy != null) { KandaDirectory.AfterCopy(null, EventArgs.Empty); }
            }
        }
    }
}