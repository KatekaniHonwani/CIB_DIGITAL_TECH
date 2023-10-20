Feature: Task1API

A short summary of the feature

@mytag
Scenario: [Perform an API request to produce a list of all dog breeds]
          When the user makes a GET request to All Dog breeds Service "<Uri>"
          Then the user is presented with All information
          

 Examples: 
| Uri                                 |
| https://dog.ceo/api/breeds/list/all |

Scenario: [Verify specific breed is within the list]
    When the user makes a GET request to dog breeds with "<breedName>" as parameter
    Then the user is presented with breed information and a success status code

 Examples: 
| breedName     | 
| retriever     | 

Scenario: [Perform an API request to produce a list of sub-breeds]
    When the user makes a GET request to get list of sub-breeds with "<breedName>" as parameter
    Then the user is presented with list of sub breeds information and a success status code

 Examples: 
| breedName     | 
| retriever     |

Scenario: [Perform an API request to produce a random image / link for the sub-breed]
    When the user makes a GET request to get random image with "<subBreedName>" as parameter
    Then the user is presented with image and a success status code

 Examples: 
| subBreedName     | 
| golden     |









