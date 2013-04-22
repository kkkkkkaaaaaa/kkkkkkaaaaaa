using System;
using Xunit;
using kkkkkkaaaaaa.WindowsAzure.Storage.Blob;

namespace kkkkkkaaaaaa.Xunit.WindowsAzure.Storage.Blob
{
    public class Class1Facts
    {
        [Fact()]
        public void DoFact()
        {
            var o = new Class1();
            var uri = new Uri(new Uri(AppDomain.CurrentDomain.BaseDirectory), @"../../TestData/WindowsAzure.Blob/a.txt");

            o.Do(uri.LocalPath);
        }
    }
}