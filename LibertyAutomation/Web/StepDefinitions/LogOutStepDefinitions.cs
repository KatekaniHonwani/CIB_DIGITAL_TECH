using System;
using System.Threading;
using LibertyAutomation.LibertyAutomation.PageObjects;
using LibertyAutomation.Web.PageObjects;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace LibertyAutomation.Web.StepDefinitions
{
    [Binding]
    public class LogOutStepDefinitions
    {
         readonly Dashboard dashboard;
         private readonly LogoutDialogBoxPopUp logoutDialogBoxPopUp;
         private readonly LogIn logIn;

         public LogOutStepDefinitions()
         {
             dashboard = new Dashboard();
             logoutDialogBoxPopUp = new LogoutDialogBoxPopUp();
             logIn = new LogIn();
         }
        [When(@"user clicks logout button")]
        public void WhenUserClicksLogoutButton()
        { 
          dashboard.CheckProgressBarIsDoneAndNavigateTo("Logout");
         // dashboard.NavigateTo("Logout"); 
        }

        [Then(@"dialog box must pop up")]
        public void ThenDialogBoxMustPopUp()
        {
            logoutDialogBoxPopUp.VerifyLogOutPopUpIsDisplayed();
        }

        [When(@"user clicks cancel button")]
        public void WhenUserClicksCancelButton()
        {
           
            logoutDialogBoxPopUp.ClickLogoutPopUpButton("Cancel");
            
        }

        [Then(@"the dialog box closes")]
        public void ThenTheDialogBoxCloses()
        {
            logoutDialogBoxPopUp.VerifyLogOutPopUpIsNotVisible();
        }

        [Then(@"user is still logged in")]
        public void ThenUserIsStillLoggedIn()
        {
            logIn.VerifySuccessfulLogin();
        }

        [When(@"user clicks yes button in logout pop up screen")]
        public void WhenUserClicksYesButtonInLogoutPopUpScreen()
        {
           dashboard.NavigateTo("Logout"); 
           logoutDialogBoxPopUp.ClickLogoutPopUpButton("Yes");
           
        }

        [Then(@"user is logged out and lands on log in page")]
        public void ThenUserIsLoggedOutAndLandsOnLogInPage()
        {
            logIn.VerifySspLoginPageIsDisplyed();
        }
    }
}