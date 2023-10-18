using GoogleSheetsHelper;

using OpenQA.Selenium;

using OpenQA.Selenium.Chrome;

using OpenQA.Selenium.Firefox;

using OpenQA.Selenium.IE;

using System;

//using Microsoft.Edge.SeleniumTools;

using ABSAAutomation.Hooks;
using Microsoft.Graph;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.DevTools;
using System.IO;
//using OpenQA.Selenium.DevTools.Console;
using NUnit.Framework;
using OpenQA.Selenium.Edge;
using System.Data;



namespace ABSAAutomation.Utilities

{

    class TestBase : ExcelHelper

    {

        protected IWebDriver driver;

        public static int generatedDataRow;

        private EdgeOptions edgeOptions;

        private FirefoxOptions firefoxOptions;



        public static int sheetRow;

        public static WorkbookRange sheetValues;

        public static string SheetID;

        public static string SpreadsheetID;

        //   public static DevToolsSession session;

        //    public static int cid;



        public static DataTable rowValues;

        //  public static string NewSheetID;

        private GoogleSheetsHelper2 gsh;





        public IWebDriver SetupBrowser(String BrowserName)

        {

            switch (BrowserName.ToUpper())

            {

                case "CHROME":

                    new DriverManager().SetUpDriver(new ChromeConfig());

                    ChromeOptions options = new ChromeOptions();

                    options.SetLoggingPreference(LogType.Browser, LogLevel.Severe);

                    driver = new ChromeDriver(options);

                    driver.Manage().Window.Maximize();

                    break;

                case "FIREFOX":

                    new DriverManager().SetUpDriver(new FirefoxConfig());

                    firefoxOptions = new FirefoxOptions();

                    firefoxOptions.AcceptInsecureCertificates = true;

                    driver = new FirefoxDriver(firefoxOptions);

                    driver.Manage().Window.Maximize();

                    break;

                case "EDGE":

                    new DriverManager().SetUpDriver(new EdgeConfig());

                    edgeOptions = new EdgeOptions();

                    driver = new EdgeDriver(edgeOptions);

                    driver.Manage().Window.Maximize();

                    break;

                case "IE":

                    new DriverManager().SetUpDriver(new InternetExplorerConfig());

                    driver = new InternetExplorerDriver();

                    driver.Manage().Window.Maximize();

                    break;

            }

            //  driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);

            return driver;

        }




        public void initializeExcelSheet(string spreadsheetID, string sheetName)
        {
            sheetValues = GetSheetData(spreadsheetID, sheetName).GetAwaiter().GetResult();
        }




        public void initializeGoogleSheets(String SpreadsheetID, String sheetid)

        {

            gsh = new GoogleSheetsHelper.GoogleSheetsHelper2(SpreadsheetID);

            //  var gsp = new GoogleSheetParameters() { RangeColumnStart = 1, RangeRowStart = 1, RangeColumnEnd = NumberOfColumn, FirstRowIsHeaders = true, SheetName = sheetid };

            var gsp = new GoogleSheetParameters() { RangeColumnEnd = 700, SheetName = sheetid };



            rowValues = gsh.GetGoogleSheetsData(gsp);





            // String value = gsh.getCellData(rowValues, "SAIDNumber", 0);





        }



    





        public DataTable getGeneratedDataGoogleSheets(String SpreadsheetID, String sheetid)

        {

            gsh = new GoogleSheetsHelper.GoogleSheetsHelper2(SpreadsheetID);

            //  var gsp = new GoogleSheetParameters() { RangeColumnStart = 1, RangeRowStart = 1, RangeColumnEnd = NumberOfColumn, FirstRowIsHeaders = true, SheetName = sheetid };

            var gsp = new GoogleSheetParameters() { RangeColumnEnd = 300, SheetName = sheetid };



            DataTable dataGen = gsh.GetGoogleSheetsData(gsp);



            return dataGen;



        }



     





        public string getDataGeneratedValue(WorkbookRange dValues, DataTable dtTable, String ColumnToCheck, int Column, string username)

        {

            string gValue = null;

            if (!config.DataType.ToUpper().Equals("GOOGLESHEETS"))

            {

                for (int i = 0; i < dValues.ColumnCount; i++)

                {

                    if (dValues.Values[0][i].ToString().Trim().ToUpper() == ColumnToCheck.Trim().ToUpper())

                    {

                        for (int r = 0; r < dValues.RowCount; r++)

                        {

                            string dUsername = dValues.Values[r][0].ToString();

                            if (dUsername.ToUpper() == username.ToUpper())

                            {

                                string col1 = dValues.Values[r][i].ToString();

                                string col2 = dValues.Values[r][i + 1].ToString();

                                if (col1.ToLower() != "null" && col2.ToLower() == "null")

                                {

                                    gValue = dValues.Values[r][Column].ToString();

                                    generatedDataRow = r + 1;

                                    break;

                                }

                            }

                        }

                    }

                }

            }


            if (gValue == null)

                throw new Exception("Unable to retrieve client that matches user " + username + " from the data generation file or matches the search criteria, please check your data generation file");



            return gValue;

        }

    }

}