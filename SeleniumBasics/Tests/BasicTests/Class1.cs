using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
//using SeleniumBasics.Utilities;
using System;
using System.Collections.ObjectModel;
using System.Threading;

namespace SeleniumBasics
{
    [TestFixture]
    public class MyFirstTests
    {
       private IWebDriver driver;
       private WebDriverWait wait;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20)); 
        }

        [TearDown]
        public void BrowserQuit()
        {
            //driver.Quit();
        }

        [Test]
        public void SearchInGoogleForSelenuim()
        {
            driver.Url = "https://google.com";
            IWebElement searchField = driver.FindElement(By.XPath("//*[@id='tsf']/div[2]/div[1]/div[1]/div/div[2]/input"));
            searchField.SendKeys("Selenuim");

            IWebElement searchButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='tsf']/div[2]/div[1]/div[2]/div[2]/div[2]/center/input[1]")));
                //driver.FindElement(By.XPath("//*[@id='tsf']/div[2]/div[1]/div[2]/div[2]/div[2]/center/input[1]"));
            searchButton.Click();
            

            IWebElement seleniumResult = wait.Until<IWebElement>(d => d.FindElement(By.XPath("/html/body/div[6]/div[2]/div[9]/div[1]/div[2]/div/div[2]/div[2]/div/div/div[1]/div/div[1]/a/h3")));
            seleniumResult.Click();

            Assert.AreEqual("https://www.selenium.dev/", driver.Url);
            Assert.AreEqual("SeleniumHQ Browser Automation", driver.Title);

        }

        [Test]
        public void NavigateToQaAutomation()
        {
            driver.Url = "https://www.softuni.bg";
            IWebElement trainingMenu = wait.Until<IWebElement>(d => d.FindElement(By.XPath("/html/body/div[1]/div[1]/header/nav/div[1]/ul/li[2]/a/span")));               
            trainingMenu.Click();

            IWebElement qaCourse = wait.Until<IWebElement>(d => d.FindElement(By.XPath("/html/body/div[1]/div[1]/header/nav/div[1]/ul/li[2]/div/div/div[2]/div[2]/div/div[1]/ul[2]/div[1]/ul/li/a")));
            qaCourse.Click();

            IWebElement headerQaAutomationPage = wait.Until<IWebElement>(d => d.FindElement(By.XPath("/html/body/div[2]/header/h1")));

            Assert.AreEqual("QA Automation - май 2020", headerQaAutomationPage.Text);
            Assert.AreEqual("h1", headerQaAutomationPage.TagName);

        }

        [Test]
        public void AutomationPracticeRegistration()
        {
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");

            IWebElement signInLink = wait.Until<IWebElement>(d => d.FindElement(By.XPath("//*[@id='header']/div[2]/div/div/nav/div[1]/a")));
            signInLink.Click();

            IWebElement emailField =
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/div[1]/form/div/div[2]/input[@id ='email_create']")));
               
             emailField.Click();
             emailField.SendKeys("petyad86@gmail.com");

             IWebElement submitButton = driver.FindElement(By.XPath("//*[@id='SubmitCreate']/span"));
             submitButton.Click();

            IWebElement emailRegistrationForm = 
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/form/div[1]/div[4]/input")));
                
             Assert.AreEqual("petyad86@gmail.com", emailRegistrationForm.GetAttribute("value"));

        }

        [Test]
        public void GoToQADemo()
        {
            driver.Navigate().GoToUrl("http://demoqa.com/");
            driver.Manage().Window.Maximize();

            IWebElement interactionsButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='app']/div/div/div[2]/div/div[5]")));
            interactionsButton.Click();

            ReadOnlyCollection<IWebElement> interactionOptions = wait.Until(d => d.FindElements(By.XPath("/html/body/div/div/div/div[2]/div[1]/div/div/div[5]/div/ul/li")));
       
           // driver.ScrollTo(interactionOptions[3]);
            interactionOptions[3].Click();

        }

    }
}
