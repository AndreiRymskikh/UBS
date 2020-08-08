using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using UBS.Pages;

namespace UBS.StepDefinitions
{
    [Binding, Scope(Feature = "ContactUs form")]
    public class ContactUsFormSteps : CommonSteps
    {
        [Given(@"Domiciles '(.*)' '(.*)' picked")]
        public void GivenDomicilesOpened(string region, string country)
        {
            var homePage = new HomePage(driver);
            homePage.ClickAgryToAllButton();
            homePage.SelectDomiciles(region, country);
        }
        
        [Given(@"'(.*)' page displayed")]
        public void GivenContactUsFormDisplayed(string pageName)
        {
            var homePage = new HomePage(driver);
            homePage.SelectNavMenu(pageName, "Report misconduct of UBS staff");
            Assert.True(homePage.IsTitleDisplayed(pageName), $"The title '{pageName}' is not displayed");
        }
        
        [When(@"I fill Contact Us form")]
        public void WhenIFillContactUsForm()
        {
            new ContactUsPage(driver).FillContactUsForm();
        }
        
        [Then(@"I can send it to UBS company")]
        public void ThenICanSendItToUBSCompany()
        {
            Assert.IsTrue(new ContactUsPage(driver).ImitateFormSubmit());
        }
    }
}
