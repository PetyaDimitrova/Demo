using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SeleniumBasics
{
    [TestFixture]
    class DroppableTests
    {
        IWebDriver driver;
        Actions builder;
        string driverURL = "http://demoqa.com/droppable";

         [SetUp]
         public void SetUp()
        {
            driver = new ChromeDriver();
            builder = new Actions(driver);
            driver.Navigate().GoToUrl(driverURL);
            driver.Manage().Window.Maximize();
        } 
        [Test]
        public void CheckTheColorWhenDragAndDrop()
        {
            IWebElement draggableBox = driver.FindElement(By.Id("draggable"));
            IWebElement droppableBox = driver.FindElement(By.Id("droppable"));

            var droppableBoxColorBefore = droppableBox.GetCssValue("background-color");

            builder
                .DragAndDrop(draggableBox, droppableBox)
                .Perform();

            Thread.Sleep(5);
            var droppableBoxColorAfter = droppableBox.GetCssValue("background-color");

            Assert.AreNotEqual(droppableBoxColorBefore, droppableBoxColorAfter);
        }

        [Test]

        public void CheckTheTextWhenDragAndDrop()
        {
            IWebElement draggableBox = driver.FindElement(By.Id("draggable"));
            IWebElement droppableBox = driver.FindElement(By.Id("droppable"));

            // drag and drop using different methods 
            builder
                .ClickAndHold(draggableBox)
                .MoveToElement(droppableBox)
                .Release()
                .Perform();

            String droppableBoxTextAfter = droppableBox.Text;

            Assert.AreEqual("Dropped!", droppableBoxTextAfter);

        }

        [TearDown]
        public void Quit()
        {
            driver.Quit();
        }

    }
}
