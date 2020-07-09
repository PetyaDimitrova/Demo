using AutoFixture;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumBasics.Tests.AutomationPractice
{
    public static class UserFactory
    {
        public static RegistrationUser CreateUser()
    {
            var fixture = new Fixture();

            return new RegistrationUser
            {
                FirstName = "Petya",
                LastName = "Dimitrova",
                Password = "123456",
                Address = fixture.Create<string>(),
                City= fixture.Create<string>(),
                ZipCode= "10000",
                State = "Alabama",
                Phone= fixture.Create<int>().ToString()
            };
    }
    }
}
