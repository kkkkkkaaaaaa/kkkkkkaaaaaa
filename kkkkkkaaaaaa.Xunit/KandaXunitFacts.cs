using System;

namespace kkkkkkaaaaaa.Xunit
{
    public class KandaXunitFacts
    {
        protected KandaXunitFacts()
        {
            this.TestData = new Uri(new Uri(AppDomain.CurrentDomain.BaseDirectory), @"../../TestData/");
        }

        protected Uri TestData { get; private set; }
    }
}