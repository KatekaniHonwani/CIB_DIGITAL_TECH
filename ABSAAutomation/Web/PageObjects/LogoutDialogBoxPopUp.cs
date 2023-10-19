using System;
using ABSAAutomation.Hooks;
using ABSAAutomation.Utilities;
using ABSAAutomation.Web.ObjectRepo;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ABSAAutomation.Web.PageObjects
{
     class LogoutDialogBoxPopUp:ActionHelper
     {
         LogoutDialogBoxPopUpRepo logoutDialogBoxPopUpRepo;
         IWebDriver driver;

         public LogoutDialogBoxPopUp()
         {
             logoutDialogBoxPopUpRepo = new LogoutDialogBoxPopUpRepo();
             driver = Absa.driver;
             PageFactory.InitElements(driver,logoutDialogBoxPopUpRepo);
         }
         
         public void VerifyLogOutPopUpIsDisplayed()
         {
             WaitForElementClickable1(logoutDialogBoxPopUpRepo.txtLogOutPopUp, driver);
            
         }
         
         public void ClickLogoutPopUpButton(string button)
         {
             WaitForElementClickable1(logoutDialogBoxPopUpRepo.btnLogOutCancel, driver);
             if ( button.Equals("Cancel", StringComparison.OrdinalIgnoreCase))
                
             {
                 ClickObject(logoutDialogBoxPopUpRepo.btnLogOutCancel,driver);
             }
             else if ( button.Equals("Yes", StringComparison.OrdinalIgnoreCase))
             {
                 ClickObject(logoutDialogBoxPopUpRepo.btnLogOutYes,driver);
             }
            
         }

         public void VerifyLogOutPopUpIsNotVisible()
         {
             if (CheckisDisplayed(logoutDialogBoxPopUpRepo.txtLogOutPopUp,driver))
             {
                 Assert.Fail("Pop up is still visible");
             }
             
         }
         
    }
}