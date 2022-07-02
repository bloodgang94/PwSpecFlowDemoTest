using FluentAssertions;
using PwSpecFlowDemoTest.PageObject;
using TechTalk.SpecFlow;

namespace PwSpecFlowDemoTest.StepDefinitions
{
    [Binding]
    public sealed class GoogleSearchStepDefinitions
    {
        private readonly SearchPage _searchPage;
        private readonly ResultPage _resultPage;

        public GoogleSearchStepDefinitions(SearchPage searchPage, 
            ResultPage resultPage)
        {
            _searchPage = searchPage;
            _resultPage = resultPage;
        }

        [Given("The search page is open")]
        public async Task SearchPageOpenAsync()
        {
            await _searchPage.OpenSearchPage();
        }

        [When("I enter a search phrase (.*)")]
        public async Task EnterSearchPhraseAsync(string site)
        {
            await _searchPage.FillSearchInputAsync(site);
        }

        [When("I press the search button")]
        public async Task PressSearchButtonAsync()
        {
            await _searchPage.SearchAsync();
        }

        [Then("The search results contain the url (.*)")]
        public async Task ThenTheResultShouldBe(string expected)
        {
            var actual = await _resultPage.GetResults();
            actual.Should().Contain(x => x.Contains(expected));
        }
    }
}