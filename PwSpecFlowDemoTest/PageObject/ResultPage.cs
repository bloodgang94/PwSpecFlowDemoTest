using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PwSpecFlowDemoTest.PageObject
{
    public class ResultPage : WebPage
    {
        public ResultPage(IPage page) : base(page)
        {
        }

        public async Task<IEnumerable<string>> GetResults()
        {
            await Page.WaitForResponseAsync("**/search**");
            var results = await Page.Locator("//cite").AllInnerTextsAsync();
            return results;
        }
    }
}
