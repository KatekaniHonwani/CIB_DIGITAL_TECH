using System.Threading;
using LibertyAutomation.LibertyAutomation.PageObjects;
using LibertyAutomation.Web.ObjectRepo;
using TechTalk.SpecFlow;

namespace LibertyAutomation.Web.StepDefinitions
{
    [Binding]
    public class LogInStepDefinitions
    {
         readonly LogIn loggingIn;

         public LogInStepDefinitions()
         {
             loggingIn = new LogIn();
         }

         [Given(@"user logs in")]
         [When(@"user logs in")]
        public void GivenUserLogsIn()
        {
            loggingIn.VerifySspLoginPageIsDisplyed();
            loggingIn.LoginToSsp(config.SspEmail);
        }

        [Given(@"the user is on the login page")]
        [When(@"the user is on the login page")]
        public void GivenTheUserIsOnTheLoginPage()
        {
            loggingIn.NavigateToSspWebsite(config.SspUrl);
        }

        [Then(@"the SSP dashboard is displayed")]
        public void ThenTheSspDashboardIsDisplayed()
        {
            loggingIn.VerifySuccessfulLogin();
        }
    }
}