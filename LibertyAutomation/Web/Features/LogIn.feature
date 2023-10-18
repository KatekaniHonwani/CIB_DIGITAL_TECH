Feature: LogIn
	

@mytag
Scenario: Login to SSP
	Given the user is on the login page
	When user logs in
	Then the SSP dashboard is displayed
