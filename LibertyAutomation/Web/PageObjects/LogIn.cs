using System;
using AventStack.ExtentReports;
using LibertyAutomation.Hooks;
using LibertyAutomation.Utilities;
using LibertyAutomation.Web.ObjectRepo;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace LibertyAutomation.LibertyAutomation.PageObjects
{
     class LogIn : ActionHelper
    {
         IWebDriver driver;
         LogInRepo logInRepo;

        public LogIn()
        {
            logInRepo = new LogInRepo();
            driver = liberty.driver;
            PageFactory.InitElements(driver,logInRepo);

        }

        public void LoginToSsp(string email)
        {
            EnterValue(logInRepo.txtEmail, driver, email);
            ClickObject(logInRepo.btnContinue, driver);
            
        }
        public void NavigateToSspWebsite(string sUrl)
        {
            driver.Navigate().GoToUrl(sUrl);

            VerifySspLoginPageIsDisplyed();

        }

        public void VerifySspLoginPageIsDisplyed()
        {

            bool sspLaunched = WaitForElementToBeDisplayed(logInRepo.txtLogInPageWelcomeMessage, driver, 10);

            if (!sspLaunched)
            {
                Assert.Fail("Ssp login page is not displayed.");
            }

        }

        public void VerifySuccessfulLogin()
        {


            bool isDisplayed = WaitForElementToBeDisplayed(logInRepo.txtDashboardWelcomeMessage, driver, 20);

            if (!isDisplayed)
            {
                Assert.Fail("Login failed");
            }

        }
        
        
    } 
    
}
