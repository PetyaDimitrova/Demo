using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumBasics.Tests.AutomationPractice;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace SeleniumBasics.Pages
{
    public partial class RegistrationPage : BasePage
    {
        public RegistrationPage(IWebDriver driver) 
            :base(driver)
        {

        }

        public void FillRegistrationForm(RegistrationUser user)
        {
            FirstName.SendKeys(user.FirstName);
            LastName.SendKeys(user.LastName);
            Password.SendKeys(user.Password);
            Address.SendKeys(user.Address);
            City.SendKeys(user.City);
            ZipCode.SendKeys(user.ZipCode);
            //state dropdown
            SelectElement statesList = new SelectElement(StateField);
            statesList.SelectByText(user.State);
            PhoneNumber.SendKeys(user.Phone);
            SubmitButton.Click();
        }   

    }
}
