Feature: Calculator

Search google test

@Ui
Scenario Outline: Link Search
	Given The search page is open
	When I enter a search phrase <site>
	And I press the search button
	Then The search results contain the url <site>

	Examples: 
	| site            |
	| www.youtube.com |
	| twitter.com     |