using ABSAAutomation.ABSAAutomation.PageObjects;
using ABSAAutomation.Support.Utilities;
using ABSAAutomation.Web.PageObjects;
using Microsoft.Graph;
using System;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ABSAAutomation.Web.StepDefinitions
{
    [Binding]
    public class MemberComplaintContactUSStepDefinitions 
    {
        private readonly LogIn login;
        private readonly Dashboard dashboard;
        private readonly MemberComplaintContact memberComplaint;

        public MemberComplaintContactUSStepDefinitions() 
        {
            login = new LogIn();
            dashboard = new Dashboard();
            memberComplaint = new MemberComplaintContact();
        }

        [Given(@"a member is on the login page")]
        public void GivenAMemberIsOnTheLoginPage()
        {
            login.NavigateToSspWebsite(config.SspUrl);
        }

        [When(@"a member logs in to SSP using ""([^""]*)""")]
        public void WhenAMemberLogsInToSSPUsing(string loginEmailAddress)
        {
            
            login.LoginToSsp(loginEmailAddress);
            login.VerifySuccessfulLogin();
        }

        [When(@"Navigate to Complaints\.")]
        public void WhenNavigateToComplaints_()
        {
            dashboard.CheckProgressBarIsDoneAndNavigateTo("Complaints");
            dashboard.NavigateTo("Complaints");
        }

        [Then(@"member should be landed on the Contact Us tab by default")]
        public void ThenMemberShouldBeLandedOnTheContactUsTabByDefault()
        {
            dashboard.CheckProgressBarIsDoneAndNavigateTo("Complaints");
     
        }

        [When(@"a member click the Complain Online tab, they should be directed to the complaints page")]
        public void WhenAMemberClickTheComplainOnlineTabTheyShouldBeDirectedToTheComplaintsPage()
        {
            memberComplaint.NavigateToComplaintOnline();
        }

        [When(@"when the member populate invalid contact details to verify error alerts")]
        public void WhenWhenTheMemberPopulateInvalidContactDetailsToVerifyErrorAlerts(Table table)
        {
           
            

            var invalidCredentialsList = table.CreateSet<MemberComplaintCredentials>().ToList();

            foreach (var invalidAllCredentials in invalidCredentialsList)
            {

              
                memberComplaint.VerifyCorrectErrorDisplayed(invalidAllCredentials.complaintEmailAddress, invalidAllCredentials.complaintCellNumber, invalidAllCredentials.memberComplaint);
           
            }
        }

        [When(@"then click the continue button with valid details to submit complaint")]
        public void WhenThenClickTheContinueButtonWithValidDetailsToSubmitComplaint(Table table)
        {
            var memberComplaintCredentials = table.CreateSet<MemberComplaintCredentials>().ToList();

            foreach (var memberAllCredentials in memberComplaintCredentials)
            {


                memberComplaint.MemberComplaintSubmission(memberAllCredentials.complaintEmailAddress, memberAllCredentials.complaintCellNumber, memberAllCredentials.memberComplaint);

                

            }
        }


        [Then(@"member should be able to Review complaint information and submit complaint")]
        public void ThenMemberShouldBeAbleToReviewComplaintInformationAndSubmitComplaint()
        {
            memberComplaint.VerifySuccessComplaintReview();
            memberComplaint.SubmitMemberComplaint();
        }




    }
}
