using ABSAAutomation.Support.Utilities;
using ABSAAutomation.Web.PageObjects;
using FluentAssertions;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ABSAAutomation.Web.StepDefinitions
{
    [Binding]
    public class CIBDIGITALTECH_Task2WebStepDefinitions
    {
        Task2Web task2Web;
        private readonly UserInformation userInformation;
        ScenarioContext scenarionContext;
        FeatureContext featureContext;

        bool tableDisplayed = true;

        public CIBDIGITALTECH_Task2WebStepDefinitions(ScenarioContext scenarionContext, FeatureContext featureContext)
        {
            task2Web = new Task2Web();
            this.scenarionContext = scenarionContext;
            this.featureContext = featureContext;
        }

        [Given(@"user has ""([^""]*)"" to Way(.*)Automation application")]
        public void GivenUserHasToWayAutomationApplication(string url, int p1)
        {
            scenarionContext["url"] = url;

        }

        [When(@"User navigate to the application")]
        public void WhenUserNavigateToTheApplication()
        {
            task2Web.NavigateToWay2automation(scenarionContext["url"].ToString());
        }

        [Then(@"user is presented with list of users in the table")]
        public void ThenUserIsPresentedWithListOfUsersInTheTable()
        {
           
            task2Web.VerifyTableWithIsAvailable();
            tableDisplayed = true;

            featureContext["tDisplay"] = tableDisplayed;
        }

        [Given(@"User navigate to the application")]
        public void GivenUserNavigateToTheApplication()
        {
            
        }


        [When(@"the user adds a new user")]
        public void WhenTheUserAddsANewUser(Table table)
        {
            task2Web.AddUserButtonClick();
            var userDetails = table.CreateSet<UserInformation>().ToList();

            foreach (var allUserDetails in userDetails)
            {

                task2Web.AddNewUser(allUserDetails);
                task2Web.AddUserButtonClick();

            }

            task2Web.CloseDialog();
        }

        [Then(@"User is displayed on the user table")]
        public void ThenUserIsDisplayedOnTheUserTable()
        {
            task2Web.VerifyTableWithIsAvailable();
            tableDisplayed = true;

            featureContext["tDisplay"] = tableDisplayed;
        }
    }
}
