Feature: Member

A short summary of the feature
Background: 
	Given that the required headers are loaded from "TestData\\API\\LibertyConfig.json" 
    And the certificate is loaded from "Cert\\Mulesoft_Non_Prod.pfx"
    And the certificate has a valid password "12345"

@Regression
Scenario: [Verify GET Member Details API service]
    When the user makes a GET request to Member Service "<Uri>" with valid "<MemberId>" as parameter
    Then the user is presented with Member information and a success status code

 Examples: 
| Service | Uri           | MemberId |
| Schemes | /api/Members/ | 273366   |
| Schemes | /api/Members/ | 6584719  |
| Schemes | /api/Members/ | 4506000  |
| Schemes | /api/Members/ | 7387681  |
| Schemes | /api/Members/ | 7268803  |

@NegativeTest
Scenario: [Verify Error Message displayed when incorrect Member_ID is captured API service]
    When the user makes a GET request to "<Uri>" with invalid "<MemberID>"
    Then the user is presented with a not found error message

Examples: 
| Service | Uri           | MemberID |
| Schemes | /api/Members/ | 12       |