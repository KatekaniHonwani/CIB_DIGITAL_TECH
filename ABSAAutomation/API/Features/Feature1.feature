Feature: Feature1

A short summary of the feature

Scenario: Get a list of all dog breeds
    When the user performs an API request to produce a list of all dog breeds
    Then the API response should contain a list of dog breeds

Scenario: Verify "retriever" breed is within the list
    When the user performs an API request to produce a list of all dog breeds
    Then the API response should contain the "retriever" breed

Scenario: Get a list of sub-breeds for "retriever"
    When the user performs an API request to produce a list of sub-breeds for "retriever"
    Then the API response should contain sub-breeds

Scenario: Get a random image/link for the sub-breed "golden"
    When the user performs an API request to produce a random image/link for the sub-breed "golden"
    Then the API response should contain an image/link for the "golden" sub-breed

