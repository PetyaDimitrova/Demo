using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;

namespace SeleniumBasics
{
    [TestFixture]
    class InteractionsTest
    {
        IWebDriver driver;
        Actions builder;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            builder = new Actions(driver);
        }

        [Test]
        public void ResizeTheBoxToMaximum()
        {
            driver.Navigate().GoToUrl("http://demoqa.com/resizable");
            driver.Manage().Window.Maximize();

            IWebElement resizableBox = driver.FindElement(By.Id("resizableBoxWithRestriction"));
            IWebElement handle = driver.FindElement(By.XPath("//*[@id='resizableBoxWithRestriction']/span"));

            builder
                .DragAndDropToOffset(handle, 300, 100)
                .Perform();

            var resizableBoxWidthAfter = resizableBox.GetCssValue("width");
            var resizableBoxHeightAfter = resizableBox.GetCssValue("height");

            Assert.AreEqual("500px", resizableBoxWidthAfter);
            Assert.AreEqual("300px", resizableBoxHeightAfter);
        }

        [Test]
        public void ResizeTheBoxToMinimum()
        {
            driver.Navigate().GoToUrl("http://demoqa.com/resizable");
            driver.Manage().Window.Maximize();

            IWebElement resizableBox = driver.FindElement(By.Id("resizableBoxWithRestriction"));
            IWebElement draggableBox = driver.FindElement(By.XPath("//*[@id='resizableBoxWithRestriction']/span"));
            var resizableBoxSizeBefore = resizableBox.Size;

            builder
                .DragAndDropToOffset(draggableBox, -50, -50)
                .Perform();

            var resizableBoxWidthAfter = resizableBox.GetCssValue("width");
            var resizableBoxHeightAfter = resizableBox.GetCssValue("height");
            var resizableBoxSizeAfter = resizableBox.Size;

            Assert.IsFalse(resizableBoxSizeBefore == resizableBoxSizeAfter);
            Assert.AreEqual("150px", resizableBoxWidthAfter);
            Assert.AreEqual("150px", resizableBoxHeightAfter);
        }


        [Test]
        public void SelectAllOptionsInTheList()
        {
            driver.Navigate().GoToUrl("http://demoqa.com/selectable");
            driver.Manage().Window.Maximize();

           ReadOnlyCollection<IWebElement> selectableOptions = driver.FindElements(By.XPath("//*[@id = 'verticalListContainer']/li"));

            var colorOption0Before = selectableOptions[0].GetCssValue("background-color");
            var colorOption1Before = selectableOptions[1].GetCssValue("background-color");
            var colorOption2Before = selectableOptions[2].GetCssValue("background-color");
            var colorOption3Before = selectableOptions[3].GetCssValue("background-color");

            IWebElement scrollThePage = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div/div/div[5]/span/div"));

            selectableOptions[0].Click();
            selectableOptions[1].Click();
            selectableOptions[2].Click();
            builder.MoveToElement(scrollThePage).Perform();
            selectableOptions[3].Click();

            var colorOption0After = selectableOptions[0].GetCssValue("background-color");
            var colorOption1After = selectableOptions[1].GetCssValue("background-color");
            var colorOption2After = selectableOptions[2].GetCssValue("background-color");
            var colorOption3After = selectableOptions[3].GetCssValue("background-color");

            Assert.AreNotEqual(colorOption0Before, colorOption0After);
            Assert.AreNotEqual(colorOption1Before, colorOption1After);
            Assert.AreNotEqual(colorOption2Before, colorOption2After);
            Assert.AreNotEqual(colorOption3Before, colorOption3After);
        }

        [Test]

        public void SelectAnOptionInTheGrid()
        {
            driver.Navigate().GoToUrl("http://demoqa.com/selectable");
            driver.Manage().Window.Maximize();

            IWebElement gridButton = driver.FindElement(By.Id("demo-tab-grid"));
            gridButton.Click();

            IWebElement boxOne = driver.FindElement(By.XPath("//*[@id='row1']/li[1]"));

            var colorBefore = boxOne.GetCssValue("background-color");

            boxOne.Click();

            var colorAfter = boxOne.GetCssValue("background-color");

            Assert.IsTrue(colorBefore != colorAfter);
        }


    [Test]
    public void UnselectAnOptionInTheGrid()
    {
        driver.Navigate().GoToUrl("http://demoqa.com/selectable");
        driver.Manage().Window.Maximize();

        IWebElement gridButton = driver.FindElement(By.Id("demo-tab-grid"));
        gridButton.Click();

        IWebElement boxOne = driver.FindElement(By.XPath("//*[@id='row1']/li[1]"));

            var initialColor = boxOne.GetCssValue("background-color");

            boxOne.Click();

            var colorBeforeUnselecting = boxOne.GetCssValue("background-color");

            boxOne.Click();
            builder.MoveToElement(gridButton).Perform();

            var colorAfterUnselecting = boxOne.GetCssValue("background-color");

            Assert.AreNotEqual(initialColor, colorBeforeUnselecting);
            Assert.AreEqual(initialColor, colorAfterUnselecting);
    }
        [Test]
        public void SortItemsInTheList()
        {
            driver.Navigate().GoToUrl("http://demoqa.com/sortable");
            driver.Manage().Window.Maximize();

           ReadOnlyCollection <IWebElement> listItems = driver.FindElements(By.XPath("//*[@id='demo-tabpane-list']/div/div"));

            String itemOneTextBeforeSorting = listItems[0].Text;
            String itemTwoTextBeforeSorting = listItems[1].Text;

            builder
                .ClickAndHold(listItems[0])
                .MoveToElement(listItems[1])
                .Release()
                .Perform();

            String itemOneTextAfterSorting = listItems[0].Text;
            String itemTwoTextAfterSorting = listItems[1].Text;

            Assert.AreNotEqual(itemOneTextBeforeSorting, itemOneTextAfterSorting);
            Assert.AreNotEqual(itemTwoTextBeforeSorting, itemTwoTextAfterSorting);

            Assert.AreEqual("Two", itemOneTextAfterSorting);
            Assert.AreEqual("One", itemTwoTextAfterSorting);

        }

        [Test]
        public void SortItemsInTheGrid()
        {
            driver.Navigate().GoToUrl("http://demoqa.com/sortable");
            driver.Manage().Window.Maximize();

            IWebElement gridTab = driver.FindElement(By.Id("demo-tab-grid"));
            gridTab.Click();

            ReadOnlyCollection<IWebElement> allItems = driver.FindElements(By.XPath("//*[@id='demo-tabpane-grid']/div/div/div"));
            List<String> allTextsBeforeSorting = new List<String>();

            foreach (IWebElement option in allItems)
            {
                allTextsBeforeSorting.Add(option.Text);
            }

            builder
                .ClickAndHold(allItems[0])
                .MoveToElement(allItems[1])
                .Click()
                .Perform();

            List<String> allTextsAfterSorting = new List<String>();

            foreach (IWebElement option in allItems)
            {
                allTextsAfterSorting.Add(option.Text);
            }

            Assert.AreNotSame(allTextsBeforeSorting, allTextsAfterSorting);
            Assert.AreEqual("Two", allTextsAfterSorting[0]);
            Assert.AreEqual("One", allTextsAfterSorting[1]);

        }

        [Test]
        public void NewTabTest()
        {
            driver.Navigate().GoToUrl("http://demoqa.com/browser-windows");
            driver.Manage().Window.Maximize();

            IWebElement newTabButton = driver.FindElement(By.Id("tabButton"));
            newTabButton.Click();

            String samplePage = driver.WindowHandles.Last();
            var newTab = driver.SwitchTo().Window(samplePage);

            IWebElement header = driver.FindElement(By.Id("sampleHeading"));
            Assert.AreEqual("This is a sample page", header.Text);

            newTab.Close();

        }

        [Test]
        public void ResizeTheBox([Range(99, 100)] int x, [Range(99, 100)] int y)
        {
            driver.Navigate().GoToUrl("http://demoqa.com/resizable");
            driver.Manage().Window.Maximize();

            IWebElement resizableBox = driver.FindElement(By.Id("resizableBoxWithRestriction"));
            IWebElement draggableBox = driver.FindElement(By.XPath("//*[@id='resizableBoxWithRestriction']/span"));

            var resizableBoxWidthBefore = resizableBox.Size.Width; ;
            var resizableBoxHeightBefore = resizableBox.Size.Height; ;

            builder
            .DragAndDropToOffset(draggableBox, x, y)
            .Perform();

            var resizableBoxWidthAfter = resizableBox.Size.Width;
            var resizableBoxHeightAfter = resizableBox.Size.Height;

            Assert.AreEqual(resizableBoxWidthBefore + x, resizableBoxWidthAfter, 3);
            Assert.AreEqual(resizableBoxHeightBefore + y, resizableBoxHeightAfter,3);

        }
    [TearDown]
        public void Quit()
        {
            driver.Quit();
        }
    }
}
