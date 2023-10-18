using ABSAAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Infrastructure;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace ABSAAutomation.API.StepDefinitions
{
    internal class TaskAPIStepDefination
    {

        ISpecFlowOutputHelper specflowOutputHelper;
        APIHelper apiHelper;
        ScenarioContext scenarioContext;
        String[] response;

        public TaskAPIStepDefination(ISpecFlowOutputHelper specflowOutputHelper, ScenarioContext scenarioContext)
        {
            this.specflowOutputHelper = specflowOutputHelper;
            apiHelper = new APIHelper();

            this.scenarioContext = scenarioContext;
        }

        [When(@"the user makes a GET request to All Dog breeds Service ""([^""]*)""")]
        public void WhenTheUserMakesAGETRequestToAllDogBreedsService(string uri)
        {
            response = apiHelper.getAPIRequest(uri, scenarioContext["path"].ToString());
        }

        [Then(@"the user is presented with All Dog breeds information and a success status code")]
        public void ThenTheUserIsPresentedWithAllDogBreedsInformationAndASuccessStatusCode()
        {
            specflowOutputHelper.WriteLine(response[0]);
            Assert.AreEqual("success", response[1]);
        }


       
    }
}
