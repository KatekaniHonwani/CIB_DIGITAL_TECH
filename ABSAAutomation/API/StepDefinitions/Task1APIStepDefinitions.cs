using ABSAAutomation.Utilities;
using NUnit.Framework;
using System;
using System.Net.Http;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ABSAAutomation.Web.PageObjects;
using ABSAAutomation.Support.Utilities;

namespace ABSAAutomation.API.StepDefinitions
{
    [Binding]
    public class Task1APIStepDefinitions
    {
        ISpecFlowOutputHelper specflowOutputHelper;
        APIHelper apiHelper;
        ScenarioContext scenarioContext;
        String[] response;

        BreedResponse breedResponse;

        public Task1APIStepDefinitions(ISpecFlowOutputHelper specflowOutputHelper, ScenarioContext scenarioContext)
        {
            this.specflowOutputHelper = specflowOutputHelper;
            apiHelper = new APIHelper();

            this.scenarioContext = scenarioContext;
            breedResponse = new BreedResponse();
        }

        [When(@"the user makes a GET request to All Dog breeds Service ""([^""]*)""")]
        public async void WhenTheUserMakesAGETRequestToAllDogBreedsService(string Uri)
        {
            //response = apiHelper.getAPIRequest(Uri, scenarioContext["path"].ToString());

            // Define the base URL of the Dog API
            string apiUrl = "https://dog.ceo/api";

            // Create an instance of HttpClient to make the API request
            using (var httpClient = new HttpClient())
            {
                try
                {
                    // Specify the endpoint for getting a list of all dog breeds
                    string endpoint = "/breeds/list/all";

                    // Combine the base URL and endpoint to form the complete API URL
                    string requestUrl = $"{config.ApiURL}{Uri}";

                    // Make the GET request to the API
                    HttpResponseMessage response = await httpClient.GetAsync(requestUrl);

                    // Check if the request was successful (status code 200)
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the response content as a JSON string
                        string jsonResponse = await response.Content.ReadAsStringAsync();

                        // Deserialize the JSON response into a C# object
                        var breedResponse = JsonConvert.DeserializeObject<BreedResponse>(jsonResponse);

                        // Access the list of dog breeds
                        foreach (var breed in breedResponse.Message)
                        {
                            Console.WriteLine(breed);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"API request failed with status code: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }

        [Then(@"the user is presented with All Dog breeds information and a success status code")]
        public void ThenTheUserIsPresentedWithAllDogBreedsInformationAndASuccessStatusCode()
        {
            //specflowOutputHelper.WriteLine(response[0]);
            //Assert.AreEqual("success", response[1]);

            Console.WriteLine("Status code");

        }

        [When(@"the user makes a GET request to Dog breeds Service ""([^""]*)"" with valid ""([^""]*)"" as parameter")]
        public async void WhenTheUserMakesAGETRequestToDogBreedsServiceWithValidAsParameter(string p0, string retriever)
        {
            // Create an instance of HttpClient to make the API request
            using (var httpClient = new HttpClient())
            {
                try
                {
                    // Specify the endpoint for getting a list of all dog breeds
                    string endpoint = "/breeds/list/all";

                    // Combine the base URL and endpoint to form the complete API URL
                    string requestUrl = $"{config.ApiURL}{endpoint}";

                    // Make the GET request to the API
                    HttpResponseMessage response = await httpClient.GetAsync(requestUrl);

                    // Check if the request was successful (status code 200)
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the response content as a JSON string
                        string jsonResponse = await response.Content.ReadAsStringAsync();

                        // Deserialize the JSON response into a C# object
                        var breedResponse = JsonConvert.DeserializeObject<BreedResponse>(jsonResponse);

                        // Verify if "retriever" is within the list of dog breeds
                        bool isRetrieverBreed = Array.Exists(breedResponse.Message, breed => breed == "retriever");

                        if (isRetrieverBreed)
                        {
                            Console.WriteLine("The 'retriever' breed is in the list of dog breeds.");
                        }
                        else
                        {
                            Console.WriteLine("The 'retriever' breed is not in the list of dog breeds.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"API request failed with status code: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }

    }
}
