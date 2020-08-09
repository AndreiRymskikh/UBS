using NUnit.Framework;
using System;
using System.Globalization;
using TechTalk.SpecFlow;
using UBS.Pages;
using UBS.Resources;

namespace UBS.StepDefinitions
{
    [Binding, Scope(Feature = "Localization")]
    public class LocalizationSteps : CommonSteps
    {
        [Given(@"Home Page opened")]
        public void GivenHomePageOpened()
        {
            new HomePage(driver).ClickAgryToAllButton();
        }

        [When(@"(.*) language chosen")]
        public void WhenLanguageChosen(string language)
        {
            if (language == "de-De")
                new HomePage(driver).ClickLocalizationButton("DE");
        }
        
        [Then(@"Check (.*) navigation item are displayed")]
        public void ThenCheckNavigationItemAreDisplayed(string language)
        {
            var homePage = new HomePage(driver);
            CultureInfo resourceCulture = new CultureInfo(language);

            var navCareers = translations.Careers(resourceCulture);
            Assert.True(homePage.IsNavDropDownDisplayed(navCareers), $"The navigation dropdown {navCareers} " +
                "is not diaplayed");
            var navWealthManagement  = translations.WealthManagement(resourceCulture);
            Assert.True(homePage.IsNavDropDownDisplayed(navWealthManagement), $"The navigation dropdown {navWealthManagement} " +
                "is not diaplayed");
            var navAssetManagement = translations.AssetManagement(resourceCulture);
            Assert.True(homePage.IsNavDropDownDisplayed(navAssetManagement), $"The navigation dropdown {navAssetManagement} " +
                "is not diaplayed");
            var navAboutUs = translations.AboutUs(resourceCulture);
            Assert.True(homePage.IsNavDropDownDisplayed(navAboutUs), $"The navigation dropdown {navAboutUs} " +
                "is not diaplayed");
            var navInvestmentBank = translations.InvestmentBank(resourceCulture);
            Assert.True(homePage.IsNavDropDownDisplayed(navInvestmentBank), $"The navigation dropdown {navInvestmentBank} " +
                "is not diaplayed");
        }
    }
}
