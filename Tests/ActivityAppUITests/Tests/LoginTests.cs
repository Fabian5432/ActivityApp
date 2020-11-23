using Xamarin.UITest;
using ActivityAppUITests.Helper;
using TestStack.BDDfy;
using NUnit.Framework;

namespace ActivityAppUITests.Tests
{
   [Story(
        AsA = "As a user ",
        IWant = "I want to navigate to login page",
        SoThat = "So that I can login with my credentials")]
    public class LoginTests: BaseTextFixture
    {
        public LoginTests(Platform platform): base(platform)
        {

        }

        [Given("Given I'm on login page")]
        public void WaitForAllElementsLoginPage()
        {
            // Arrange & Act & Assert
            new Navigation(Po_index).NavigateToLoginPage();
            Po_index.LoginPageObject.WaitForAllElements();

            Assert.That(2, Is.EqualTo(2));
        }

        [Test]
        public void Execute()
        {
            this.BDDfy();
        }
    }
}
