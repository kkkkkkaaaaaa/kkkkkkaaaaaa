using Xunit;
using kkkkkkaaaaaa.DomainModels;

namespace kkkkkkaaaaaa.Xunit.DomainModels
{
    /// <summary>
    /// 
    /// </summary>
    public class KandaDomainModelFacts : KandaXunitDomainModelFacts
    {
        /// <summary>
        /// 
        /// </summary>
        [Fact()]
        //[Fact(Skip = @"KandaDomainModelFacts.ResetFact()")]
        public void ResetFact()
        {
            Assert.True(KandaDomainModel.Reset());
        }
    }
}