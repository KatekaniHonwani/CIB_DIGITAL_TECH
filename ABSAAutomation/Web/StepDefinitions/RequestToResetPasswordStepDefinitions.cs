using ABSAAutomation.ABSAAutomation.PageObjects;
using ABSAAutomation.Utilities;
using Google.Apis.Sheets.v4.Data;
using System;
using TechTalk.SpecFlow;
using static MongoDB.Driver.WriteConcern;

namespace ABSAAutomation.ABSAAutomation.StepDefinitions
{
    [Binding]
    public class RequestToResetPasswordStepDefinitions
    {
        readonly ResetPassword rstPass;
        readonly ResetPasswordLink rstLink;
        
        private readonly TestBase tBase;


        public RequestToResetPasswordStepDefinitions()
        {
            rstPass = new ResetPassword();
            rstLink = new ResetPasswordLink();
            tBase = new TestBase();
        }

        [When(@"a user clicks reset password")]
        public void WhenAUserClicksResetPassword()
        {
            rstLink.ClickOnResetPassword();
        }



        [When(@"a user enters email ""([^""]*)"" using worksheet ""([^""]*)"" sheet ""([^""]*)""")]
        public void WhenAUserEntersEmailUsingWorksheetSheet(int rowcount, string spreadsheetID, string sheetID)
        {
            if (TestBase.sheetValues != null || sheetID != TestBase.SheetID)
            {
                TestBase.SheetID = sheetID;
                if (config.DataType.ToUpper().Equals("GOOGLESHEETS")) tBase.initializeGoogleSheets(spreadsheetID, sheetID); else tBase.initializeExcelSheet(spreadsheetID, sheetID);
            }
            TestBase.sheetRow = rowcount;

            rstPass.EnterEmail(TestBase.sheetValues, TestBase.sheetRow);
        }
        [When(@"a user send the link")]
        public void WhenAUserSendTheLink()
        {
            rstPass.ClickEmail();

        }

        [Then(@"password is reseted")]
        public void ThenPasswordIsReseted()
        {
            rstPass.confirmRestpassword();
        }
    }
}
