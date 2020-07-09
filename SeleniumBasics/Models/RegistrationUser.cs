using OpenQA.Selenium.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumBasics.Tests.AutomationPractice
{
   public class RegistrationUser
    {
        public string FirstName { get; set; } //set <- factory
        public string LastName { get; set; }
        public string Password { get; set; }    
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }
  
    }
}
