using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoDi;
using Microsoft.Extensions.Configuration;
using PwSpecFlowDemoTest.Models;
using TechTalk.SpecFlow;

namespace PwSpecFlowDemoTest.Hooks
{
    [Binding]
    internal class ConfigurationBinding
    {
        private readonly IObjectContainer _objectContainer;
        public ConfigurationBinding(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }


        [BeforeScenario]
        public void CreateConfig()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var section = config.GetSection(nameof(PlaywrightConfig));
            var pwConfig = section.Get<PlaywrightConfig>();

            _objectContainer.RegisterInstanceAs(pwConfig);

        }
    }

   
}
