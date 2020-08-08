using NUnit.Framework;
using TechTalk.SpecFlow;
using UBS.Pages;

namespace UBS.StepDefinitions
{
    [Binding]
    public class LookThroughLocationSteps : CommonSteps
    {
        [Given(@"Location page opened")]
        public void GivenLocationPageOpened()
        {
            new HomePage(driver).ClickLocationsNavButton();
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
