Feature: Task1API

A short summary of the feature

@mytag
Scenario: [Perform an API request to produce a list of all dog breeds]
          When the user makes a GET request to All Dog breeds Service "<Uri>"
          Then the user is presented with All Dog breeds information and a success status code
    

 Examples: 
| Uri                   |
| /breeds/list/all      |

Scenario: [Using code, verify if specific breed is within the list]
    When the user makes a GET request to Dog breeds Service "<Uri>" with valid "retriever" as parameter
    Then the user is presented with Person information and a success status code

 Examples: 
| Uri                        |
| /breeds/list/all              |


