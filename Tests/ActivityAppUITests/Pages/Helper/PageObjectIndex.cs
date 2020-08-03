using System;

namespace ActivityAppUITests.Pages.Helper
{
    public class PageObjectIndex
    {
        #region Properties

        public OnboardingPageObject OnboardingPageObject {  get; set; }
        public LoginPageObject LoginPageObject { get; set; }

        #endregion

        #region Constructor

        public PageObjectIndex()
        {
            LoginPageObject = new LoginPageObject();
            OnboardingPageObject = new OnboardingPageObject();
        }

        #endregion
    }
}
