using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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

        ///<summary>Select value from 'ul' dropdown</summary>
        ///<param name="option">Option to chose</param>
        ///<param name="dropDown">'ul' element locator</param>
        ///<param name="item">'li' element locator</param>
        public void SelectValueFromDropDown(string option, By dropDown, By item)
        {
            driver.FindElement(dropDown).Click();
            ReadOnlyCollection<IWebElement> options = driver.FindElements(item);
            string text;

            foreach (IWebElement opt in options)
            {
                text = opt.Text;
                if (text == option)
                {
                    opt.Click();
                    return;
                }                
            }
            throw new NoSuchElementException("Can't find " + option + " in dropdown");
        }

        ///<summary>Select value from 'select' dropdown</summary>
        ///<param name="value">Value to chose</param>
        ///<param name="selectLocator">'select' element locator</param>
        public void SelectValueFromDropDown(string value, By selectLocator)
        {
            var select = driver.FindElement(selectLocator);
            var selectElement = new SelectElement(select);
            selectElement.SelectByText(value);
        }
    }
}
