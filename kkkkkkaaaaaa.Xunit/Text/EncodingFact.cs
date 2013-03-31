using System.Text;
using Xunit;

namespace kkkkkkaaaaaa.Xunit.Text
{
    public class EncodingFact
    {
        [Fact()]
        public void UTF8Fact()
        {
            Assert.Equal(Encoding.UTF8, new UTF8Encoding(true, false));

            Assert.NotEqual(Encoding.UTF8, new UTF8Encoding(true, true));
            Assert.NotEqual(Encoding.UTF8, new UTF8Encoding(false, true));
            Assert.NotEqual(Encoding.UTF8, new UTF8Encoding(false, false));
        }
    }
}