using System;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;
using OpenQA.Selenium.Support.UI;

namespace UBS.WebCore
{
    public class Browser
    {
        private const int waitElementTimeout = 10;
        public IWebDriver driver;

        public Browser() { }
        public Browser(IWebDriver driver) { this.driver = driver; }

        public void Start()
        {
            //directory searching
            string dirName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            FileInfo fileInfo = new FileInfo(dirName);
            DirectoryInfo parentDir = fileInfo.Directory.Parent.Parent;
            string parentDirName = parentDir.FullName;

            //bring info from appsetings.json
            var config = new ConfigurationBuilder()
                .SetBasePath(parentDirName)
                .AddJsonFile("appsettings.json")
                .Build();

            var browserName = config["ApplicationSettings:Browser"];
            var browserUrl = config["ApplicationSettings:BaseUrl"];

            //browser launching and page opening
            StartBrowser(browserName);
            GoToPage(browserUrl);
        }

        public void StartBrowser(string browser)
        {
            var path = Path.GetDirectoryName(
                    Assembly.GetExecutingAssembly().GetName().CodeBase)?.Replace("file:\\", "");
            switch (browser)
            {
                case "Firefox":
                    driver = new OpenQA.Selenium.Firefox.FirefoxDriver(path);
                    driver.Manage().Window.Size = new Size(1920, 1080);
                    break;
                case "Chorme":
                    ChromeOptions optionsCh = new ChromeOptions();
                    optionsCh.AddArguments("--start-maximized");
                    optionsCh.AddArgument("-no-sandbox");
                    driver = new ChromeDriver(path, optionsCh, TimeSpan.FromMinutes(2));
                    break;
                default:
                    throw new Exception("Browser was not initialized");
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(waitElementTimeout);
        }

        public void GoToPage(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public bool WaitForElementInvisible(By locator,
            int seconds = waitElementTimeout)
        {
            var bResult = false;
            try
            {
                var webElement = driver.FindElement(locator);
                
                if (webElement != null && webElement.Displayed)
                {
                    new WebDriverWait(driver, TimeSpan.FromSeconds(seconds)).Until(
                        SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
                }

                bResult = true;
            }
            catch (NoSuchElementException)
            {
                bResult = true;
            }
            catch (Exception) { }

            return bResult;
        }

        public void WaitForElementClickable(By locator,
           int seconds = waitElementTimeout) 
        { 
            new WebDriverWait(driver, TimeSpan.FromSeconds(seconds)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }
    }
}
