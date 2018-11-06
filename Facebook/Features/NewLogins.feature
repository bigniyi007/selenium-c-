Feature: NewLogins
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario Outline: Login
	Given I have entered username '<username>' and password '<password>'
	When I login
	Then I should be informed that login '<result>'

	Examples: 
	| testing               | username | password             | result   |
	| valid combination     | tomsmith | SuperSecretPassword! | passed   |
	| invalid combination 1 | test     | test                 | failed   |
	| special characters    | $$$      | SuperSecretPassword! | failed   |
