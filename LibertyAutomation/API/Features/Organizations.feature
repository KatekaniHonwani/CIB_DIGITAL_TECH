Feature: Organizations

A short summary of the feature
Background: 
	Given that the required headers are loaded from "TestData\\API\\LibertyConfig.json" 
    And the certificate is loaded from "Cert\\Mulesoft_Non_Prod.pfx"
    And the certificate has a valid password "12345"

@ApiRegression
Scenario: [Verify GET organisation API service]
    When the user makes a GET request to Organization Service "<Uri>" with valid "<taxNo>" as parameter
    Then the user is presented with Organization information and a success status code

 Examples: 
| Service       | Uri                       | taxNo      |
| Organizations | /api/Organizations?taxNo= | 4380223851 |
| Organizations | /api/Organizations?taxNo= | 125 |

@NegativeTest
Scenario: Verify Error Message displayed when incorrect tax number is captured on Organization API service
    When the user makes a GET request to Organization Service "<Uri>" with invalid "<taxNo>" as parameter
    Then the user is presented with a failed not found error message

 Examples: 
| Service       | Uri                       | taxNo      |
| Organizations | /api/Organizations?taxNo= | 677777777 |
| Organizations | /api/Organizations?taxNo= | 677777778 |

@NegativeTest
Scenario: Verifiy Error Message displayed when an incorrect organisation name is captured on Organization API service
    When the user makes a GET request to Organization Service "<Uri>" with invalid "<InvalidOrganizationName>" as parameter
    Then the user is presented with a failed not found error message

 Examples: 
| Service       | Uri                                  | InvalidOrganizationName |
| Organizations | /api/Organizations?organizationName= | testcom                 |
| Organizations | /api/Organizations?organizationName= | testcom 2               |
