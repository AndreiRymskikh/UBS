using OpenQA.Selenium;
using UBS.TestData;

namespace UBS.Pages
{
    public class ContactUsPage : BasePage
    {
        private By Mr => By.Id("Title_2");
        private By Mrs => By.Id("Title_1");
        private By FirstNameField => By.Id("Firstname");
        private By LastNameField => By.Id("Lastname");
        private By AddressField => By.Id("Address");
        private By PhoneField => By.Id("Phone");
        private By EmailField => By.Id("Email");
        private By CityField => By.Id("City");
        private By PostalCodeField => By.Id("Zip");
        private By ConcernField => By.Id("Concern");
        private By Confirmation => By.Id("AcceptDisclaimer_1");
        private By CountryDropDown => By.Id("Country");
        private By RegionDropDown => By.Id("Region");

        public ContactUsPage(IWebDriver driver) : base(driver) { }

        public void FillContactUsForm()
        {
            var userData = new GenerateData().UserData;

            driver.FindElement(userData.Mr ? Mr : Mrs).Click();
            driver.FindElement(FirstNameField).SendKeys(userData.FirstName);
            driver.FindElement(LastNameField).SendKeys(userData.LastName);
            driver.FindElement(AddressField).SendKeys(userData.Address);
            driver.FindElement(PhoneField).SendKeys(userData.Phone);
            driver.FindElement(EmailField).SendKeys(userData.Email);
            driver.FindElement(CityField).SendKeys(userData.City);
            driver.FindElement(PostalCodeField).SendKeys(userData.PostalCode);

            SelectValueFromDropDown("Poland", CountryDropDown);
            SelectValueFromDropDown("Americas", RegionDropDown);

            driver.FindElement(ConcernField).SendKeys(userData.Note);

            driver.FindElement(Confirmation).Click();
        }

        public bool ImitateFormSubmit()
        {
            //I decided that will be better not to submit the form
            //let it be at least imitation
            return true;
        }
    }
}