using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumBasics.Pages.HomePage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SeleniumBasics.Tests.DemoQA
{
    [TestFixture]
    class Navigation : BaseTest
    {
        //IWebDriver driver;
        //WebDriverWait wait;
        private HomePage _homePage;

        [SetUp]
        public void SetUp()
        {
            Initialize();
            //driver = new ChromeDriver();
            //wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            _homePage = new HomePage(Driver);

            Driver.Navigate().GoToUrl("http://demoqa.com/");
            Driver.Manage().Window.Maximize();
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void NavigateToAllSections(int number)
        {
            //Arrange
            string navigationOptionName = _homePage.GetTheNavigationOptionName(number);

            //Act
            _homePage.ClickNavigationOption(number);
           
            //Assert
            Assert.AreEqual(navigationOptionName, _homePage.Header.Text);
            
        }

        [TearDown]
        public void Quit()
        {
            Driver.Quit();
        }
    }
}
