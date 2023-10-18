Feature: Persons

A short summary of the feature

Background: 
	Given that the required headers are loaded from "TestData\\API\\LibertyConfig.json" 
    And the certificate is loaded from "Cert\\Mulesoft_Non_Prod.pfx"
    And the certificate has a valid password "12345"

Scenario: [Verify GET Persons_ID API service]
    When the user makes a GET request to Persons_ID Service "<Uri>" with valid "<PersonId>" as parameter
    Then the user is presented with Persons_ID information and a success status code

 Examples: 
| Service           | Uri                       | PersonId  |
| Persons PersonsID | /api/Persons/             | 273366 |
| Persons PersonsID | /api/Persons/             | 11542 |

Scenario: [Verify GET Person contact API service]
    When the user makes a GET request to Persons_ID Service "<Uri>" with valid "<emailAddress>" as parameter
    Then the user is presented with Person information and a success status code

 Examples: 
| Service | Uri                        | emailAddress       |
| Persons | /api/Persons?emailAddress= | PAYROLL@HOLLYWOODBETS.NET |

@Negetive
Scenario: Verify Error message displayed when incorrect Person ID is captured on Persons_ID API service 
    When the user makes a GET request to Persons_ID Service "<Uri>" with invalid "<invalidPersonID>" as parameter
    Then the user is presented with a person not found error message

 Examples: 
| Service           | Uri           | invalidPersonID |
| Persons PersonsID | /api/Persons/ | 4        |


@Negetive
Scenario: Verify Error message displayed when incorrect Email address is captured on Persons API service 
    When the user makes a GET request to Persons Service "<Uri>" with invalid "<emailAddress>" as parameter
    Then the user is presented with a person not found error message

 Examples: 
| Service       | Uri                       | emailAddress      |
| Organizations | /api/Persons?emailAddress=| ts@ymail.com |

@Negetive
Scenario: Verify Error message displayed when incorrect First Name is captured on Persons API service 
    When the user makes a GET request to Persons Service Name "<Uri>" with invalid "<invalidName>" as parameter
    Then the user is presented with a person not found error message

 Examples: 
| Service       | Uri                     | invalidName |
| Organizations | /api/Persons?firstName= | 1nameTest   |


Scenario: [Verify GET persons profile API service]
    When the user makes a GET request to Persons_ID Service Profiles "<Uri>" with valid "<PersonId>" as parameter
    Then the user is presented with Persons_ID information and a success status code

 Examples: 
| Service                    | Uri                   | PersonId |
| Persons PersonsID Profiles | api/Persons//Profiles | 4182867  |