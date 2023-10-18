using LibertyAutomation.Utilities;
using Microsoft.Graph;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace LibertyAutomation.API.StepDefinitions
{
    [Binding]
    public class PersonsStepDefinitions
    {

        ISpecFlowOutputHelper specflowOutputHelper;
        APIHelper apiHelper;
        ScenarioContext scenarioContext;

        String[] response;
        public PersonsStepDefinitions(ISpecFlowOutputHelper specflowOutputHelper, ScenarioContext scenarioContext)
        {
            this.specflowOutputHelper = specflowOutputHelper;
            apiHelper = new APIHelper();

            this.scenarioContext = scenarioContext;
        }
        [When(@"the user makes a GET request to Persons_ID Service ""([^""]*)"" with valid ""([^""]*)"" as parameter")]
        public void WhenTheUserMakesAGETRequestToPersons_IDServiceWithValidAsParameter(string uri, string personId)
        {
            response = apiHelper.getRestRequest(uri + personId, scenarioContext["certificate"].ToString(), scenarioContext["password"].ToString(), scenarioContext["path"].ToString());
        }

        [Then(@"the user is presented with Persons_ID information and a success status code")]
        public void ThenTheUserIsPresentedWithPersons_IDInformationAndASuccessStatusCode()
        {
            specflowOutputHelper.WriteLine(response[0]);
            Assert.AreEqual("OK", response[1]);
        }
        [Then(@"the user is presented with Person information and a success status code")]
        public void ThenTheUserIsPresentedWithPersonInformationAndASuccessStatusCode()
        {
            specflowOutputHelper.WriteLine(response[0]);
            Assert.AreEqual("OK", response[1]);
        }
        [When(@"the user makes a GET request to Persons_ID Service ""([^""]*)"" with invalid ""([^""]*)"" as parameter")]
        public void WhenTheUserMakesAGETRequestToPersons_IDServiceWithInvalidAsParameter(string uri, string invalidID)
        {
            response = apiHelper.getRestRequest(uri + invalidID, scenarioContext["certificate"].ToString(), scenarioContext["password"].ToString(), scenarioContext["path"].ToString());
        }

        [When(@"the user makes a GET request to Persons Service ""([^""]*)"" with invalid ""([^""]*)"" as parameter")]
        public void WhenTheUserMakesAGETRequestToPersonsServiceWithInvalidAsParameter(string uri, string invalidEmail)
        {
            response = apiHelper.getRestRequest(uri + invalidEmail, scenarioContext["certificate"].ToString(), scenarioContext["password"].ToString(), scenarioContext["path"].ToString());
        }
        [When(@"the user makes a GET request to Persons_ID Service Profiles ""([^""]*)"" with valid ""([^""]*)"" as parameter")]
        public void WhenTheUserMakesAGETRequestToPersons_IDServiceProfilesWithValidAsParameter(string uri, string personID)
        {
            string fullUri = uri.Insert(12, personID);
            response = apiHelper.getRestRequest(fullUri, scenarioContext["certificate"].ToString(), scenarioContext["password"].ToString(), scenarioContext["path"].ToString());
        }

        [Then(@"the user is presented with a person not found error message")]
        public void ThenTheUserIsPresentedWithAPersonNotFoundErrorMessage()
        {
            specflowOutputHelper.WriteLine(response[0]);
            Assert.AreEqual("NotFound", response[1]);
        }
        [When(@"the user makes a GET request to Persons Service Name ""([^""]*)"" with invalid ""([^""]*)"" as parameter")]
        public void WhenTheUserMakesAGETRequestToPersonsServiceNameWithInvalidAsParameter(string uri, string invalidName)
        {
            response = apiHelper.getRestRequest(uri + invalidName, scenarioContext["certificate"].ToString(), scenarioContext["password"].ToString(), scenarioContext["path"].ToString());
        }
    }
}
