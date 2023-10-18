using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;

namespace ABSAAutomation.Web.ObjectRepo
{
    class ValueAddedServicesRepo
    {


        [FindsBy(How = How.XPath, Using = "//div[@class='background-card-vas']//div[@class='card-header']")]
        public IList<IWebElement> vasHeadings;

        [FindsBy(How = How.XPath, Using = "//div[@class = 'card-body']//p")]
        public IList<IWebElement> txtVasDescriptions;

        [FindsBy(How = How.CssSelector, Using = "button[class ~='btn-link']")]
        public IWebElement btnVasIcon;

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'telephonic access')]/parent::*/parent::*")]
        public IWebElement telephonicAccessContact;

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'digital')]/parent::*/parent::*")]
        public IWebElement digitalAccessContact;

        [FindsBy(How = How.XPath, Using = "//button[contains(@class,'contact')]")]
        public IWebElement btnDownloadContact;

        [FindsBy(How = How.CssSelector, Using = "[href *='VAS']")]
        public IWebElement linkAccessVas;

        [FindsBy(How = How.TagName, Using = "img")]
        public IWebElement imgLiberty;


    }
}

