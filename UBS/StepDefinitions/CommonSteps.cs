using OpenQA.Selenium;
using TechTalk.SpecFlow;
using UBS.WebCore;

namespace UBS.StepDefinitions
{
    public class CommonSteps
    {
        protected IWebDriver driver;

        [BeforeScenario]
        public void Before()
        {
            Browser browser = new Browser();
            browser.Start();
            driver = browser.driver;
        }

        [AfterScenario]
        public void After()
        {
            driver.Quit();
        }
    }
}
