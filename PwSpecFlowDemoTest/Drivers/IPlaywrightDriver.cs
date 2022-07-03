using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using PwSpecFlowDemoTest.Models;

namespace PwSpecFlowDemoTest.Drivers
{
    internal interface IPlaywrightDriver
    {
        Task<IBrowser> InitDriverAsync(IPlaywright playwright, PlaywrightConfig pwDto);
    }
}
