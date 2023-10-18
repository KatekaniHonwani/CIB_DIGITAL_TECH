Feature: LogOut
	


Scenario: Verify if a user can logout of SSP successfully
	Given the user is on the login page
	And user logs in
	When user clicks logout button
	Then dialog box must pop up
	When user clicks cancel button
	Then the dialog box closes
	And user is still logged in
	When user clicks yes button in logout pop up screen
	Then user is logged out and lands on log in page
	
	