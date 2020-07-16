using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace ActivityAppUITests.Pages
{
    public class OnboardingPageObject : BasePageObject
    {
        private const string LoginButtonId = "Login";
        private const string RegisterButtonId = "Register";

        public OnboardingPageObject(IApp app) : base(app)
        {
        }

        public override void WaitForAllElements()
        {
            App.WaitForElement(x => x.Marked(LoginButtonId));
            App.WaitForElement(x => x.Marked(RegisterButtonId));
            App.Screenshot(nameof(WaitForAllElements));
        }

        public OnboardingPageObject TapLoginButton()
        {
            App.Tap(x => x.Marked(LoginButtonId));
            return this;
        }

        public OnboardingPageObject TapRegisterButton()
        {
            App.Tap(x => x.Marked(RegisterButtonId));
            return this;
        }
    }
}
