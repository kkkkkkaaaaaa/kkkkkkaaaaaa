using System;
using Xunit;
using kkkkkkaaaaaa.Runtime.InteropServices;

namespace kkkkkkaaaaaa.Xunit.Runtime.InteropServices
{
    /// <summary>
    /// 
    /// </summary>
    public class WinBaseFacts : KandaXunitFacts
    {
        [Fact(Skip="")]
        public void GetFileAttributes()
        {
            var fileName = new Uri(this.TestData, @"./GetFileAttributesFact").LocalPath;

            var attributes = WinBase.GetFileAttributes(fileName);

            Assert.NotEqual(WinBase.INVALID_FILE_ATTRIBUTES, (int)attributes);
            Assert.True((attributes & WinNT.FILE_ATTRIBUTE_DIRECTORY) == WinNT.FILE_ATTRIBUTE_DIRECTORY);
        }
    }
}