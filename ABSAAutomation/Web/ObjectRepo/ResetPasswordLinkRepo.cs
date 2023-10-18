using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABSAAutomation.Web.ObjectRepo
{
    class ResetPasswordLinkRepo
    {
        [FindsBy(How = How.Id, Using = "forgot-password")]
        public IWebElement ResetPasswordLink;
    }
}
