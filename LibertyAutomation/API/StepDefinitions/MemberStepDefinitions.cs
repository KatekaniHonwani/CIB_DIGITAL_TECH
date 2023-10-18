using LibertyAutomation.Utilities;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace LibertyAutomation.API.StepDefinitions
{
    [Binding]
    public class MemberStepDefinitions
    {
        ISpecFlowOutputHelper specflowOutputHelper;
        APIHelper apiHelper;
        ScenarioContext scenarioContext;

        String[] response;
        public MemberStepDefinitions(ISpecFlowOutputHelper specflowOutputHelper, ScenarioContext scenarioContext)
        {
            this.specflowOutputHelper = specflowOutputHelper;
            apiHelper = new APIHelper();

            this.scenarioContext = scenarioContext;
        }
        [When(@"the user makes a GET request to Member Service ""([^""]*)"" with valid ""([^""]*)"" as parameter")]
        public void WhenTheUserMakesAGETRequestToMemberServiceWithValidAsParameter(string uri, string memberID)
        {
            response = apiHelper.getRestRequest(uri + memberID, scenarioContext["certificate"].ToString(), scenarioContext["password"].ToString(), scenarioContext["path"].ToString());
        }

        [Then(@"the user is presented with Member information and a success status code")]
        public void ThenTheUserIsPresentedWithMemberInformationAndASuccessStatusCode()
        {
            specflowOutputHelper.WriteLine(response[0]);
            Assert.AreEqual("OK", response[1]);
        }
    }
}
