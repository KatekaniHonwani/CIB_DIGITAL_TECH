Feature: Test an API

 
 
Scenario Outline: Get some information API
    Given that the required headers are loaded from "TestData\\API\\LibertyConfig.json" 
    And the certificate is loaded from "Cert\\Mulesoft_Non_Prod.pfx"
    And the certificate has a valid password "12345"
    When the user makes a GET request to "<Uri>"
    Then the user is presented with data in the body of the response and a success status code

Examples: 
| Service                   | Uri                                                                                                               |
| Schemes                   | /api/Schemes/42                                 |
| Members                   | /api/Members/273366                                |  
| Members Investment Values | /api/Members/6584719/InvestmentValues              |
| Member Billing            | /api/Members/6584719/Billing?applyGrouping=false   |
| Organizations             | /api/Organizations?taxNo=4380223851                |
| Persons PersonsID         | /api/Persons/273366                                 |
| Persons PersonsID Profiles| /api/Persons/4182867/Profiles                      |
| Persons                   | /api/Persons?emailAddress=test@ymail.com           |