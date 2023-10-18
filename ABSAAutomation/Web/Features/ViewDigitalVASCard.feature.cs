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
namespace LibertyAutomation.Web.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("View digital VAS card")]
    public partial class ViewDigitalVASCardFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "ViewDigitalVASCard.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Web/Features", "View digital VAS card", null, ProgrammingLanguage.CSharp, featureTags);
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
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify that a Member can View Value Added Services Benefits")]
        [NUnit.Framework.CategoryAttribute("R1.1")]
        [NUnit.Framework.TestCaseAttribute("member9@test.com", "true", null)]
        public void VerifyThatAMemberCanViewValueAddedServicesBenefits(string emailAddress, string haveFuneralBenefits, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "R1.1"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("emailAddress", emailAddress);
            argumentsOfScenario.Add("haveFuneralBenefits", haveFuneralBenefits);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify that a Member can View Value Added Services Benefits", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 4
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 6
  testRunner.Given("a member is on the SSP login page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 7
  testRunner.When(string.Format("a member logs in to SSP using \"{0}\"", emailAddress), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 9
  testRunner.And("Navigates to Value Added Services", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                            "vasHeading",
                            "vasDescription"});
                table1.AddRow(new string[] {
                            "24-Hour Health Information Helpline",
                            "Provides you with easy access to medical resources, such as general medical infor" +
                                "mation, lifestyle advice and explanations and interpretations of medical termino" +
                                "logy."});
                table1.AddRow(new string[] {
                            "Emergency Ambulance Assistance",
                            @"In the case of a medical emergency, you can call the 24-Hour Contact Centre where you will be assisted by trained medical personnel, who can provide guidance through a medical crisis situation. For life-threatening medical crisis, an appropriate road and/or air response will be dispatched."});
                table1.AddRow(new string[] {
                            "R5 000 Hospital Admission Guarantee",
                            "Should you or your immediate family be admitted into hospital, and a hospital gua" +
                                "rantee cash payment is required, the 24-Hour Contact Centre can be contacted to " +
                                "cover up to R5 000 (including VAT) of this required payment."});
                table1.AddRow(new string[] {
                            "Legal Assist Helpline",
                            "By contacting the 24-Hour Contact Centre, you can access professional assistance " +
                                "from a panel of qualified lawyers/ attorneys, who will assess the situation, exp" +
                                "lain your rights and advise you of the best course of action to take."});
                table1.AddRow(new string[] {
                            "Trauma Counselling",
                            "Offers you and your immediate family access to trauma counselling, to assist with" +
                                " emotional recovery following a critical incident."});
                table1.AddRow(new string[] {
                            "Funeral Assistance Service",
                            @"A 24-hour service that will assist you and/or your bereaved family members with funeral arrangements and transportation of the deceased to where the funeral will be taking place, provided that the destination is more than 100 km's away from where the deceased's body is being kept. The territories for transportation of the deceased include anywhere within South Africa, Namibia, Mozambique, Botswana, Lesotho, eSwatini and Zimbabwe. Embalming and refrigerated transportation is not part of the service offered."});
#line 10
  testRunner.Then(string.Format("the member is presented with a list of all the services available to them dependi" +
                            "ng on whether they \"{0}\" or not", haveFuneralBenefits), ((string)(null)), table1, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                            "Field",
                            "Value"});
                table2.AddRow(new string[] {
                            "telephonicAccess",
                            "JD 24-Hour Contact Centre (telephonic access) If calling from within South Africa" +
                                ": +27 11 966 5011 If calling from outside of South Africa: 0861 724 247"});
                table2.AddRow(new string[] {
                            "digitalMessaging",
                            "JD 24-Hour Contact Centre (digital messaging access) Digital messaging platform: " +
                                "AccessVAS.liberty.co.za QR code:"});
#line 20
  testRunner.And("contact details are displayed", ((string)(null)), table2, "And ");
#line hidden
#line 26
  testRunner.And("a member can download the contact details", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 27
  testRunner.When("a member clicks on the digital messaging platform link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 28
  testRunner.Then("They are redirected to the access vas page on a new tab.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion