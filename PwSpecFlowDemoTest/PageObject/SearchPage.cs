using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PwSpecFlowDemoTest.PageObject
{
    public class SearchPage : WebPage
    {
        public SearchPage(IPage page) : base(page)
        {

        }

        public async Task OpenSearchPage()
        {
            await Page.GotoAsync("https://www.google.ru/");
        }

        public async Task FillSearchInputAsync(string searchText)
        {
            await Page.Locator("input[name='q']").FillAsync(searchText);
        }

        public async Task SearchAsync()
        {
            await Page.Locator("(//input[@name='btnK'])[1]").ClickAsync();
        }
    }
}
