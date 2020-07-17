using System;
using System.Runtime.InteropServices;
using Xamarin.UITest;
using NUnit.Framework;
using ActivityAppUITests.Pages;

namespace ActivityAppUITests.Tests
{
    public class LoginTests: BaseTextFixture
    {
        public LoginTests(Platform platform): base(platform)
        {

        }
        [SetUp]
        public void NavigateToLoginBeforeEachTest() =>
            new NavigationPageObject().NavigateToLoginPage();

        [Test]
        public void WaitForAllElementsLoginPage()
        {
            // Arrange 
            var loginPageObject = new LoginPageObject();

            // Act & Assert
            loginPageObject.WaitForAllElements();

        }

    }
}
