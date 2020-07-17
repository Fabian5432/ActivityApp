using System.Linq;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace ActivityAppUITests.Pages
{   
    public class OnboardingPageObject : BasePageObject
    { 
        private const string LoginButtonId = "go_to_login_button";
        private const string RegisterButtonId = "go_to_register_button";
        private const string WelcomeTextId = "welcome_text_title";
        private const string ContentId = "content";

        private readonly Query Content;
        private readonly Query LoginButton;
        private readonly Query RegisterButton;
        private readonly Query WelcomeText;

        public OnboardingPageObject()
        {
            Content = x => x.Marked(ContentId);

            LoginButton = x => x.Marked(LoginButtonId);
            RegisterButton = x => x.Marked(RegisterButtonId);
            WelcomeText = x => x.Marked(WelcomeTextId);
        }

        public override void WaitForAllElements()
        {
            WaitForAllElementsOnboardingage();

            SaveScreenshot(nameof(WaitForAllElementsOnboardingage));

        }

        public void WaitForAllElementsOnboardingage()
        {
            app.WaitForElement(Content);

            app.WaitForElement(LoginButton);
            app.WaitForElement(RegisterButton);
            app.WaitForElement(WelcomeTextId);
        }

        public OnboardingPageObject TapLoginButton()
        {
            app.Tap(x => x.Marked(LoginButtonId));
            SaveScreenshot(nameof(TapLoginButton));
            return this;
        }

        public OnboardingPageObject TapRegisterButton()
        {
            app.Tap(x => x.Marked(RegisterButtonId));
            SaveScreenshot(nameof(TapRegisterButton));
            return this;
        }

        public string GetLoginButtonText()
        {
            var result = app.Query(LoginButton).FirstOrDefault().Text;
            SaveScreenshot(nameof(GetLoginButtonText));

            return result;
        }

        public string GetRegisterButtonText()
        {
            var result = app.Query(RegisterButton).FirstOrDefault().Text;
            SaveScreenshot(nameof(GetRegisterButtonText));

            return result;
        }
    }
}
