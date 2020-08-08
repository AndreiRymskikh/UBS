using OpenQA.Selenium;

namespace UBS.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;
        private By Header(string text) => By.XPath($"//header//h1[text() = '{text}']");

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool IsHeaderDisplayed(string text)
        {
            return driver.FindElement(Header(text)).Displayed;
        }
    }
}
