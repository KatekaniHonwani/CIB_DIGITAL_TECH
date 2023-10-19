using ABSAAutomation.Hooks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABSAAutomation.Web.ObjectRepo
{
   class Task2WebRepo
    {
        readonly IWebDriver driver;

        public Task2WebRepo() {
            driver = Absa.driver;
        }

        [FindsBy(How = How.CssSelector, Using = "[table-title *= 'Table' ]")]
        public IWebElement txtTable;

        [FindsBy(How = How.CssSelector, Using = "button[type ~='add']")]
        public IWebElement btnAdd;

        [FindsBy(How = How.Name, Using = "FirstName")]
        public IWebElement txtFirstName;

        [FindsBy(How = How.Name, Using = "LastName")]
        public IWebElement txtLastName;

        [FindsBy(How = How.Name, Using = "UserName")]
        public IWebElement txtUserName;

        [FindsBy(How = How.Name, Using = "Password")]
        public IWebElement txtPassword;

        [FindsBy(How = How.Name, Using = "Email")]
        public IWebElement txtEmail;

        [FindsBy(How = How.Name, Using = "Mobilephone")]
        public IWebElement txtMobilePhone;

        [FindsBy(How = How.XPath, Using = "//label[text()='Company AAA']/input")]
        public IWebElement rbCompanyAAA;

        [FindsBy(How = How.XPath, Using = "//label[text()='Company BBB']/input")]
        public IWebElement rbCompanyBBB;

        [FindsBy(How = How.ClassName, Using = "btn-success")]
        public IWebElement btnSave;

        [FindsBy(How = How.ClassName, Using = "btn-danger")]
        public IWebElement btnClose;

        [FindsBy(How = How.Name, Using = "RoleId")]
        public IWebElement txtRole;
   

    }
}
