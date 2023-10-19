using ABSAAutomation.Hooks;
using ABSAAutomation.Support.Utilities;
using ABSAAutomation.Utilities;
using ABSAAutomation.Web.ObjectRepo;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Org.BouncyCastle.Ocsp;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ABSAAutomation.Web.PageObjects
{
    class Task2Web : ActionHelper
    {
        IWebDriver driver;
        Task2WebRepo task2WebRepo;

        public Task2Web() 
        {
            driver = Absa.driver;
            task2WebRepo = new Task2WebRepo();
            PageFactory.InitElements(driver, task2WebRepo);
        }

        public void NavigateToWay2automation(string sURL)
        {
            driver.Navigate().GoToUrl(sURL);

        }

        public void AddUserButtonClick() 
        {
            ClickObject(task2WebRepo.btnAdd, driver);
        }


        public void AddNewUser(UserInformation userInformation)
        { 
            
            EnterValue(task2WebRepo.txtFirstName, driver, userInformation.first_Name);
            EnterValue(task2WebRepo.txtLastName, driver, userInformation.last_Name);
            EnterValue(task2WebRepo.txtUserName, driver, userInformation.user_Name);
            EnterValue(task2WebRepo.txtPassword, driver, userInformation.password);

            if (userInformation.customer == "Company AAA")
            {
                ClickObject(task2WebRepo.rbCompanyAAA, driver);
            }
            else
            {
                ClickObject(task2WebRepo.rbCompanyBBB, driver);
            }

            var select = new SelectElement(task2WebRepo.txtRole);


            SelectDropDownItem(task2WebRepo.txtRole, driver, "Text", userInformation.role);

            EnterValue(task2WebRepo.txtEmail, driver, userInformation.email);
            EnterValue(task2WebRepo.txtMobilePhone, driver, userInformation.cell);

            WaitForElementClickable(task2WebRepo.btnSave, driver);
            ClickObject(task2WebRepo.btnSave, driver);

        }

        public void VerifyTableWithIsAvailable()
        {

            bool tableIsAvailable = WaitForElementToBeDisplayed(task2WebRepo.txtTable, driver, 10);

            tableIsAvailable.Should().BeTrue();

        }

        public void CloseDialog() {
            ClickObject(task2WebRepo.btnClose, driver);
        }

    }
}
