using ABSAAutomation.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace ABSAAutomation
{
    [Binding]
    public class TestAnAPIStepDefinitions
    {
        ISpecFlowOutputHelper specflowOutputHelper;
        APIHelper apiHelper;
        ScenarioContext scenarioContext ;

        String[] response;

        public TestAnAPIStepDefinitions(ISpecFlowOutputHelper specflowOutputHelper, ScenarioContext scenarioContext)
        {
            this.specflowOutputHelper = specflowOutputHelper;
            apiHelper = new APIHelper();

            this.scenarioContext = scenarioContext;
        }

        [Given(@"that the required headers are loaded from ""([^""]*)""") ]
        [Given(@"the certificate is loaded from ""([^""]*)""")]
        [Given(@"the certificate has a valid password ""([^""]*)""")]
        public void GivenThatTheRequiredHeadersAreLoadedFrom(string conditionOption)
        {
            if(scenarioContext.StepContext.StepInfo.Text.Contains("required headers"))
            {
                scenarioContext["path"] = conditionOption;
            }
            else if(scenarioContext.StepContext.StepInfo.Text.Contains("certificate is loaded"))
            {
                scenarioContext["certificate"] = conditionOption;
            }
            else if(scenarioContext.StepContext.StepInfo.Text.Contains("valid password"))
            {
                scenarioContext["password"] = conditionOption;
            }
        }

        [When(@"the user makes a GET request to ""([^""]*)""")]
        public async Task WhenTheUserMakesAGETRequestTo(string uri)
        {
            response = apiHelper.getRestRequest(uri, scenarioContext["certificate"].ToString(), scenarioContext["password"].ToString(), scenarioContext["path"].ToString());
        }

        private readonly SpecFlowOutputHelper specFlowOutputHelper;

        [Then(@"the user is presented with data in the body of the response and a success status code")]
        public void ThenTheUserIsPresentedWithDataInTheBodyOfTheResponseAndASuccessStatusCode()
        {
            specflowOutputHelper.WriteLine(response[0]);
            Assert.AreEqual("OK", response[1]);
        }
    }
}
