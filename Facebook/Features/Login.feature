Feature: Login
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers


Background: Reset Browser

@mytag
Scenario: Login with Correct Details
	Given I have entered username into the Website  
	And I have entered password into the website
	When I click the login button
	Then i should see the welcome page
	

Scenario: Login with Wrong Details
	Given I have entered username into the Website  
	And I have entered password into the website
	When I click the login button
	Then i should not see the welcome page

