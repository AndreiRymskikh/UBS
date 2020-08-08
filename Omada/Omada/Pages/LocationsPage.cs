using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace UBS.Pages
{
    public class LocationsPage : BasePage
    {
        private By Map => By.XPath("//div[@id = 'main']//div[contains(@class, 'map-region')]");

        public LocationsPage(IWebDriver driver) : base(driver) { }

        public bool IsMapDisplayed()
        {
            return driver.FindElement(Map).Displayed;
        }
    }
}