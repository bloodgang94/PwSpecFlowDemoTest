using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using PwSpecFlowDemoTest.Models;

namespace PwSpecFlowDemoTest.Drivers
{
    internal class PlaywrightFactory
    {
        public static async Task<IBrowser> CreateDriverAsync(PlaywrightConfig pwDto)
        {
            var playwright = await Playwright.CreateAsync();

            var pwBrowser = pwDto.RunTypeBrowser switch
            {
                RunTypeBrowser.Local => new LocalPlaywrightDriver().InitDriverAsync(playwright, pwDto),
                RunTypeBrowser.Wss => new WssPlaywrightDriver().InitDriverAsync(playwright, pwDto),
                _ => throw new ArgumentOutOfRangeException()
            };

            return await pwBrowser;
        }
    }
}
