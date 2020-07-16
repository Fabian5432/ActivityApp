using System;
using Xamarin.UITest;
using NUnit.Framework;
using ActivityAppUITests.Pages;

namespace ActivityAppUITests.Tests
{
    public class OnboardingTests: BaseTextFixture
    {
        public OnboardingTests(Platform platform) : base(platform)
        {
        }

        [Test]
        public void StartRepl()
        {
            App.Repl();
        }

        [Test]
        public void WaitForAllElements()
        {
            OnboardingPageObject onboardingPageObject = new OnboardingPageObject(App);
            onboardingPageObject.WaitForAllElements();
        }

    }
}
