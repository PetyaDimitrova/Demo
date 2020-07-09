using AutoFixture;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumBasics.Pages;
using SeleniumBasics.Tests;
using SeleniumBasics.Tests.AutomationPractice;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SeleniumBasics
{

    [TestFixture]
    public class Automationpractice : BaseTest
    {
 
        private LogInPage _logInPage;
        private RegistrationPage _registrationPage;
        private RegistrationUser _user;

        [SetUp]
        public void SetUp()
        {
            Initialize();

            _registrationPage = new RegistrationPage(Driver);
            _logInPage = new LogInPage(Driver);
            _user = UserFactory.CreateUser();
            
            Driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            Driver.Manage().Window.Maximize();
            _logInPage.LogIn();
        }

        [Test]
        public void SubmitRegistrationForm_WhenMissingPhoneAndState()
        {
            //Arrange
            _user.Phone = string.Empty;
            _user.State = "-";

            //Act
            _registrationPage.FillRegistrationForm(_user);

            //Assert
            _registrationPage.AssertErrorWhenMissingPhoneAndState();
        }

        [Test]
         public void SubmitRegistrationForm_WhenMissingLastName()

        {
            //Arrange
            _user.LastName = string.Empty;

            // Act
            _registrationPage.FillRegistrationForm(_user);

            //Assert
            _registrationPage.AssertError_WhenMissingLastName();

        }

        [Test]
        public void SubmitRegistrationForm_WhenMissingLastNameAndCity()
        {
            //Arrange
            _user.LastName = string.Empty;
            _user.City = string.Empty;

            //Act
            _registrationPage.FillRegistrationForm(_user);

            //Assert
            _registrationPage.AssertError_WhenMissingLastNameAndCity();

        }

        [TearDown]
        public void Quit()
        {
            Driver.Quit();
        }

    }
}
