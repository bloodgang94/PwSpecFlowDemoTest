using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using PwSpecFlowDemoTest.Models;

namespace PwSpecFlowDemoTest.Drivers
{
    internal class LocalPlaywrightDriver : IPlaywrightDriver
    {
        public async Task<IBrowser> InitDriverAsync(IPlaywright playwright, PlaywrightConfig pwDto)
        {

            var headless = pwDto.BrowserArgs != null && bool.Parse(pwDto.BrowserArgs["headless"]);

            var browser = pwDto.Browser switch
            {
                Browser.Chrome => playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions() { Channel = "chrome", Headless = headless }),
                Browser.Firefox => playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions() { Headless = headless }),
                Browser.Chromium => playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions() { Headless = headless }),
                Browser.WebKit => playwright.Webkit.LaunchAsync(new BrowserTypeLaunchOptions() { Headless = headless }),
                _ => throw new NotImplementedException(nameof(pwDto.Browser))
            };

            return await browser;
        }
    }
}
