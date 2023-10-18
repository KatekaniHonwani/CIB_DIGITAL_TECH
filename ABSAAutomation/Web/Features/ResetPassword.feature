Feature: Request to Reset password
	Ability for a user of the clinical system to request to reset their password

	Background: Login Clinical
	Given a user navigate to the Healthone Webpage
	

@Reset_Password
Scenario Outline: Reset Password
	When a user clicks reset password
	And a user enters email "<ScenarioNumber>" using worksheet "1VvSZCLWhPvdsdsvByiMWZL9kNGOqfTvafX_QrKymwGg" sheet "patient"
	And a user send the link
	Then password is reseted


Examples: 
 | ScenarioNumber | 

  |1				|


