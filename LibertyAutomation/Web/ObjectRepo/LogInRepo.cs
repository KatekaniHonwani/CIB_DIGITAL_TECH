using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace LibertyAutomation.Web.ObjectRepo
{
    public class LogInRepo
    {
       
        [FindsBy(How = How.Id, Using = "EmailInput_EmailAddress")]
        public IWebElement txtEmail;
        
        [FindsBy(How = How.Id, Using = "to-login-button")]
        public IWebElement btnContinue;
        
        [FindsBy(How = How.XPath, Using = "//h1[text()[contains(.,'Welcome')]]")]
        public IWebElement txtDashboardWelcomeMessage;
        
        [FindsBy(How = How.XPath, Using = "//div[contains(text(), 'Welcome')]")]
        public IWebElement txtLogInPageWelcomeMessage;
        
    }
    
}
