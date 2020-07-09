using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumBasics.Tests.DemoQA;
//using SeleniumBasics.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;

namespace SeleniumBasics
{
    
   [TestFixture]
    class DraggableTests
    {
        IWebDriver driver;
        Actions builder;
        WebDriverWait wait;
        string driverURL = "http://demoqa.com/";


        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            builder = new Actions(driver);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));

            driver.Navigate().GoToUrl(driverURL);
            driver.Manage().Window.Maximize();

            //Click on Interactions button
            IWebElement interactionsButton = driver.FindElement(By.XPath("//*[@id='app']/div/div/div[2]/div/div[5]"));
            interactionsButton.Click();
   
            ReadOnlyCollection<IWebElement> interactionOptions = wait.Until(d => d.FindElements(By.XPath("/html/body/div/div/div/div[2]/div[1]/div/div/div[5]/div/ul/li")));
            //driver.ScrollTo(interactionOptions[4]);
            interactionOptions[4].Click();
        }

        [Test]
        public void DragAndCheckPosition_Test1()
        {
            IWebElement draggableBox = driver.FindElement(By.Id("dragBox"));

            double draggableBoxPositionXBefore = draggableBox.Location.X;
            double dragableBoxPositionYBefore = draggableBox.Location.Y;

            builder
                .DragAndDropToOffset(draggableBox, 20, 30)
                .Perform();

            double draggableBoxPositionXAfter = draggableBox.Location.X; 
            double dragableBoxPositionYAfter = draggableBox.Location.Y; 

            Assert.AreEqual(draggableBoxPositionXBefore + 20, draggableBoxPositionXAfter, 3);
            Assert.AreEqual(dragableBoxPositionYBefore + 30, dragableBoxPositionYAfter, 3);

        }

        [Test]
        public void DragAtTheLeftCorner()
        {
            IWebElement draggableBox = driver.FindElement(By.Id("dragBox"));

            builder
                .ClickAndHold(draggableBox)
                .MoveByOffset(100, 150)
                .Perform();

            double draggableBoxPositionX = draggableBox.Location.X;
            double draggableBoxPositionY = draggableBox.Location.Y;


            // Assert.IsTrue(draggableBoxPositionX == 453);
            //Assert.IsTrue(draggableBoxPositionY == 444);

            Assert.AreEqual(518, draggableBoxPositionX, 3);
            Assert.AreEqual(444, draggableBoxPositionY, 3);
        }

        [Test]

        public void DragOnTheHeader()
        {
            IWebElement draggableBox = driver.FindElement(By.Id("dragBox"));
            IWebElement header = driver.FindElement(By.XPath("//*[@id='app']/header/a/img"));

            builder
                .ClickAndHold(draggableBox)
                .MoveToElement(header)
                .Perform();

            double draggableBoxPositionX = draggableBox.Location.X;
            double draggableBoxPositionY = draggableBox.Location.Y;


            Assert.AreEqual(709, draggableBoxPositionX, 3);
            Assert.AreEqual(30, draggableBoxPositionY, 3);
        }

        [Test]
        public void DragToCordinatesZero()
        {
            IWebElement draggableBox = driver.FindElement(By.Id("dragBox"));

            int draggableBoxPositionX = draggableBox.Location.X;
            int draggableBoxPositionY = draggableBox.Location.Y;

            builder
                .DragAndDropToOffset(draggableBox,-draggableBoxPositionX, -draggableBoxPositionY)
                .Perform();

            int draggableBoxPositionXAfter = draggableBox.Location.X;
            int draggableBoxPositionYAfter = draggableBox.Location.Y;

            Assert.AreEqual(0, draggableBoxPositionXAfter);
            Assert.AreEqual(0, draggableBoxPositionYAfter);
        }

        [TearDown]
        public void Quit()
        {
            driver.Quit();
        }
    }
}
