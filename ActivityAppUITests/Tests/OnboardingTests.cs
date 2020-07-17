using Xamarin.UITest;
using NUnit.Framework;
using ActivityAppUITests.Pages;

namespace ActivityAppUITests.Tests
{
    public class OnboardingTests : BaseTextFixture
    {
        public OnboardingTests(Platform platform) : base(platform)
        {
        }

        [Test]
        public void Onboarding_WaitForAllElements()
        {   // Arrange 
            var onboardingPageObject = new OnboardingPageObject();

            // Act & Assert
            onboardingPageObject.WaitForAllElements();
        }

        [Test]
        public void Onboarding_VerifyLoginButtonText()
        {
            // Arrange 
            var onboardingPageObject = new OnboardingPageObject();
            onboardingPageObject.WaitForAllElements();

            var expected_login_button_text = "Login";

            // Act
            var actual_result = onboardingPageObject.GetLoginButtonText();

            // Assert
            Assert.AreEqual(expected_login_button_text, actual_result);
        }

        [Test]
        public void Onboarding_VerifyRegisterButtonText()
        {
            // Arrange 
            var onboardingPageObject = new OnboardingPageObject();
            onboardingPageObject.WaitForAllElements();

            var expected_register_button_text = "Register";

            // Act
            var actual_result = onboardingPageObject.GetRegisterButtonText();

            // Assert
            Assert.AreEqual(expected_register_button_text, actual_result);
        }

        [Test]
        [Ignore("Ignore a test")]
        public void StartRepl()
        {
            App.Repl();
        }
    }
}
