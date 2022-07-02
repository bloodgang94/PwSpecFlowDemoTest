using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoDi;
using Microsoft.Playwright;
using PwSpecFlowDemoTest.Drivers;
using PwSpecFlowDemoTest.Models;
using TechTalk.SpecFlow;

namespace PwSpecFlowDemoTest.Hooks
{
    [Binding]
    internal class PlaywrightHook
    {
        private readonly IObjectContainer _objectContainer;
        private readonly PlaywrightConfig _config;
        private IBrowser? _browser;

        public PlaywrightHook(IObjectContainer objectContainer, PlaywrightConfig playwrightConfig)
        {
            _objectContainer = objectContainer;
            _config = playwrightConfig;
        }

        [BeforeScenario("Ui")]
        public async Task CreateDriverAsync()
        {
            _browser = await PlaywrightFactory.CreateDriverAsync(_config);
            _objectContainer.RegisterInstanceAs(_browser);
            var page = await _browser.NewPageAsync(new BrowserNewPageOptions
            {
                IgnoreHTTPSErrors = true
            });

            _objectContainer.RegisterInstanceAs(page);
        }

        [AfterScenario]
        public async Task DisposePlaywright()
        {
            await _browser?.CloseAsync()!;
            await _browser.DisposeAsync();
        }
    }
}
