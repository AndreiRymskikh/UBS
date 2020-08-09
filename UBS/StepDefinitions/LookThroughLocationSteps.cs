using NUnit.Framework;
using TechTalk.SpecFlow;
using UBS.Pages;

namespace UBS.StepDefinitions
{
    [Binding, Scope(Feature = "Look through location")]
    public class LookThroughLocationSteps : CommonSteps
    {
        [Given(@"Location page opened")]
        public void GivenLocationPageOpened()
        {
            var homePage = new HomePage(driver);
            homePage.ClickAgryToAllButton();
            homePage.ClickLocationsNavButton();
        }
        
        [When(@"Header '(.*)' is displayed")]
        public void WhenHeaderIsDisplayed(string header)
        {
            Assert.True(new LocationsPage(driver).IsHeaderDisplayed(header), $"The header '{header}' " +
                "is not displayed");
        }
        
        [Then(@"I can see the map")]
        public void ThenICanSeeTheMap()
        {
            Assert.True(new LocationsPage(driver).IsMapDisplayed(), $"The map is not displayed");
        }
    }
}
