using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using PwSpecFlowDemoTest.Models;

namespace PwSpecFlowDemoTest.Drivers
{
    internal class WssPlaywrightDriver : IPlaywrightDriver
    {
        public async Task<IBrowser> InitDriverAsync(IPlaywright playwright, PlaywrightConfig pwDto)
        {
            if (string.IsNullOrEmpty(pwDto.PlaywrightVersion))
            {
                throw new Exception($"{nameof(pwDto.PlaywrightVersion)} cannot be empty or null");
            }

            if (string.IsNullOrEmpty(pwDto.WssUrl))
            {
                throw new Exception($"{nameof(pwDto.WssUrl)} cannot be empty or null");
            }

            string args = string.Empty;

            if(pwDto.BrowserArgs is not null)
                args = string.Join("&", pwDto.BrowserArgs
                    .Select((x) => x.Key + "=" + x.Value));


            var connectionString = string.Format("{0}{1}/playwright-{2}?{3}",
                pwDto.WssUrl,
                pwDto.Browser.ToString().ToLower(),
                pwDto.PlaywrightVersion, args);

            var pwBrowser = pwDto.Browser switch
            {
                Browser.Chrome =>  playwright.Chromium.ConnectAsync(connectionString),
                Browser.Firefox => playwright.Firefox.ConnectAsync(connectionString),
                Browser.Chromium => playwright.Chromium.ConnectAsync(connectionString),
                Browser.WebKit =>  playwright.Webkit.ConnectAsync(connectionString),
                _ => throw new NotImplementedException(nameof(pwDto.Browser)),
            };

            return await pwBrowser;
        }
    }
}
