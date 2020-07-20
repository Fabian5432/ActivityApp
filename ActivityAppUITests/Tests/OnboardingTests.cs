using Xamarin.UITest;
using NUnit.Framework;

namespace ActivityAppUITests.Tests
{
    public class OnboardingTests : BaseTextFixture
    {
        public OnboardingTests(Platform platform) : base(platform)
        {
        }

        [Test]
        public void Onboarding_WaitForAllElements()
        {
            // Arrange & Act & Assert
            Po_index.OnboardingPageObject.WaitForAllElements();
        }

        [Test]
        public void Onboarding_VerifyLoginButtonText()
        {
            // Arrange 
            Po_index.OnboardingPageObject.WaitForAllElements();

            var expected_login_button_text = "Login";

            // Act
            var actual_result = Po_index.OnboardingPageObject.GetLoginButtonText();

            // Assert
            Assert.AreEqual(expected_login_button_text, actual_result);
        }

        [Test]
        public void Onboarding_VerifyRegisterButtonText()
        {
            // Arrange 
            Po_index.OnboardingPageObject.WaitForAllElements();

            var expected_register_button_text = "Register";

            // Act
            var actual_result = Po_index.OnboardingPageObject.GetRegisterButtonText();

            // Assert
            Assert.AreEqual(expected_register_button_text, actual_result);
        }

        [Test]
        //[Ignore("Ignore a test")]
        public void StartRepl()
        {
            App.Repl();
        }
    }
}
