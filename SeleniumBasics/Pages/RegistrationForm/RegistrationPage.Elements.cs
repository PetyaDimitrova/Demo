using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumBasics.Pages
{
    public partial class RegistrationPage : BasePage
    {
        public IWebElement FirstName => Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("customer_firstname")));
        public IWebElement LastName => Driver.FindElement(By.Name("customer_lastname"));
        public  IWebElement Password => Driver.FindElement(By.Name("passwd"));
        public IWebElement Address => Driver.FindElement(By.Name("address1"));
        public  IWebElement City => Driver.FindElement(By.Id("city"));
        public IWebElement ZipCode => Driver.FindElement(By.Id("postcode"));
        public IWebElement StateField => Driver.FindElement(By.Id("id_state"));
        public IWebElement PhoneNumber => Driver.FindElement(By.Name("phone_mobile"));
       public IWebElement SubmitButton => Driver.FindElement(By.Id("submitAccount"));

    }
}
