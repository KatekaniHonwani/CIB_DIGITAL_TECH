using System;
using LibertyAutomation.HealthOneAPI.AppSpecific;
using LibertyAutomation.Hooks;
using LibertyAutomation.Utilities;
using AventStack.ExtentReports.Gherkin.Model;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace LibertyAutomation.HealthOneAPI.StepDefinitions
{
    [Binding]
    public class CreateNewAppointmentStepDefinitions
    {

        readonly APIHelper api;
        readonly Appointments ap;
        String[] sResponse;
        private readonly TestBase tBase;

        public CreateNewAppointmentStepDefinitions()
        {
            api = new APIHelper();
            tBase = new TestBase();
            ap = new Appointments();

        }

        [Given(@"a user creates new appointment  ""([^""]*)"" using worksheet ""([^""]*)"" sheet ""([^""]*)""")]
        public void GivenAUserCreatesNewAppointmentUsingWorksheetSheet(int rowcount, string spreadsheetID, string sheetID)
        {
            if (TestBase.sheetValues == null || sheetID != TestBase.SheetID)

            {

                TestBase.SheetID = sheetID;

                if (config.DataType.ToUpper().Equals("GOOGLESHEETS")) tBase.initializeGoogleSheets(spreadsheetID, sheetID); else tBase.initializeExcelSheet(spreadsheetID, sheetID);

            }

            TestBase.sheetRow = rowcount;
        }

        [When(@"a user updates the payload with required data from the worksheet using file ""([^""]*)""")]
        public void WhenAUserUpdatesThePayloadWithRequiredDataFromTheWorksheetUsingFile(string sFilePath)
        {
            ap.AppointmentsUpdateJsonFile(TestBase.sheetValues, TestBase.sheetRow, sFilePath);
        }


        [When(@"a user sends a post request to create new appointment usings ""([^""]*)"" and ""([^""]*)"" and ""([^""]*)""")]
        public void WhenAUserSendsAPostRequestToCreateNewAppointmentUsingsAndAnd(string sURL, string sFilePath, string sMemAPIKey)
        {
            sResponse = api.postRestRequest(sURL, sFilePath, sMemAPIKey);
        }



        [Then(@"a successful message is returned")]
        public void ThenASuccessfulMessageIsReturned()
        {
            Assert.AreEqual("OK", sResponse[1]);
            liberty.scenario.CreateNode<Then>(sResponse[0]);

        }
    }
}
