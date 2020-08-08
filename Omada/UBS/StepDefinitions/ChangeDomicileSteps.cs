using NUnit.Framework;
using TechTalk.SpecFlow;
using UBS.Pages;

namespace UBS.StepDefinitions
{
    [Binding, Scope(Feature = "Change Domicile")]
    public class ChangeDomicileSteps : CommonSteps
    {
        [Given(@"Home Page opened")]
        public void GivenHomePageOpened()
        {
            new HomePage(driver).ClickAgryToAllButton();
        }
        
        [When(@"domiciles choosen (.*), (.*)")]
        public void WhenDomicilesChoosen(string continent, string country)
        {
            new HomePage(driver).SelectDomiciles(continent, country);
        }

        [Then(@"I can read (.*) info about the company")]
        public void ThenICanReadInfoAboutTheCompany(string title)
        {
            Assert.True(new HomePage(driver).IsTitleDisplayed(title), $"The title '{title}' " +
                "is not displayed");
        }
    }
}
