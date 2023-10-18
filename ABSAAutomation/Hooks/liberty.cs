using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using ABSAAutomation.Utilities;
using System.Reflection;
using GoogleSheetsHelper;
using System.Diagnostics.PerformanceData;
using AventStack.ExtentReports.Reporter;
using System.Diagnostics;

namespace ABSAAutomation.Hooks
{
    [Binding]
    class liberty : TestBase
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        public static new IWebDriver driver;
        public static ExtentReports extent;
 
        public static ExtentReports extentZephyr;
        public static ExtentTest featureName;
        public static ExtentTest scenario;
        public static ExtentTest featureNameZephyr;
        public static ExtentTest scenarioZephyr;
        public static string sPath;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            sPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
            string sReportPath = sPath + "Reports\\TestAutomationReport.html";
            ExtentManager xt = new ExtentManager();
            extent = xt.initializeExtentReports(sReportPath);

        }
        [BeforeScenario]
        [Obsolete]
        public void BeforeScenario()
        {

            if (!ScenarioContext.Current.ScenarioInfo.Title.Contains("API"))
            {
                var chromeDriverProcesses = Process.GetProcesses().
                    Where(pr => pr.ProcessName == "chromedriver");

                foreach (var process in chromeDriverProcesses)
                {
                    try
                    {
                        process.Kill();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("unable to kill process " + e.Message);
                    }
                }
                driver = SetupBrowser(config.BrowserName);
            }

            scenario = liberty.featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);

            // scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
            //   Console.Out.WriteLine(scenario);

          
        }

        [AfterScenario]
        [Obsolete]
        public void AfterScenario()
        {
            if (!ScenarioContext.Current.ScenarioInfo.Title.Contains("API"))
            {
                
                DataHelpers.WriteBrowserLogs(driver);
                driver.Quit();
            }

        }
        [AfterTestRun]
        public static void TearDown()
        {
            
            extent.Flush();
        }

        [BeforeFeature]
        [Obsolete]
        public static void BeforeFeature()
        {
            if (FeatureContext.Current.FeatureInfo.Tags.Length == 0)
                featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
            else if (!FeatureContext.Current.FeatureInfo.Tags[0].Contains("ignore"))
                featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }

        [AfterStep]
        [Obsolete]
        public void InsertReportingsteps()
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            var screenshot = "";

            // PropertyInfo pInfo = typeof(ScenarioContext).GetProperty("TestStatus", BindingFlags.Instance | BindingFlags.NonPublic);
            //   MethodInfo getter = pInfo.GetGetMethod(nonPublic: true);
            //   object TestResult = getter.Invoke(ScenarioContext.Current, null);
            //utils ut = new utils();

            if (!ScenarioContext.Current.ScenarioInfo.Title.Contains("API"))
            {
                screenshot = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
                if (!ScenarioStepContext.Current.StepInfo.Text.Contains("worksheet"))
                {


                    if (ScenarioContext.Current.TestError == null && config.TakeScreenshots.ToUpper() == "NO" || ScenarioContext.Current.ScenarioInfo.Title.Contains("API"))
                    {
                        if (stepType == "Given")
                            scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                        else if (stepType == "When")
                            scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                        else if (stepType == "And")
                            scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
                        else if (stepType == "Then")
                            scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                       
                    }

                    else if (ScenarioContext.Current.TestError == null)
                    {
                        if (stepType == "Given")
                            scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Pass("", MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, ScenarioContext.Current.ScenarioInfo.Title.Trim()).Build());
                        else if (stepType == "When")
                            scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Pass("", MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, ScenarioContext.Current.ScenarioInfo.Title.Trim()).Build());
                        else if (stepType == "And")
                            scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Pass("", MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, ScenarioContext.Current.ScenarioInfo.Title.Trim()).Build());
                        else if (stepType == "Then")
                            scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Pass("", MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, ScenarioContext.Current.ScenarioInfo.Title.Trim()).Build());
                        

                    }
                    else if (ScenarioContext.Current.TestError != null)
                    {
                        if (stepType == "Given")
                            scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, ScenarioContext.Current.ScenarioInfo.Title.Trim()).Build());
                        else if (stepType == "When")
                            scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, ScenarioContext.Current.ScenarioInfo.Title.Trim()).Build());
                        else if (stepType == "And")
                            scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, ScenarioContext.Current.ScenarioInfo.Title.Trim()).Build());
                        else if (stepType == "Then")
                            scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, ScenarioContext.Current.ScenarioInfo.Title.Trim()).Build());
                       

                    }
                }
            }
            else
            {
                if (ScenarioContext.Current.TestError == null)
                {
                    if (stepType == "Given")
                        scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                    else if (stepType == "When")
                        scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                    else if (stepType == "And")
                        scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
                    else if (stepType == "Then")
                        scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                   
                }
                else
                {
                    if (stepType == "Given")
                        scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                    else if (stepType == "When")
                        scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                    else if (stepType == "And")
                        scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                    else if (stepType == "Then")
                        scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);

                    
                }

            }



            /*     if (TestResult.ToString() == "StepDefinitionPending")

                 {
                     if (stepType == "Given")
                         scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                     else if (stepType == "When")
                         scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                     else if (stepType == "And")
                         scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                     else if (stepType == "Then")
                         scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");

                 }*/

        }
    }

}