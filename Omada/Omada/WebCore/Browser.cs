using System;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Extensions.Configuration.Json;
using System.Reflection;

namespace Omada.WebCore
{
    internal class Browser
    {
        public IWebDriver driver;

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
            goToPage(browserUrl);
        }

        public void StartBrowser(string browser)
        {
            switch (browser)
            {
                case "Firefox":
                    driver = new OpenQA.Selenium.Firefox.FirefoxDriver();
                    driver.Manage().Window.Size = new Size(1920, 1080);
                    break;
                case "Chorme":
                    ChromeOptions optionsCh = new ChromeOptions();
                    optionsCh.AddArguments("--start-maximized");
                    optionsCh.AddArgument("-no-sandbox");
                    driver = new ChromeDriver("C:\\Tools", optionsCh, TimeSpan.FromMinutes(2));
                    break;
                default:
                    throw new Exception("Browser was not initialized");
            }
        }
        public void goToPage(string url)
        {

            driver.Navigate().GoToUrl(url);
        }
    }
}
