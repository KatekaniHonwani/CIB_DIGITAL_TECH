using LibertyAutomation.Utilities;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;
using static MongoDB.Bson.Serialization.Serializers.SerializerHelper;

namespace LibertyAutomation.API.StepDefinitions
{
    [Binding]
    public class OrganizationsStepDefinitions
    {
        ISpecFlowOutputHelper specflowOutputHelper;
        APIHelper apiHelper;
        ScenarioContext scenarioContext;

        String[] response;
        public OrganizationsStepDefinitions(ISpecFlowOutputHelper specflowOutputHelper, ScenarioContext scenarioContext)
        {
            this.specflowOutputHelper = specflowOutputHelper;
            apiHelper = new APIHelper();

            this.scenarioContext = scenarioContext;
        }
        [When(@"the user makes a GET request to Organization Service ""([^""]*)"" with valid ""([^""]*)"" as parameter")]
        public void WhenTheUserMakesAGETRequestToOrganizationServiceWithValidAsParameter(string uri, string taxNo)
        {
            response = apiHelper.getRestRequest(uri + taxNo, scenarioContext["certificate"].ToString(), scenarioContext["password"].ToString(), scenarioContext["path"].ToString());
        }
        [Then(@"the user is presented with Organization information and a success status code")]
        public void ThenTheUserIsPresentedWithOrganizationInformationAndASuccessStatusCode()
        {
            specflowOutputHelper.WriteLine(response[0]);
            Assert.AreEqual("OK", response[1]);
        }

        [When(@"the user makes a GET request to Organization Service ""([^""]*)"" with invalid ""([^""]*)"" as parameter")]
        public void WhenTheUserMakesAGETRequestToOrganizationServiceWithInvalidAsParameter(string uri, string invalidTaxNO)
        {
            response = apiHelper.getRestRequest(uri + invalidTaxNO, scenarioContext["certificate"].ToString(), scenarioContext["password"].ToString(), scenarioContext["path"].ToString());
        }
        [Then(@"the user is presented with a failed not found error message")]
        public void ThenTheUserIsPresentedWithAFailedNotFoundErrorMessage()
        {
            specflowOutputHelper.WriteLine(response[0]);
            Assert.AreEqual("NotFound", response[1]);
        }

    }
}
