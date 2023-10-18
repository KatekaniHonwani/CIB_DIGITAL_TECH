﻿
using LibertyAutomation.Hooks;
using LibertyAutomation.Utilities;
using Microsoft.Graph;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibertyAutomation.Web.ObjectRepo;

namespace LibertyAutomation.LibertyAutomation.PageObjects
{
     class ResetPasswordLink : ActionHelper
    {

        IWebDriver driver;

        ResetPasswordLinkRepo resetPasswordRepo;
        TestBase gsh;
        //Reset repopassword;





        public ResetPasswordLink()
        {
            driver = liberty.driver;
            // resetpassword = new ResetPassRep();
            gsh = new TestBase();
            resetPasswordRepo = new ResetPasswordLinkRepo();
            //restPasswordRep = new RestPasswordRep();    
            PageFactory.InitElements(driver, resetPasswordRepo);
        }
        public void NavigateToTheHelthOneWebSite(string sURL)
        {
            driver.Navigate().GoToUrl(sURL);


        }

        public void ClickOnResetPassword()

        {
            
            ClickObject(resetPasswordRepo.ResetPasswordLink, driver);


        }
    }
}