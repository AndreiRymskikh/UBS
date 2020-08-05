﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace Omada.Pages
{
    class CareersPage
    {
        private IWebDriver driver;
        private By GlobalLocator => By.XPath("//li/a[text()='GLOBAL']");
        private By RomanialLocator => By.XPath("//li/a[text()='ROMANIA']");
        private By ShowAllJobsButtonLocator => By.CssSelector("a.content-loader-button.load-more-button");
        private By ViewOpenPositionsButtonLocator => By.CssSelector("a.mSubmit.mForm__btn-green");
        private By VacancyBlockLocator => By.CssSelector("a.vacancies-blocks-item-header.ability-link");
        public By LanguageDropDown => By.XPath("//select[@name = 'language']");

        public CareersPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickGlobal()
        {
           var global = driver.FindElement(GlobalLocator);
           global.Click();
        }

        public void ClickRomania()
        {
            var romania = driver.FindElement(RomanialLocator);
            romania.Click();
        }

        public void ClickShowAllJobsButton()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(15)).Until(
                     ExpectedConditions.ElementExists(ShowAllJobsButtonLocator));
            var btn = driver.FindElement(ShowAllJobsButtonLocator);
            driver.ExecuteJavaScript<object>("arguments[0].scrollIntoView(true);", btn);
            btn.Click();
        }

        public void ClickViewOpenPositionsButton()
        {     
            var btn = driver.FindElement(ViewOpenPositionsButtonLocator);
            btn.Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        public int CountVacancies()
        {
            var vacancies = driver.FindElements(VacancyBlockLocator);
            return vacancies.Count;
        }
    }
}