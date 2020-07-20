using Xamarin.UITest;
using NUnit.Framework;
using ActivityAppUITests.Helper;

namespace ActivityAppUITests.Tests
{
    public class LoginTests: BaseTextFixture
    {
        public LoginTests(Platform platform): base(platform)
        {

        }

        [SetUp]
        public void NavigateToLoginBeforeEachTest() =>
            new Navigation(Po_index).NavigateToLoginPage();

        [Test]
        public void WaitForAllElementsLoginPage()
        {
            // Arrange & Act & Assert
            Po_index.LoginPageObject.WaitForAllElements();
        }

        [Test]
        public void EnterEmail()
        {   // Arrange
            var email_text = "vlasceanufabian96@gmail.com";

            //Act & Assert
            Po_index.LoginPageObject.WaitForAllElements();
            Po_index.LoginPageObject.EnterEmail(email_text);
        }
    }
}
