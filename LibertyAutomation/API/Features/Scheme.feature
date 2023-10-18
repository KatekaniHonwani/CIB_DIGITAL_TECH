Feature: Scheme

Scheme Feature

Background: 
    Given that the required headers are loaded from "TestData\\API\\LibertyConfig.json" 
    And the certificate is loaded from "Cert\\Mulesoft_Non_Prod.pfx"
    And the certificate has a valid password "12345"

@Regression
Scenario: [Verify GET Scheme Details API service]
    When the user makes a GET request to Scheme service "<Uri>" with valid "<SchemeId>" as parameter
    Then the user is presented with scheme information and a success status code

 Examples: 
| Service | Uri           | SchemeId |
| Schemes | /api/Schemes/ | 42       |
| Schemes | /api/Schemes/ | 61       |
| Schemes | /api/Schemes/ | 181      |
| Schemes | /api/Schemes/ | 261      |
| Schemes | /api/Schemes/ | 281      |

@NegativeTest
Scenario: [Verify Error Message displayed when incorrect Scheme_ID is captured API service]
    When the user makes a GET request to "<Uri>" with invalid "<SchemeID>"
    Then the user is presented with a not found error message

Examples: 
| Service | Uri           | SchemeID |
| Schemes | /api/Schemes/ | 33       |