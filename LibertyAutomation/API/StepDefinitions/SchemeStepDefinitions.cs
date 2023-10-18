using LibertyAutomation.Utilities;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace LibertyAutomation.API.StepDefinitions
{
    [Binding]
    public class SchemeStepDefinitions
    {
        ISpecFlowOutputHelper specflowOutputHelper;
        APIHelper apiHelper;
        ScenarioContext scenarioContext;

        String[] response;
        public SchemeStepDefinitions(ISpecFlowOutputHelper specflowOutputHelper, ScenarioContext scenarioContext)
        {
            this.specflowOutputHelper = specflowOutputHelper;
            apiHelper = new APIHelper();

            this.scenarioContext = scenarioContext;
        }
        [When(@"the user makes a GET request to Scheme service ""([^""]*)"" with valid ""([^""]*)"" as parameter")]
        public void WhenTheUserMakesAGETRequestToSchemeServiceWithValidAsParameter(string uri, string schemeId)
        {
            response = apiHelper.getRestRequest(uri + schemeId, scenarioContext["certificate"].ToString(), scenarioContext["password"].ToString(), scenarioContext["path"].ToString());
        }

        [Then(@"the user is presented with scheme information and a success status code")]
        public void ThenTheUserIsPresentedWithSchemeInformationAndASuccessStatusCode()
        {
            specflowOutputHelper.WriteLine(response[0]);
            Assert.AreEqual("OK", response[1]);
        }
        [When(@"the user makes a GET request to ""([^""]*)"" with invalid ""([^""]*)""")]
        public void WhenTheUserMakesAGETRequestToWithInvalid(string uri, string invalidSchemeNO)
        {
            response = apiHelper.getRestRequest(uri + invalidSchemeNO, scenarioContext["certificate"].ToString(), scenarioContext["password"].ToString(), scenarioContext["path"].ToString());
        }

        [Then(@"the user is presented with a not found error message")]
        public void ThenTheUserIsPresentedWithANotFoundErrorMessage()
        {
            specflowOutputHelper.WriteLine(response[0]);
            Assert.AreEqual("NotFound", response[1]);
        }

    }
}
