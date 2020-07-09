using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SeleniumBasics.Pages.HomePage
{
    public partial class HomePage : BasePage
    {
        public HomePage(IWebDriver Driver):base(Driver)
        {
               
        }
        public string GetTheNavigationOptionName(int number)
        {
            string navigationOptionName = NavigationOptions[number].Text;
            return navigationOptionName;
        }

        public void ClickNavigationOption(int number)
        {
            NavigationOptions[number].Click();
        }
    }
}
