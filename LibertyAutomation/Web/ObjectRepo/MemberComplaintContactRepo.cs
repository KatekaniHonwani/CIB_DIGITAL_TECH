using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibertyAutomation.Web.ObjectRepo
{
    public class MemberComplaintContactRepo
    {

        [FindsBy(How = How.Id, Using = "btn-contact-us")]
        public IWebElement btnContactUs;

        [FindsBy(How = How.Id, Using = "btn-complain")]
        public IWebElement btnComplain;

        [FindsBy(How = How.XPath, Using = "//div[@class=\"background-card body-card-complaints body-card-complaints-divider\"]")]
        public IWebElement divContactUsContainer;

        [FindsBy(How = How.CssSelector, Using = "input[placeholder ~= 'email']")]
        public IWebElement txtInputInvalidEmail;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Email')]")]
        public IWebElement txtInvalidEmail;

        [FindsBy(How = How.CssSelector, Using = "input[placeholder ~= 'cell']")]
        public IWebElement txtInputInvalidCellNumber;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Cell')]")]
        public IWebElement txtInvalidCellNumber;

        [FindsBy(How = How.CssSelector, Using = "textarea[placeholder ~= 'complaint']")]
        public IWebElement txtInputInvalidComplaint;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'add detail')]")]
        public IWebElement txtAddDetails;

        [FindsBy(How = How.ClassName, Using = "browse-button")]
        public IWebElement btnUploadDocument;

        [FindsBy(How = How.ClassName, Using = "btn-continue")]
        public IWebElement btnContinueComplaint;

        [FindsBy(How = How.ClassName, Using = "btn-cancel")]
        public IWebElement btnClearComplaint;


        [FindsBy(How = How.ClassName, Using = "modal-complaints-red-text-button")]
        public IWebElement btnDialogCancel;

        [FindsBy(How = How.ClassName, Using = "modal-complaints-ok-text-button")]
        public IWebElement btnDialogContinue;

        [FindsBy(How = How.ClassName, Using = "welcome-tag")]
        public IWebElement txtReviewCompliantInfo;

        [FindsBy(How = How.ClassName, Using = "btn-continue")]
        public IWebElement btnSubmitComplaint;

        [FindsBy(How = How.ClassName, Using = "title-modal-risk-benfits")]
        public IWebElement txtClearFoamconfirmation;
       


    }
}