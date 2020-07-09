using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SeleniumBasics.Pages.HomePage
{
   public partial class HomePage : BasePage
    {
      public ReadOnlyCollection<IWebElement> NavigationOptions => Wait.Until(d => d.FindElements(By.XPath("//*[@id='app']/div/div/div[2]/div/div")));
       public IWebElement Header => Wait.Until(d => d.FindElement(By.XPath("//*[@id='app']/div/div/div[1]")));
    }
}
