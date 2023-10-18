using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace LibertyAutomation.Web.ObjectRepo
{
    public class LogoutDialogBoxPopUpRepo
    {
        [FindsBy(How = How.XPath, Using = "//button[text()='Yes']")]
        public IWebElement btnLogOutYes;
        
        [FindsBy(How = How.XPath, Using = "//button[text()='Cancel']")]
        public IWebElement btnLogOutCancel;
        
        [FindsBy(How = How.XPath, Using = "//p[contains(., 'log out?')]")]
        public IWebElement txtLogOutPopUp;
    }
}