using ABSAAutomation.Hooks;
using ABSAAutomation.Utilities;
using ABSAAutomation.Web.ObjectRepo;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;
using SeleniumExtras.WaitHelpers;

namespace ABSAAutomation.Web.PageObjects
{
    class Dashboard : ActionHelper
    {

        private readonly DashboardRepo dashboardRepo;
        private readonly IWebDriver driver;
        public Dashboard()
        {

            driver = liberty.driver;
            dashboardRepo = new DashboardRepo();

            PageFactory.InitElements(driver, dashboardRepo);

        }

        public void CheckProgressBarIsDoneAndNavigateTo(string menuText)
        {

            bool progressBarCompleted = WaitForElementToDisappear(dashboardRepo.progressBar, driver);

            if (progressBarCompleted)
            {
                NavigateTo(menuText);
            }

        }

        public void NavigateTo(string menuText)
        {

            IList<IWebElement> menuItems = dashboardRepo.menuItems;

            foreach (IWebElement menuItem in menuItems)
            {

                if (GetTextOfElement(menuItem, driver).Equals(menuText))
                {

                    ScrollTo(menuItem, driver);

                    ClickObject(menuItem, driver);

                    break;

                }

            }

            VerifyNavigationSuccess();

        }

        private void VerifyNavigationSuccess()
        {

            bool navigated = WaitForElementToBeDisplayed(dashboardRepo.txtPageHeading, driver, 20);

            if (!navigated)
            {

                Assert.Fail("Failed to navigate");

            }

        }

    }

}
