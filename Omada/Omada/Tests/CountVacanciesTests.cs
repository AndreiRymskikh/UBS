using NUnit.Framework;
using OpenQA.Selenium;
using Omada.Pages;

namespace Omada.Tests
{
    public class CountVacanciesTests : TestBase
    {
        [Datapoint]
        private readonly int vacanciesQttyExpected = 34;

        [Datapoint]
        private readonly string language = "English";

        [Test]
        [Theory]
        public void CountVacanciesTest(int vacanciesQtty, string language)
        {
            var careerPage = new CareersPage(driver);
            careerPage.ClickGlobal();
            careerPage.ClickRomania();
            SelectValueFromDropDown(language, careerPage.LanguageDropDown);
            careerPage.ClickViewOpenPositionsButton();
            careerPage.ClickShowAllJobsButton();

            if (vacanciesQtty > 6)
            {
                PollingWait(() => careerPage.CountVacancies() > 6, timeoutMilliseconds: 5000);
            }

            var aa = careerPage.CountVacancies();

            Assert.IsTrue(careerPage.CountVacancies() == vacanciesQtty, $"Wrong quantity of vacancies. Expected {vacanciesQtty}");
        }
    }
}