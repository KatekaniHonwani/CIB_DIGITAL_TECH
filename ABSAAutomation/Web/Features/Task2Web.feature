Feature: CIB DIGITAL TECH - Task 2 Web 

A short summary of the feature
@mytag
Scenario Outline: Navigation to Way2Automation Application
	Given user has "http://www.way2automation.com/angularjs-protractor/webtables/" to Way2Automation application
	When User navigate to the application
	Then user is presented with list of users in the table	

Scenario: Adding Users to the table
		Given the user is on web tables 
		When the user adds a new user

		| first_Name | last_Name | user_Name | password | customer    | role     | email             | cell   |
		| FName1     | LName1    | User1     | Pass1    | Company AAA | Admin    | admin@mail.com    | 082555 |
		| FName2     | LName2    | User2     | Pass2    | Company BBB | Customer | customer@mail.com | 083444 |
		
		Then User is displayed on the user table