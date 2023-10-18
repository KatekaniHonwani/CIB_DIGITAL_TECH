Feature: Member Complaint Contact US

A short summary of the feature


Scenario Outline: Member Complaint Contact us SSP

	Given a member is on the login page
	When a member logs in to SSP using "<loginEmailAddress>"
	And Navigate to Complaints.
	Then member should be landed on the Contact Us tab by default 
	When a member click the Complain Online tab, they should be directed to the complaints page
	And when the member populate invalid contact details to verify error alerts 
	 
		| complaintEmailAddress             | complaintCellNumber | memberComplaint |
		| katekani.honwani@liberty.			| 63588356			  |					|

	And then click the continue button with valid details to submit complaint
		| complaintEmailAddress             | complaintCellNumber | memberComplaint |
		| testingliberty200@outlook.com		| 635883568			  |  I look forward to your reply and a resolution to my problem. I will wait until before seeking help from other assistance.        |
	
	Then member should be able to Review complaint information and submit complaint
	
Examples: 
|loginEmailAddress |
|member10@test.com |

