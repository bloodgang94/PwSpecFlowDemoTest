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
            var browser = pwDto.Browser switch
            {
                Browser.Chrome => playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions() { Channel = "chrome"}),
                Browser.Firefox => playwright.Firefox.LaunchAsync(),
                Browser.Chromium => playwright.Chromium.LaunchAsync(),
                Browser.WebKit => playwright.Webkit.LaunchAsync(),
                _ => throw new NotImplementedException(nameof(pwDto.Browser))
            };

            return await browser;
        }
    }
}
