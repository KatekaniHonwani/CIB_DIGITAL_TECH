using LibertyAutomation.LibertyAutomation.PageObjects;
using LibertyAutomation.Web.PageObjects;
using TechTalk.SpecFlow;
using System;
using TechTalk.SpecFlow.Assist;
using LibertyAutomation.Support.Utilities;
using System.Collections.Generic;
using System.Data;

namespace LibertyAutomation.Web.StepDefinitions
{
    [Binding]
    public class ViewDigitalVASCardStepDefinitions
    {

        private readonly LogIn login;
        private readonly Dashboard dashboard;
        private readonly ValueAddedServices vas;

        public ViewDigitalVASCardStepDefinitions(ScenarioContext scenarioContext)
        {
            login = new LogIn();
            dashboard = new Dashboard();
            vas = new ValueAddedServices();
        }

        [Given(@"a member is on the SSP login page")]
        public void GivenAMemberIsOnTheSSPLoginPage()
        {

            login.NavigateToSspWebsite(config.SspUrl);

        }

        [When(@"a member logs in to SSP using ""([^""]*)""")]
        public void WhenAMemberLogsInToSSPUsing(string loginEmail)
        {

            login.LoginToSsp(loginEmail);

            login.VerifySuccessfulLogin();

        }

        [When(@"Navigates to Value Added Services")]
        public void WhenNavigatesToValueAddedServices()
        {

            dashboard.CheckProgressBarIsDoneAndNavigateTo("Value-added services");

        }

        [Then(@"the member is presented with a list of all the services available to them depending on whether they ""([^""]*)"" or not")]
        public void ThenTheMemberIsPresentedWithAListOfAllTheServicesAvailableToThem(string hasFuneralBenefits, Table table)
        {

            bool memberHasFuneralBenefits = Convert.ToBoolean(hasFuneralBenefits);

            Dictionary<string, string> vasesHeadingsAndDescriptions = DataTableHelper.DataTableToDictionary(table);

            vas.VerifyCorrectVasesDisplayed(memberHasFuneralBenefits, vasesHeadingsAndDescriptions);

        }

        [Then(@"contact details are displayed")]
        public void ThenContactDetailsAreDisplayed(Table table)
        {

            Dictionary<string, string> contactDetails = DataTableHelper.DataTableToDictionary(table);

            vas.VerifyContactDetailsAreCorrect(contactDetails);

        }

        [Then(@"a member can download the contact details")]
        public void ThenAMemberCanDownloadTheContactDetails()
        {

            vas.VerifyContactDownload();
            
        }

        [When(@"a member clicks on the digital messaging platform link")]
        [Then(@"They are redirected to the access vas page on a new tab\.")]
        public void WhenAMemberClicksOnTheDigitalMessagingPlatformLink()
        {
            vas.VerifyUserIsRedirectedToNewTab();
        }

    }

}
