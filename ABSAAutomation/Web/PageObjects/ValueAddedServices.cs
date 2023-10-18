using ABSAAutomation.Hooks;
using ABSAAutomation.Utilities;
using ABSAAutomation.Web.ObjectRepo;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace ABSAAutomation.Web.PageObjects
{
    class ValueAddedServices : ActionHelper
    {

        private readonly ValueAddedServicesRepo vasRepo;
        private readonly IWebDriver driver;
        public ValueAddedServices()
        {

            driver = liberty.driver;
            vasRepo = new ValueAddedServicesRepo();

            PageFactory.InitElements(driver, vasRepo);

        }

        public Dictionary<string,string> GetValueAddedServices()
        {

            WaitForElementToBeDisplayed(vasRepo.btnVasIcon, driver, 10);

            Dictionary<string, string> vasHeadingsAndDescriptions = new Dictionary<string, string>();

            string vasHeading = "";
            string vasDescription = "";

            foreach(IWebElement vasHeadingContainer in vasRepo.vasHeadings)
            {

                vasHeading = GetTextOfElement(vasHeadingContainer, driver);

                ClickObject(vasHeadingContainer, driver);

                vasDescription = GrabVasDescription();

                ClickObject(vasHeadingContainer, driver);

                vasHeadingsAndDescriptions.Add(vasHeading, vasDescription);

            }
            
            return vasHeadingsAndDescriptions;
            
        }

        private string GrabVasDescription()
        {

            string vasDescription = "";

            foreach(IWebElement vasDesc in vasRepo.txtVasDescriptions)
            {

                if(WaitForElementToBeDisplayed(vasDesc, driver, 5))
                {
                    vasDescription = GetTextOfElementJsExecutor(vasDesc, driver);
                    break;
                }

            }

            return vasDescription;

        }

        public void VerifyCorrectVasesDisplayed(bool hasFuneralBenefits, Dictionary<string,string> vasesHeadingsAndDescriptions)
        {

            Dictionary<string, string> vases = GetValueAddedServices();

            HashSet<string> issues = new HashSet<string>();

            string vasHeading = "";
            string vasDescription = "";
            
            if (!hasFuneralBenefits)
            {

                vasesHeadingsAndDescriptions.Remove("Funeral Assistance Service");

            }

            if (!hasFuneralBenefits && vases.ContainsKey("Funeral Assistance Service"))
            {

                issues.Add("Member has no funeral benefits but Funeral Assistance Service is displayed as a VAS");

            }

            foreach (KeyValuePair<string, string> vasAndDesc in vasesHeadingsAndDescriptions)
            {

                vasHeading = vasAndDesc.Key;
                vasDescription = vasesHeadingsAndDescriptions[vasHeading];

                if (!vases.ContainsKey(vasHeading))
                {

                    issues.Add($"{vasHeading} is not displayed as a VAS.");

                }
                else if (vases.ContainsKey(vasHeading) && !vases[vasHeading].Equals(vasDescription))
                {

                    issues.Add($"The description of the VAS \"{vasHeading}\" is incorrect ");

                }

            }

            ReportIssues(issues);

        }

        private void ReportIssues(HashSet<string> setOfIssues)
        {

            string issueMarker = "  <---->  ";

            string issues = String.Join(issueMarker, setOfIssues);

            if (setOfIssues.Count > 0)
            {
                Assert.Fail($"{issueMarker} {issues} {issueMarker}");
            }

        }

        public void VerifyContactDetailsAreCorrect(Dictionary<string,string> contactTableData)
        {

            string telephonicAccess = GetTextOfElement(vasRepo.telephonicAccessContact, driver);
            string digitalMessaging = GetTextOfElement(vasRepo.digitalAccessContact, driver);

            telephonicAccess = telephonicAccess.Replace("\r\n", " ").Replace("Hiresh Parbhoo ", "");
            digitalMessaging = digitalMessaging.Replace("\r\n", " ").Replace("Hiresh Parbhoo ","");

            Assert.Multiple(() =>
            {
                Assert.AreEqual(contactTableData["telephonicAccess"],telephonicAccess);
                Assert.AreEqual(contactTableData["digitalMessaging"],digitalMessaging);
            });

        }

        public void VerifyContactDownload()
        {

            ScrollTo(vasRepo.btnDownloadContact, driver);

            WaitForElementClickable(vasRepo.btnDownloadContact, driver);

            ClickObject(vasRepo.btnDownloadContact, driver);

        }

        public void VerifyUserIsRedirectedToNewTab()
        {

            int numberOfActiveTabs = driver.WindowHandles.Count;

            Assert.That(numberOfActiveTabs == 1, "There's already an additional tab opened.");

            ScrollTo(vasRepo.linkAccessVas, driver);

            ClickObject(vasRepo.linkAccessVas, driver);

            numberOfActiveTabs = driver.WindowHandles.Count;

            Assert.That(numberOfActiveTabs == 2, "Clicking on link did not trigger a new tab to open");

            SwitchToNewWindow(driver);

            WaitForElementToBeDisplayed(vasRepo.imgLiberty, driver,10);

        }

    }
}
