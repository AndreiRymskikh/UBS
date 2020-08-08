using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace UBS.Pages
{
    public class LocationsPage : BasePage
    {
        private By Map => By.XPath("//div[@id = 'main']//div[contains(@class, 'map-region')]");

        public LocationsPage(IWebDriver driver) : base(driver) { }

        public bool IsMapDisplayed()
        {
            try 
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(Map));
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}