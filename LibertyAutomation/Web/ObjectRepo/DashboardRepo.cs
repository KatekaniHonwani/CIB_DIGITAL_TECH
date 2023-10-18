using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;

namespace LibertyAutomation.Web.ObjectRepo
{
    class DashboardRepo
    {

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'dashboard-container')]")]
        public IWebElement divDashboardContainer;

        [FindsBy(How = How.XPath, Using = "//h1[text()[contains(.,'Welcome')]]")]
        public IWebElement txtWelcome;

        [FindsBy(How = How.ClassName, Using = "sidebar-content")]
        public IWebElement divSidebarContent;

        [FindsBy(How = How.XPath, Using = "//span[contains(@class,'menu')]")]
        public IList<IWebElement> menuItems;

        [FindsBy(How = How.XPath, Using = "//h1")]
        public IWebElement txtPageHeading;

        [FindsBy(How = How.XPath, Using = "//div[@class='page-progress progress']")]
        public IWebElement pageLoadProgress;
        public By progressBar => By.XPath("//div[@class='page-progress progress']");

    }
}
