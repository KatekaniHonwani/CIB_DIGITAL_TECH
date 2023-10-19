using ABSAAutomation.Hooks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABSAAutomation.ABSAAutomation.ObjectRepo
{
     class ResetPasswordRepo
    {


        readonly IWebDriver driver;

        public ResetPasswordRepo()
        {
            driver = Absa.driver;
        }


        [FindsBy(How = How.Id, Using = "Input.Email")]
        public IWebElement EmailTextBox;

        [FindsBy(How = How.XPath, Using = "(//button[text()='Send Link'])")]
        public IWebElement ResetPasswordButton;

        [FindsBy(How = How.XPath, Using = "/html/body/div/div/div/p[2]")]
        public IWebElement sConfirmSendLink;
    }
}
