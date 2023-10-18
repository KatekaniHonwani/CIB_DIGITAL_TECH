using LibertyAutomation.Hooks;
using LibertyAutomation.Utilities;
using LibertyAutomation.Web.ObjectRepo;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace LibertyAutomation.Web.PageObjects
{
    class  MemberComplaintContact : ActionHelper
    {
        private readonly MemberComplaintContactRepo memberComplaintContactRepo;
        private readonly IWebDriver driver;

        public MemberComplaintContact()
        {
            driver = liberty.driver;

            memberComplaintContactRepo = new MemberComplaintContactRepo();
            PageFactory.InitElements(driver, memberComplaintContactRepo);
        }

        public void VerifyContactUsIsDefault()
        {

            bool isDisplayed = WaitForElementToBeDisplayed(memberComplaintContactRepo.divContactUsContainer, driver, 10);

            if (!isDisplayed)
            {
                Assert.Fail("Contuct Us is not Default selected Tab");
            }

        }

        public  void  NavigateToComplaintOnline() 
        {
            ClickObject(memberComplaintContactRepo.btnComplain, driver);
            
        }

        public async void VerifyCorrectErrorDisplayed(String invalidEmail, String invalidCellNumber, string invalidComplaint) 
        {
            
            ClearFieldValue(memberComplaintContactRepo.txtInputInvalidEmail, driver);
            EnterValue(memberComplaintContactRepo.txtInputInvalidEmail, driver, invalidEmail);
            WaitForElementToBeDisplayed(memberComplaintContactRepo.txtInvalidEmail, driver, 5);


            ClearFieldValue(memberComplaintContactRepo.txtInputInvalidCellNumber, driver);
            EnterValue(memberComplaintContactRepo.txtInputInvalidCellNumber, driver, invalidCellNumber);
            WaitForElementToBeDisplayed(memberComplaintContactRepo.txtInvalidCellNumber, driver, 5);


            ClearFieldValue(memberComplaintContactRepo.txtInputInvalidComplaint, driver);
            //WaitForElementClickable(memberComplaintContactRepo.txtInputInvalidComplaint, driver);
           // EnterValue(memberComplaintContactRepo.txtInputInvalidComplaint, driver, invalidComplaint);
            WaitForElementToBeDisplayed(memberComplaintContactRepo.txtAddDetails, driver, 5);

        }

        public void MemberComplaintSubmission(String invalidEmail, String invalidCellNumber, string invalidComplaint)
        {

            

            ClearFieldValue(memberComplaintContactRepo.txtInputInvalidEmail, driver);
            EnterValue(memberComplaintContactRepo.txtInputInvalidEmail, driver, invalidEmail);

            ClearFieldValue(memberComplaintContactRepo.txtInputInvalidCellNumber, driver);
            EnterValue(memberComplaintContactRepo.txtInputInvalidCellNumber, driver, invalidCellNumber);

            ClearFieldValue(memberComplaintContactRepo.txtInputInvalidComplaint, driver);
            EnterValue(memberComplaintContactRepo.txtInputInvalidComplaint, driver, invalidComplaint);

            WaitForElementClickable(memberComplaintContactRepo.btnContinueComplaint, driver);
            ClickObject(memberComplaintContactRepo.btnContinueComplaint, driver);

        }

        

        public void VerifySuccessComplaintReview()
        {
           
            bool isDisplayed = WaitForElementToBeDisplayed(memberComplaintContactRepo.txtReviewCompliantInfo, driver, 10);

            if (!isDisplayed)
            {
                Assert.Fail("Unable to verify user information captured");
            }

        }


        public void SubmitMemberComplaint() 
        {
            ClickObject(memberComplaintContactRepo.btnSubmitComplaint, driver);
        }
    }
}
