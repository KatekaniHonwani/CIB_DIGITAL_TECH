using ABSAAutomation.ABSAAutomation.ObjectRepo;
using ABSAAutomation.Hooks;
using ABSAAutomation.Utilities;
using Microsoft.Graph;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABSAAutomation.ABSAAutomation.PageObjects
{
    class ResetPassword : ActionHelper
    {


        IWebDriver driver;
        ResetPasswordRepo rep;
        TestBase gsh;
        DataHelpers dat;
        private string sEmail = "";

        public ResetPassword()
        {
            driver = liberty.driver;

            gsh = new TestBase();
            rep = new ResetPasswordRepo();
              
            PageFactory.InitElements(driver, rep);
        }

       

        public void EnterEmail(WorkbookRange dTable, int iRow)
        {
            EnterValue(rep.EmailTextBox, driver, gsh.GetCellValue(dTable, "Email", iRow));
        }


        public void ClickEmail()
        {
            ClickObject(rep.ResetPasswordButton, driver);
        }

        public void confirmRestpassword()
        {
       
            
            string sEmailAddress = GetTextOfElement(rep.sConfirmSendLink, driver);
            Assert.IsTrue(sEmailAddress.Contains(sEmail));



        }
    }
}

