using System;

using System.Threading;

using System.Collections.Generic;

using System.Text;

using OpenQA.Selenium;

using OpenQA.Selenium.Support.UI;

using OpenQA.Selenium.Interactions;


using System.IO;

using iTextSharp.text.pdf;

using iTextSharp.text.pdf.parser;

using ABSAAutomation.Web.ObjectRepo;

using System.Linq;
using SeleniumExtras.WaitHelpers;

namespace ABSAAutomation.Utilities

{

    class ActionHelper

    {

        public String GetCurrentUrl(IWebDriver driver)

        {

            String url = null;

            try

            {

                url = driver.Url;

            }

            catch (Exception e)

            {

                Console.WriteLine("Unable to get current url " + e.Message);

            }

            return url;

        }

        public string GetClientIdFromCurrentUrl(IWebDriver driver)

        {

            string clientId = null;

            try

            {

                string url = driver.Url;

                string[] urlSplit = url.Split('&');

                string clientDetails = urlSplit[1];



                string[] urlSplit1 = clientDetails.Split('=');

                clientId = urlSplit1[1];

            }

            catch (Exception e)

            {

                Console.WriteLine("Unable to get the clientId from current url " + e.Message);

            }

            return clientId;

        }

        public void ClickObject(IWebElement sElement, IWebDriver driver)

        {

            try

            {

                WaitForElementClickable(sElement, driver);



                sElement.Click();

            }

            catch (Exception e)

            {

                Console.WriteLine("Unable to click object " + e.Message);

            }

        }

        public bool EnterValue1(IWebElement element, IWebDriver driver, string Value)

        {

            try

            {

                WaitForElementClickable1(element, driver);



                element.Clear();

                element.SendKeys(Value);

                return true;

            }

            catch (Exception e)

            {

                Console.WriteLine("Unable to enter Value  " + e.Message);

                return false;

            }

        }

        public void EnterValue(IWebElement sElement, IWebDriver driver, string Value)

        {

            try

            {

                WaitForElementClickable(sElement, driver);



                sElement.Clear();

                sElement.SendKeys(Value);

            }

            catch (Exception e)

            {

                Console.WriteLine("Unable to enter Value  " + e.Message);

            }

        }

        public void ClearFieldValue(IWebElement sElement, IWebDriver driver)

        {

            try

            {

                WaitForElementClickable(sElement, driver);



                sElement.Clear();

            }

            catch (Exception e)

            {

                Console.WriteLine("Unable to Clear Field " + e.Message);

            }

        }

        public void SwitchToNewWindow(IWebDriver driver)
        {

            string mainWindow = driver.CurrentWindowHandle;

            foreach(string window in driver.WindowHandles)
            {
                if (!window.Equals(mainWindow))
                {
                    driver.SwitchTo().Window(window);
                }
            }

        }
  
        public void SwitchFocusToFrame(IWebDriver driver, string FrameToFocusOn)

        {

            WebDriverWait waitForFrame = new WebDriverWait(driver, new TimeSpan(0, 0, 20));

            waitForFrame.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.FrameToBeAvailableAndSwitchToIt(FrameToFocusOn));

        }

        public void SelectDropDownItem(IWebElement sElement, IWebDriver driver, string Identifier, string ItemToSelect)

        {

            try

            {

                WaitForElementClickable(sElement, driver);



                SelectElement sEle = new SelectElement(sElement);

                sEle.SelectByValue(ItemToSelect);

                if (Identifier.ToUpper() == "VALUE")

                {

                    sEle.SelectByValue(ItemToSelect);

                }

                else if (Identifier.ToUpper() == "TEXT")

                {

                    sEle.SelectByText(ItemToSelect);

                }



            }

            catch (Exception e)

            {

                Console.WriteLine("Unable to Select Field " + e.Message);

            }

        }

        public string GetValueOfElement(IWebElement sElement, IWebDriver driver)

        {

            String value = null;

            try

            {

                value = sElement.GetAttribute("value");

            }

            catch (Exception e)

            {

                Console.WriteLine("Unable to get attribute value " + e.Message);

            }

            return value;

        }

        public string GetTextOfElementJsExecutor(IWebElement webElement, IWebDriver driver)
        {

            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;

            string script = "return arguments[0].innerHTML";

            return (string)jsExecutor.ExecuteScript(script, webElement);
            
        }

        public string GetTextOfElement(IWebElement sElement, IWebDriver driver)

        {

            string value = null;

            try

            {

                value = sElement.Text;

            }

            catch (Exception e)

            {

                Console.WriteLine("Unable to get attribute text " + e.Message);

            }

            return value;

        }

        public bool WaitForElementClickable1(IWebElement element, IWebDriver driver)

        {

            try

            {

                WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));

                return true;

            }

            catch (Exception e)

            {

                Console.WriteLine(e.Message);

                return false;

            }

        }

        public void UploadFileofTypeEqualsFile(IWebElement sElement, IWebDriver driver, string filepath)



        {



            try



            {



                sElement.SendKeys(filepath);



            }



            catch (Exception e)



            {



                Console.WriteLine("Unable to upload file  " + e.Message);



            }



        }

        public void WaitForElementClickable(IWebElement sElement, IWebDriver driver)

        {

            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));



            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(sElement));

        }

        public void ScrollTo(IWebElement element, IWebDriver driver)

        {



            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);

        }

        public void ScrollTo2(IWebElement element, IWebDriver driver)

        {

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);

        }

        public void ClearFieldAndEnterValueUsingActionBuilder(IWebElement sElement, IWebDriver driver, String sData)

        {

            try

            {

                IWebElement keysEventInput = sElement;



                Actions actionProvider = new Actions(driver);

                actionProvider.Click(keysEventInput)

                .KeyDown(Keys.Control)

                .SendKeys("a")

                .KeyUp(Keys.Control)

                .SendKeys(Keys.Backspace)

                .Build()

                .Perform();

                Thread.Sleep(2000);

                IAction sValue = actionProvider.SendKeys(keysEventInput, sData).Build();

                sValue.Perform();



            }

            catch (Exception e)

            {

                Console.WriteLine("Unable to clear and enter text " + e.Message);

            }

        }

        public void ClearFieldUsingActionBuilder(IWebElement sElement, IWebDriver driver)

        {

            try

            {

                IWebElement keysEventInput = sElement;



                Actions clearProvider = new Actions(driver);

                clearProvider.Click(keysEventInput)

                .KeyDown(Keys.Control)

                .SendKeys("a")

                .KeyUp(Keys.Control)

                .SendKeys(Keys.Backspace)

                .Build()

                .Perform();

            }

            catch (Exception e)

            {

                Console.WriteLine("Unable to clear and enter text " + e.Message);

            }

        }

        public void EnterValueUsingActionBuilder(IWebElement sElement, IWebDriver driver, String sData)

        {

            try

            {

                IWebElement keysEventInput = sElement;



                Actions actionProvider = new Actions(driver);

                actionProvider.Click(keysEventInput)

                .KeyDown(Keys.Left)

                .SendKeys(sData)

                .KeyUp(Keys.Left)

                .Build()

                .Perform();

            }

            catch (Exception e)

            {

                Console.WriteLine("Unable to clear and enter text " + e.Message);

            }

        }

        public void ClickObjectJSExecuter(IWebElement sElement, IWebDriver driver)

        {

            try

            {

                IWebElement iWebElement = sElement;

                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", iWebElement);

            }

            catch (Exception e)

            {

                Console.WriteLine("Unable to click object " + e.Message);

            }

        }

        public void GetPageUri(IWebDriver driver)

        {

            IJavaScriptExecutor j = (IJavaScriptExecutor)driver;

            string url = j.ExecuteScript("window.location.href;").ToString();

            Console.WriteLine(url);

        }

        public bool IsElementPresent(IWebElement by, IWebDriver driver)

        {

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);//seconds 0 so that WebDriver doesn't implicitly wait

            bool isDisplayed = false;

            try

            {

                isDisplayed = by.Displayed;

                return true;

            }

            catch (NoSuchElementException)

            {

                return false;

            }

            finally

            {

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);//seconds back to 30 after the action is complete

            }

        }

        public bool WaitForElementToDisappear(By elementLocator,IWebDriver driver)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));

            bool elementDisappeared = false;

            try
            {

                elementDisappeared = wait.Until(ExpectedConditions.InvisibilityOfElementLocated(elementLocator));

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return elementDisappeared;

        }

        public bool WaitForElementToBeDisplayed(IWebElement element, IWebDriver driver, int waitingDuration)
        {

            bool isDisplayed = false;

            try
            {


                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitingDuration));

                isDisplayed = wait.Until(el => element.Displayed);

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);

            }

            return isDisplayed;

        }

        public bool CheckisDisplayed(IWebElement sElement, IWebDriver driver)

        {

            bool isDisplayed = false;

            try

            {

                isDisplayed = sElement.Displayed;

                //isDisplayed = true; // causes isDisplayed to always return true 

            }

            catch (Exception e)

            {

                Console.WriteLine("Object not displayed " + e.Message);

            }

            return isDisplayed;



        }

        public bool CheckisSelected(IWebElement sElement, IWebDriver driver)

        {

            bool isSelected = false;

            try

            {

                isSelected = sElement.Selected;

            }

            catch (Exception e)

            {

                Console.WriteLine("Object not displayed " + e.Message);

            }

            return isSelected;

        }

        public bool IsElementChecked(IWebElement sElement, IWebDriver driver)

        {

            bool c = true;

            try

            {

                if (sElement.GetAttribute("checked") == "true")

                    c = true;

                else

                    c = false;

            }

            catch (Exception e)

            {



                Console.WriteLine("Unable to find Field " + e.Message);

            }

            return c;

        }

        public bool IsElementDisabled(IWebElement sElement, IWebDriver driver)

        {

            bool c = true;

            try

            {

                if (sElement.GetAttribute("disabled") == "true")

                    c = true;

                else

                    c = false;



            }

            catch (Exception e)

            {



                Console.WriteLine("Unable to find Field " + e.Message);

            }

            return c;

        }

        public bool isElementEnabled(IWebElement sElement, IWebDriver driver)

        {

            bool c = true;

            try

            {

                WaitForElementClickable(sElement, driver);

            }

            catch (Exception e)

            {

                c = false;

            }

            return c;

        }

        public static bool VerifyLinkResponse(string url)

        {

            bool linkResponse;



            if (url.ToLower().Contains("blob:"))

            {

                linkResponse = true;

            }

            else

            {

                throw new Exception($"The {url} could not be verified or loaded!");

            }

            return linkResponse;

        }

        public string Between2Strings(string Text, string FirstString, string LastString)

        {

            string STR = Text;

            string STRFirst = FirstString;

            string STRLast = LastString;

            string FinalString;



            if (Text.Contains(FirstString))

            {

                int Pos1 = STR.IndexOf(FirstString) + FirstString.Length;

                STR = STR.Substring(Pos1);

                int Pos2 = STR.IndexOf(LastString);

                //FinalString = STR.Substring(Pos1, Pos2 - Pos1);

                FinalString = STR.Substring(0, Pos2);

            }

            else

            {

                FinalString = "OK";

            }

            return FinalString;

        }
    }

}
