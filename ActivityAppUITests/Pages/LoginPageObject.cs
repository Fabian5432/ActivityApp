using System;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace ActivityAppUITests.Pages
{
    public class LoginPageObject: BasePageObject
    {
        private const string SubmitButtonId = "submit";
        private readonly Query SubmitButton;

        public LoginPageObject()
        {
            SubmitButton = x => x.Marked(SubmitButtonId);
        }

        public override void WaitForAllElements()
        {
            WaitForAllElementsLoginPage();
            SaveScreenshot(nameof(WaitForAllElementsLoginPage));
        }

        public void WaitForAllElementsLoginPage()
        {
            app.WaitForElement(SubmitButton);
        }
    }
}
