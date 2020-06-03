Feature: SearchCityByCountry
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Find cities from country with id = 4
	Given I insert Country Id '4' in city controller
	Then All cities from that country are shown
