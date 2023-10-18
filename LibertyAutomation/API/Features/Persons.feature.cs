﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace LibertyAutomation.API.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Persons")]
    public partial class PersonsFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "Persons.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "API/Features", "Persons", "A short summary of the feature", ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 5
#line hidden
#line 6
 testRunner.Given("that the required headers are loaded from \"TestData\\\\API\\\\LibertyConfig.json\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 7
    testRunner.And("the certificate is loaded from \"Cert\\\\Mulesoft_Non_Prod.pfx\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 8
    testRunner.And("the certificate has a valid password \"12345\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("[Verify GET Persons_ID API service]")]
        [NUnit.Framework.TestCaseAttribute("Persons PersonsID", "/api/Persons/", "273366", null)]
        [NUnit.Framework.TestCaseAttribute("Persons PersonsID", "/api/Persons/", "11542", null)]
        public void VerifyGETPersons_IDAPIService(string service, string uri, string personId, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("Service", service);
            argumentsOfScenario.Add("Uri", uri);
            argumentsOfScenario.Add("PersonId", personId);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("[Verify GET Persons_ID API service]", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 10
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 5
this.FeatureBackground();
#line hidden
#line 11
    testRunner.When(string.Format("the user makes a GET request to Persons_ID Service \"{0}\" with valid \"{1}\" as para" +
                            "meter", uri, personId), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 12
    testRunner.Then("the user is presented with Persons_ID information and a success status code", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("[Verify GET Person contact API service]")]
        [NUnit.Framework.TestCaseAttribute("Persons", "/api/Persons?emailAddress=", "PAYROLL@HOLLYWOODBETS.NET", null)]
        public void VerifyGETPersonContactAPIService(string service, string uri, string emailAddress, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("Service", service);
            argumentsOfScenario.Add("Uri", uri);
            argumentsOfScenario.Add("emailAddress", emailAddress);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("[Verify GET Person contact API service]", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 19
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 5
this.FeatureBackground();
#line hidden
#line 20
    testRunner.When(string.Format("the user makes a GET request to Persons_ID Service \"{0}\" with valid \"{1}\" as para" +
                            "meter", uri, emailAddress), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 21
    testRunner.Then("the user is presented with Person information and a success status code", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify Error message displayed when incorrect Person ID is captured on Persons_ID" +
            " API service")]
        [NUnit.Framework.CategoryAttribute("Negetive")]
        [NUnit.Framework.TestCaseAttribute("Persons PersonsID", "/api/Persons/", "4", null)]
        public void VerifyErrorMessageDisplayedWhenIncorrectPersonIDIsCapturedOnPersons_IDAPIService(string service, string uri, string invalidPersonID, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Negetive"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("Service", service);
            argumentsOfScenario.Add("Uri", uri);
            argumentsOfScenario.Add("invalidPersonID", invalidPersonID);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify Error message displayed when incorrect Person ID is captured on Persons_ID" +
                    " API service", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 28
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 5
this.FeatureBackground();
#line hidden
#line 29
    testRunner.When(string.Format("the user makes a GET request to Persons_ID Service \"{0}\" with invalid \"{1}\" as pa" +
                            "rameter", uri, invalidPersonID), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 30
    testRunner.Then("the user is presented with a person not found error message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify Error message displayed when incorrect Email address is captured on Person" +
            "s API service")]
        [NUnit.Framework.CategoryAttribute("Negetive")]
        [NUnit.Framework.TestCaseAttribute("Organizations", "/api/Persons?emailAddress=", "ts@ymail.com", null)]
        public void VerifyErrorMessageDisplayedWhenIncorrectEmailAddressIsCapturedOnPersonsAPIService(string service, string uri, string emailAddress, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Negetive"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("Service", service);
            argumentsOfScenario.Add("Uri", uri);
            argumentsOfScenario.Add("emailAddress", emailAddress);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify Error message displayed when incorrect Email address is captured on Person" +
                    "s API service", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 38
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 5
this.FeatureBackground();
#line hidden
#line 39
    testRunner.When(string.Format("the user makes a GET request to Persons Service \"{0}\" with invalid \"{1}\" as param" +
                            "eter", uri, emailAddress), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 40
    testRunner.Then("the user is presented with a person not found error message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify Error message displayed when incorrect First Name is captured on Persons A" +
            "PI service")]
        [NUnit.Framework.CategoryAttribute("Negetive")]
        [NUnit.Framework.TestCaseAttribute("Organizations", "/api/Persons?firstName=", "1nameTest", null)]
        public void VerifyErrorMessageDisplayedWhenIncorrectFirstNameIsCapturedOnPersonsAPIService(string service, string uri, string invalidName, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Negetive"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("Service", service);
            argumentsOfScenario.Add("Uri", uri);
            argumentsOfScenario.Add("invalidName", invalidName);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify Error message displayed when incorrect First Name is captured on Persons A" +
                    "PI service", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 47
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 5
this.FeatureBackground();
#line hidden
#line 48
    testRunner.When(string.Format("the user makes a GET request to Persons Service Name \"{0}\" with invalid \"{1}\" as " +
                            "parameter", uri, invalidName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 49
    testRunner.Then("the user is presented with a person not found error message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("[Verify GET persons profile API service]")]
        [NUnit.Framework.TestCaseAttribute("Persons PersonsID Profiles", "api/Persons//Profiles", "4182867", null)]
        public void VerifyGETPersonsProfileAPIService(string service, string uri, string personId, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("Service", service);
            argumentsOfScenario.Add("Uri", uri);
            argumentsOfScenario.Add("PersonId", personId);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("[Verify GET persons profile API service]", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 56
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 5
this.FeatureBackground();
#line hidden
#line 57
    testRunner.When(string.Format("the user makes a GET request to Persons_ID Service Profiles \"{0}\" with valid \"{1}" +
                            "\" as parameter", uri, personId), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 58
    testRunner.Then("the user is presented with Persons_ID information and a success status code", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
