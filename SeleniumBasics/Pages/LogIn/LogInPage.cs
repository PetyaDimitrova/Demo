using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumBasics.Pages
{
   
    public class LogInPage : BasePage
    {
        
        public LogInPage(IWebDriver driver)
            : base(driver)
        {

        }

        public IWebElement SignInLink => Wait.Until<IWebElement>(d => d.FindElement(By.XPath("//*[@id='header']/div[2]/div/div/nav/div[1]/a")));
        public IWebElement EmailField => Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/div[1]/form/div/div[2]/input[@id ='email_create']")));
        public IWebElement SubmitButton => Driver.FindElement(By.XPath("//*[@id='SubmitCreate']/span"));

        public void LogIn()
        {
            SignInLink.Click();
            EmailField.SendKeys("petyad86@gmail.com");
            SubmitButton.Click();
        }




    }
}
