using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Xunit;

namespace kkkkkkaaaaaa.Xunit.Practices.Unity
{
    public class KandaUnityContainerFacts
    {
        [Fact]
        public void LoadConfigurationFact()
        {
            var container =  new UnityContainer().LoadConfiguration();
        }
    }
}
