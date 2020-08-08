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

        //public void SelectValueFromDropDown(string value, By locator)
        //{
        //    new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(
        //             ExpectedConditions.ElementIsVisible(locator));
        //    var select = driver.FindElement(locator);
        //    var selectElement = new SelectElement(select);
        //    selectElement.SelectByText(value);
        //}

        [AfterScenario]
        public void After()
        {
            driver.Quit();
        }
    }
}
