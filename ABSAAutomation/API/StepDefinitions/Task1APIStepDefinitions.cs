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
using Microsoft.AspNetCore.Http.Extensions;

namespace ABSAAutomation.API.StepDefinitions
{
    [Binding]
    public class Task1APIStepDefinitions
    {
        ISpecFlowOutputHelper specflowOutputHelper;
        APIHelper apiHelper;
        ScenarioContext scenarioContext;
        String[] response;

        private HttpClient client;
        private string apiBaseUrl = "https://dog.ceo/api";

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

            String[] response = apiHelper.getRestRequest(Uri, "");

            scenarioContext["content"] = response[0];
            scenarioContext["status"] = response[1];

            
        }

        [Then(@"the user is presented with All information")]
        public void ThenTheUserIsPresentedWithAllInformation()
        {
            specflowOutputHelper.WriteLine(scenarioContext["content"].ToString());
            specflowOutputHelper.WriteLine(scenarioContext["status"].ToString());


        }

        [When(@"the user makes a GET request to dog breeds with ""([^""]*)"" as parameter")]
        public void WhenTheUserMakesAGETRequestToDogBreedsWithAsParameter(string breedName)
        {
            String[] response = apiHelper.getRestRequest(config.ApiURL, "");

            scenarioContext["content"] = response[0].Contains(breedName);
            scenarioContext["status"] = response[1];
        }

        [Then(@"the user is presented with breed information and a success status code")]
        public void ThenTheUserIsPresentedWithBreedInformationAndASuccessStatusCode()
        {
            specflowOutputHelper.WriteLine(scenarioContext["content"].ToString());
            specflowOutputHelper.WriteLine(scenarioContext["status"].ToString());
        }

        [When(@"the user makes a GET request to get list of sub-breeds with ""([^""]*)"" as parameter")]
        public async void WhenTheUserMakesAGETRequestToGetListOfSub_BreedsWithAsParameter(string retriever)
        {
            
            HttpResponseMessage response = await client.GetAsync(config.ApiURL);
            ScenarioContext.Current["ApiResponse"] = response;
        }

        [Then(@"the user is presented with list of sub breeds information and a success status code")]
        public void ThenTheUserIsPresentedWithListOfSubBreedsInformationAndASuccessStatusCode()
        {
            specflowOutputHelper.WriteLine(scenarioContext["ApiResponse"].ToString());
        }

        [When(@"the user makes a GET request to get random image with ""([^""]*)"" as parameter")]
        public void WhenTheUserMakesAGETRequestToGetRandomImageWithAsParameter(string golden)
        {
            //To be completed
        }

        [Then(@"the user is presented with image and a success status code")]
        public void ThenTheUserIsPresentedWithImageAndASuccessStatusCode()
        {
            //To be completed
        }



    }
}
