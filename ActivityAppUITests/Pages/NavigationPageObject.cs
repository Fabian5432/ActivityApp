using System;
namespace ActivityAppUITests.Pages
{
    public class NavigationPageObject
    {
        private OnboardingPageObject _onboardingPageObject;
        private LoginPageObject _loginPageObject;

        public NavigationPageObject()
        {
            _onboardingPageObject = new OnboardingPageObject();
            _loginPageObject = new LoginPageObject();
        }

        public void NavigateToLoginPage()
        {
            _onboardingPageObject.WaitForAllElements();
            _onboardingPageObject.TapLoginButton();
        }

        public void NavigateToRegisterPage()
        {
            _onboardingPageObject.WaitForAllElements();
            _onboardingPageObject.TapRegisterButton();

        }

        public void CompleteOnboarding()
        {
            NavigateToLoginPage();
            _loginPageObject.WaitForAllElements();
        }
    }
}
