using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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

        public void SelectValueFromDropDown(string option, By dropDown, By item)
        {
            driver.FindElement(dropDown).Click();
            ReadOnlyCollection<IWebElement> options = driver.FindElements(item);
            
            foreach (IWebElement opt in options)
            {
                if (opt.Text.Equals(option))
                {
                    opt.Click();
                    return;
                }
            }
            throw new NoSuchElementException("Can't find " + option + " in dropdown");
        }
    }
}
