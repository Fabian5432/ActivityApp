using System;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace ActivityAppUITests.Pages
{
    public class LoginPageObject: BasePageObject
    {
        private const string SubmitButtonId = "submit";
        private const string EmailTextImputId = "email";
        private const string EmailEditTextId = "editText";
        private const string PasswordTextImputId = "pass";
        private const string PasswordEditTextId = "password";

        private readonly Query SubmitButton;
        private readonly Query EmailTextInput;
        private readonly Query TextInputEditText;
        private readonly Query PasswordTextImput;
        private readonly Query PasswordEditText;


        public LoginPageObject()
        {
            SubmitButton = x => x.Marked(SubmitButtonId);
            EmailTextInput = x => x.Marked(EmailTextImputId);
            TextInputEditText = x => x.Marked(EmailEditTextId);
            PasswordTextImput = x => x.Marked(PasswordTextImputId);
            PasswordEditText = x => x.Marked(PasswordEditTextId);

        }

        public override void WaitForAllElements()
        {
            WaitForAllElementsLoginPage();
            SaveScreenshot(nameof(WaitForAllElementsLoginPage));
        }

        public void WaitForAllElementsLoginPage()
        {
            App.WaitForElement(SubmitButton);
            App.WaitForElement(EmailTextInput);
            App.WaitForElement(TextInputEditText);
        }

        public LoginPageObject TapLoginButton()
        {
            App.Tap(SubmitButton);
            SaveScreenshot(nameof(TapLoginButton));
            return this;
        }

        public void EnterEmail(string email)
        {
            App.Tap(EmailTextInput);
            App.EnterText(email);
            SaveScreenshot(nameof(EnterEmail));
            
        }

        public void EnterPassword(string password)
        {
            App.Tap(PasswordTextImput);
            App.EnterText(password);
            SaveScreenshot(nameof(EnterPassword));
        }
    }
}
