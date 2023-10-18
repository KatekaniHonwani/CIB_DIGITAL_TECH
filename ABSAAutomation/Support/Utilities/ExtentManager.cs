using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibertyAutomation.Utilities
{
    class ExtentManager
    {

        public static ExtentHtmlReporter htmlReporter;

        public ExtentReports initializeExtentReports(String ReportName)

        {
             htmlReporter = new ExtentHtmlReporter(ReportName);
            var extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            return extent;

        }
    }
}
