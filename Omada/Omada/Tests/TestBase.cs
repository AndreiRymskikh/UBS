using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Omada.WebCore;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;
using System.Threading;

namespace Omada.Tests
{
    public class TestBase
    {
        protected IWebDriver driver;

        [SetUp]
        public void StartUp()
        {
            Browser browser = new Browser();
            browser.Start();
            driver = browser.driver;
        }

        public void SelectValueFromDropDown(string value, By locator)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(
                     ExpectedConditions.ElementIsVisible(locator));
            var select = driver.FindElement(locator);
            var selectElement = new SelectElement(select);
            selectElement.SelectByText(value);
        }

        public static void PollingWait(
            Func<bool> condition,
            int sleepMilliseconds = 100,
            int timeoutMilliseconds = 1000,
            string failureMessage = null)
        {
            var watch = new Stopwatch();
            watch.Start();

            while (true)
            {

                if (condition()) { return; }

                Thread.Sleep(sleepMilliseconds);

                if (watch.ElapsedMilliseconds > timeoutMilliseconds)
                {
                    if (failureMessage == null)
                    {
                        throw new TimeoutException(
                            message: $"Waited for {timeoutMilliseconds} milliseconds without success");
                    }

                    throw new TimeoutException(
                        message: $"Waited for {failureMessage} for {timeoutMilliseconds} without success");
                }
            }
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
