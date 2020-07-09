using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SeleniumBasics.Pages
{
   public partial class RegistrationPage : BasePage
    {
        public ReadOnlyCollection<IWebElement> ErrorMessage => Driver.FindElements(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/ol/li"));

        public void AssertErrorWhenMissingPhoneAndState()
        {
            Assert.AreEqual(2, ErrorMessage.Count);
            Assert.AreEqual("You must register at least one phone number.", ErrorMessage[0].Text);
            Assert.AreEqual("This country requires you to choose a State.", ErrorMessage[1].Text);
 
        }

        public void AssertError_WhenMissingLastName()
        {
            Assert.AreEqual(1, ErrorMessage.Count);
            Assert.AreEqual("lastname is required.", ErrorMessage[0].Text);
        }

        public void AssertError_WhenMissingLastNameAndCity()
        {
            Assert.AreEqual(2, ErrorMessage.Count);
            Assert.AreEqual("lastname is required.", ErrorMessage[0].Text);
            Assert.AreEqual("city is required.", ErrorMessage[1].Text);
        }

    }
}
