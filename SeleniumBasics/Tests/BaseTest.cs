using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumBasics.Tests
{
   public class BaseTest
    {
        public IWebDriver Driver { get; set; }
        public Actions Builder{ get; set; }

        public void Initialize()
        {
            Driver = new ChromeDriver();
            Builder = new Actions(Driver);

        }
    }
}
