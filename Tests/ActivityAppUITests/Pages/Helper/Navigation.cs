using ActivityAppUITests.Pages.Helper;

namespace ActivityAppUITests.Helper
{
    public class Navigation
    {
        private readonly PageObjectIndex Po_index;
        private const string email = "vlasceanufabian96@gmail.com";
        private const string password = "Parola12345";

        public Navigation(PageObjectIndex po_index)
        {
            Po_index = po_index;
        }

        public void NavigateToLoginPage()
        {
            Po_index.OnboardingPageObject.WaitForAllElements();
            Po_index.OnboardingPageObject.TapLoginButton();
            
        }

        public void NavigateToRegisterPage()
        {
            Po_index.OnboardingPageObject.WaitForAllElements();
            Po_index.OnboardingPageObject.TapRegisterButton();

        }

        public void DoLogin()
        {
            NavigateToLoginPage();
            Po_index.LoginPageObject.WaitForAllElements();
            Po_index.LoginPageObject.EnterEmail(email);
            Po_index.LoginPageObject.EnterPassword(password);
            Po_index.LoginPageObject.TapLoginButton();
        }
    }
}
