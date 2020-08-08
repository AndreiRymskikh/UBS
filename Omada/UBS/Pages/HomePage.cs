using OpenQA.Selenium;
using UBS.WebCore;

namespace UBS.Pages
{
    public class HomePage : BasePage
    {
        private By LocationsNavButton => By.XPath("//ul[@id = 'metanavigation']//a[contains(text(), 'Locations')]");
        private By AgreeToAllButton => By.XPath("//button//*[text() = 'Agree to all']");
        private By SelectDomicileButton => By.CssSelector("#domicileButton");
        private By Title(string text) => By.XPath($"//div[@class = 'header__title']//span[text() = '{text}']");
        public By RegionDropDown => By.XPath("//ul[contains(@class, 'list--region')]/preceding-sibling::button");
        public By RegionItem => By.XPath("//ul[contains(@class, 'list--region')]/li");
        public By CountryDropDown => By.XPath("//li[contains(@class, 'item--country')]/ul/preceding-sibling::button");
        public By CountryItem => By.XPath("//li[contains(@class, 'item--country')]/ul/li");

        public HomePage(IWebDriver driver) : base(driver) { }

        public void ClickLocationsNavButton()
        {
            var global = driver.FindElement(LocationsNavButton);
            global.Click();
        }

        public void ClickAgryToAllButton()
        {
            driver.SwitchTo().Frame(0);
            var agryToAllButton = driver.FindElement(AgreeToAllButton);
            agryToAllButton.Click();
            new Browser(driver).WaitForElementInvisible(AgreeToAllButton);
            driver.SwitchTo().DefaultContent();
        }

        public void SelectDomiciles(string region, string country)
        {
            var global = driver.FindElement(SelectDomicileButton);
            global.Click();
            new Browser(driver).WaitForElementClickable(RegionDropDown);

            SelectValueFromDropDown(region, RegionDropDown, RegionItem);
            SelectValueFromDropDown(country, CountryDropDown, CountryItem);
        }

        public bool IsTitleDisplayed(string text)
        {
            return driver.FindElement(Title(text)).Displayed;
        }
    }
}