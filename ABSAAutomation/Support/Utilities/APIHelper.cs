
using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using ABSAAutomation.Utilities;
using System.Net.Http;
using System.Net;
using System.Web;
using TechTalk.SpecFlow;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using GoogleSheetsHelper;//Added O Snyman
using System.Data;//Added O Snyman
using Microsoft.Graph;
using System.Text.RegularExpressions;
using ABSAAutomation.Hooks;
using RestSharp;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

using File = System.IO.File;
using NUnit.Framework;
using TechTalk.SpecFlow.Infrastructure;

namespace ABSAAutomation.Utilities
{   
    public class APIHelper
    {

        private static string token;
        TestBase tBase;
        DataHelpers dat = new DataHelpers();
        private ActionHelper actionH;
        TestBase gsh;
        ITakesScreenshot screenshots;

        public APIHelper()
        {
            gsh = new TestBase();
        }

        public string[] getAPIRequest(String apiEndpoint, String jsonRequestHeaders)
        {
            JObject jsonObject = JObject.Parse(File.ReadAllText(Absa.sPath + jsonRequestHeaders));


            String fullApiEndpoint = config.ApiURL + apiEndpoint;

            string[] strArrResponse = new string[2];

            var options = new RestClientOptions(fullApiEndpoint)
            {
                MaxTimeout = -1,
            };

            RestRequest request = new RestRequest(fullApiEndpoint, Method.Get);

            foreach (var pair in jsonObject)
            {
                request.AddHeader(pair.Key.ToString(), pair.Value.ToString());

            }



            strArrResponse[1] = null;

            return strArrResponse;
        }


        public string[] getRestRequest(String apiEndpoint, String certFilePath, String certPassword, String jsonRequestHeaders)
        {
            JObject jsonObject = JObject.Parse(File.ReadAllText(Absa.sPath + jsonRequestHeaders));


            String fullApiEndpoint = config.ApiURL + apiEndpoint; 

            string[] strArrResponse = new string[2];

            var options = new RestClientOptions(fullApiEndpoint)
            {
                MaxTimeout = -1,
            };
            string fullCertPath = Absa.sPath + certFilePath;

            X509Certificate2 certificate = new X509Certificate2(fullCertPath, certPassword);

            options.ClientCertificates = new X509CertificateCollection() { certificate };
            options.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

            RestClient client = new RestClient(options);

            RestRequest request = new RestRequest(fullApiEndpoint, Method.Get);

            foreach ( var pair in jsonObject)
            {
                request.AddHeader(pair.Key.ToString(), pair.Value.ToString());

            }

            RestResponse response = client.Execute(request);

            strArrResponse[0] = response.Content;

            strArrResponse[1] = response.StatusCode.ToString();

            return strArrResponse;
        }

        public String[] PostSOAPRequest(HttpWebRequest request, String sPath, WorkbookRange dt, int iRow, String SBSCall, string optionalstr = "", string optionalstr2 = "", string optionalstr3 = "", string optionalstr4 = "")
        {
           // api = new .API.APICallSpecific();
            String[] soapResponse = new string[2];
            string sSOAPPath = Absa.sPath + sPath;
            XmlDocument doc = new XmlDocument();
            doc.Load((sSOAPPath));
          //  doc = api.ManipulatePayLoad(doc, dt, iRow, SBSCall, optionalstr, optionalstr2, optionalstr3, optionalstr4); //Calls a method that updates the XML payload with data from the Google Sheet
            // add our body to the request
            Stream stream = request.GetRequestStream();
            doc.Save(stream);
            stream.Close();

            try
            {
                // get the response back
                using (HttpWebResponse response = (HttpWebResponse)
                    request.GetResponse())
                {
                    using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                    {
                        soapResponse[0] = rd.ReadToEnd();
                        soapResponse[1] = response.StatusCode.ToString();
                    }

                }
            }
            catch (WebException webex)
            {
                WebResponse errResp = webex.Response;
                using (Stream respStream = errResp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(respStream);
                    string text = reader.ReadToEnd();
                    Console.WriteLine("text");
                    soapResponse[0] = "ERROR";
                    soapResponse[1] = text;
                }

            }
            return soapResponse;
        }

        public XmlDocument updateXMLDoc(string sPath, string[] sElementToUpdate, string[] sElementTtoUpdateWith)
        {

            StringBuilder sb = new StringBuilder();
            XmlWriterSettings xws = new XmlWriterSettings();
            xws.OmitXmlDeclaration = true;
            xws.Indent = true;
            string sUpdateXMLPath = Absa.sPath + sPath;
            XElement x;

            using (XmlWriter xw = XmlWriter.Create(sb, xws))
            {




                x = XElement.Parse(sUpdateXMLPath);

                for (int i = 0; i < sElementToUpdate.Length; i++)
                {
                    var test = x.Element(sElementToUpdate[i]);
                    test.Value = sElementTtoUpdateWith[i];




                    x.WriteTo(xw);

                }


            }


            Console.WriteLine(sb.ToString());


            XmlDocument doc = new XmlDocument();
            doc.Load(sb.ToString());
            return doc;


        }

        public static XmlDocument ReplaceInFile(string[] searchText, string[] replaceText, string spath)
        {
            String Path = System.AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Absa.sPath + "TestData\\Advisor\\CreateNewAdvisor.txt";

            var content = string.Empty;
            using (StreamReader reader = new StreamReader(filePath))
            {
                content = reader.ReadToEnd();
                reader.Close();
            }
            for (int i = 0; i < searchText.Length; i++)
            {
                content = content.Replace(searchText[i], replaceText[i]);
            }

            string xmlSource = content;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlSource);
            return xmlDoc;


        }

        public void UpdateJSONArray(String sfieldJSONArray, string[] sdatatoUpdate, string []sdatatoUpdateWith,string sFilePath)
        {
            string jsonString = null;
            string json = System.IO.File.ReadAllText(Absa.sPath + sFilePath);
            dynamic jsonObj = JsonConvert.DeserializeObject(json);
            for (int i = 0; i < sdatatoUpdate.Length; i++)
            { 
                        if(sdatatoUpdateWith[i].ToUpper().Contains("FALSE")|| sdatatoUpdateWith[i].ToUpper().Contains("TRUE"))
                            jsonObj[sfieldJSONArray][0][sdatatoUpdate[i]] = Convert.ToBoolean(sdatatoUpdateWith[i]);
                       // else if (sdatatoUpdateWith[i].All(char.IsDigit))
                       //     jsonObj[sfieldJSONArray][0][sdatatoUpdate[i]] = Convert.ToInt32(sdatatoUpdateWith[i]);
                        else
                            jsonObj[sfieldJSONArray][0][sdatatoUpdate[i]] = sdatatoUpdateWith[i].ToString();
             }
            jsonString = JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
            System.IO.File.WriteAllText(Absa.sPath + sFilePath, jsonString);
        }

        public void UpdateJSON(string[] sdatatoUpdate, string[] sdatatoUpdateWith, string sFilePath)
        {
            string jsonString = null;
            string json = System.IO.File.ReadAllText(Absa.sPath + sFilePath);
            dynamic jsonObj = JsonConvert.DeserializeObject(json);
            for (int i = 0; i < sdatatoUpdate.Length; i++)
            {
                if (sdatatoUpdateWith[i].ToUpper().Contains("FALSE") || sdatatoUpdateWith[i].ToUpper().Contains("TRUE"))
                    jsonObj[sdatatoUpdate[i]] = Convert.ToBoolean(sdatatoUpdateWith[i]);
               // else if (sdatatoUpdateWith[i].All(char.IsDigit))
                //    jsonObj[sdatatoUpdate[i]] = Convert.ToInt32(sdatatoUpdateWith[i]);
                else

                    jsonObj[sdatatoUpdate[i]] = sdatatoUpdateWith[i];
            }
            jsonString = JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
            System.IO.File.WriteAllText(Absa.sPath + sFilePath, jsonString);
        }

        public string [] postRestRequest(string sURL, string sFilePath, string sMemAPIKey)
        {
            string[] strArrResponse = new string[2];
            RestClient client = new RestClient(sURL);
            RestRequest request = new RestRequest(sURL, Method.Post);
    
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Mem-Api-Key", sMemAPIKey);
    
            // var body = new
            string json = System.IO.File.ReadAllText(Absa.sPath+sFilePath);
           // dynamic jsonObj = JsonConvert.DeserializeObject(json);
            //jsonObj["requestUtcTime"] = DateTime.UtcNow.ToString("s") + "Z";
          //  string jsonString = JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);


            request.AddJsonBody(json);

            var response = client.Execute(request);
            strArrResponse[0] = response.Content;
            strArrResponse[1] = response.StatusCode.ToString();
            return strArrResponse;
        }

        public string[] getRestRequest(String sURL, string sMemAPIKey)
        {
            string[] strArrResponse = new string[2];
            RestClient client = new RestClient(sURL);
            RestRequest request = new RestRequest(sURL, Method.Get);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Mem-Api-Key", sMemAPIKey);
            var response = client.Execute(request);
            strArrResponse[0] = response.Content;
            strArrResponse[1] = response.StatusCode.ToString();
            return strArrResponse;

        }
        public String[] PostSOAPRequest2(HttpWebRequest request, String sPath, int iRow, WorkbookRange dTable)
        {

            String[] soapResponse = new string[2];

            String[] dataToUpdatewith = { gsh.GetCellValue(dTable, "FirstName", iRow), gsh.GetCellValue(dTable, "Surname", iRow), gsh.GetCellValue(dTable, "Gender", iRow), gsh.GetCellValue(dTable, "Title", iRow), gsh.GetCellValue(dTable, "DateOfBirth", iRow), gsh.GetCellValue(dTable, "MobilePhone", iRow), gsh.GetCellValue(dTable, "Country", iRow), gsh.GetCellValue(dTable, "Email", iRow) };
            String[] dataToUpdate = { "$FirstName", "$Surname", "$Gender", "$Title", "$DateOfBirth", "$MobilePhone", "$Country", "$Email" };
            // add our body to the request
            string sUpdateSOAPPath = Absa.sPath + sPath;

            var xmldoc = ReplaceInFile(dataToUpdate, dataToUpdatewith, sUpdateSOAPPath);
            // XmlDocument doc = new XmlDocument();
            // doc.Load((Path));
            Stream stream = request.GetRequestStream();
            xmldoc.Save(stream);
            stream.Close();

            try
            {
                // get the response back
                using (HttpWebResponse response = (HttpWebResponse)
                    request.GetResponse())
                {
                    using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                    {
                        soapResponse[0] = rd.ReadToEnd();
                        soapResponse[1] = response.StatusCode.ToString();
                    }

                }
            }
            catch (WebException webex)
            {
                WebResponse errResp = webex.Response;
                using (Stream respStream = errResp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(respStream);
                    string text = reader.ReadToEnd();
                    Console.WriteLine("text");
                    soapResponse[0] = "ERROR";
                    soapResponse[1] = text;
                }

            }
            return soapResponse;
        }

        public HttpWebRequest CreateWebRequest(String sURL, String sSOAPAction)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sURL);
            // add the headers
            // the SOAPACtion determines what action the web service should use
            // YOU MUST KNOW THIS and SET IT HERE
            request.Headers.Add("SOAPAction", sSOAPAction);

            // set the request type
            // we user utf-8 but set the content type here
            request.ContentType = "text/xml;charset=\"utf-8\"";
            request.Accept = "text/xml";
            request.Method = "POST";
            return request;

        }

        public class Status
        {
            public string name { get; set; }
            public int id { get; set; }
            public string description { get; set; }
            public string color { get; set; }
            public int type { get; set; }
        }

        public class Execution2
        {
            public string id { get; set; }
            public int issueId { get; set; }
            public int versionId { get; set; }
            public int projectId { get; set; }
            public string cycleId { get; set; }
            public int orderId { get; set; }
            public string executedBy { get; set; }
            public string executedByAccountId { get; set; }
            public object executedOn { get; set; }
            public string modifiedBy { get; set; }
            public string modifiedByAccountId { get; set; }
            public string createdBy { get; set; }
            public string createdByAccountId { get; set; }
            public Status status { get; set; }
            public string cycleName { get; set; }
            public List<object> defects { get; set; }
            public List<object> stepDefects { get; set; }
            public int executionDefectCount { get; set; }
            public int stepDefectCount { get; set; }
            public int totalDefectCount { get; set; }
            public object creationDate { get; set; }
            public bool executedByZapi { get; set; }
            public string zfjIndexType { get; set; }
            public int issueTypeId { get; set; }
            public string projectType { get; set; }
            public int issueIndex { get; set; }
            public string projectCycleVersionIndex { get; set; }
            public int executionStatusIndex { get; set; }
            public string projectIssueCycleVersionIndex { get; set; }
            public string comment { get; set; }
            public string folderId { get; set; }
            public string folderName { get; set; }
        }

        public class Execution
        {
            public object warningMessage { get; set; }
            public object originMessage { get; set; }
            public Execution2 execution { get; set; }
            public string issueKey { get; set; }
            public string issueLabel { get; set; }
            public object component { get; set; }
            public string issueSummary { get; set; }
            public string issueDescription { get; set; }
            public string projectName { get; set; }
            public string versionName { get; set; }
            public string priority { get; set; }
            public object priorityIconUrl { get; set; }
            public object executedByDisplayName { get; set; }
            public object assigneeType { get; set; }
            public object assignedToDisplayName { get; set; }
            public object testStepBeans { get; set; }
            public string defectsAsString { get; set; }
            public string projectKey { get; set; }
            public object plannedExecutionTimeFormatted { get; set; }
            public object actualExecutionTimeFormatted { get; set; }
            public object executionWorkflowStatus { get; set; }
            public string workflowLoggedTimedIncreasePercentage { get; set; }
            public string workflowCompletePercentage { get; set; }
            public bool versionReleased { get; set; }
            public object customFieldValuesAsString { get; set; }
            public bool viewIssuePermission { get; set; }
            public bool executionWorkflowEnabled { get; set; }
        }

        public class _1
        {
            public string name { get; set; }
            public int id { get; set; }
            public string description { get; set; }
            public string color { get; set; }
            public int type { get; set; }
        }

        public class _2
        {
            public string name { get; set; }
            public int id { get; set; }
            public string description { get; set; }
            public string color { get; set; }
            public int type { get; set; }
        }

        public class _3
        {
            public string name { get; set; }
            public int id { get; set; }
            public string description { get; set; }
            public string color { get; set; }
            public int type { get; set; }
        }

        public class _4
        {
            public string name { get; set; }
            public int id { get; set; }
            public string description { get; set; }
            public string color { get; set; }
            public int type { get; set; }
        }

        public class ExecutionStatus
        {
            public _1 _1 { get; set; }
            public _2 _2 { get; set; }
            public _3 _3 { get; set; }
            public _4 _4 { get; set; }
        }
        public class Root
        {
            public int maxAllowed { get; set; }
            public List<Execution> executions { get; set; }
            public int currentOffset { get; set; }
            public ExecutionStatus executionStatus { get; set; }
            public int totalCount { get; set; }

        }

    }
}
