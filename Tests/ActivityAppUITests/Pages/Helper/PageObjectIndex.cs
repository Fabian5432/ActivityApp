using System;

namespace ActivityAppUITests.Pages.Helper
{
    public class PageObjectIndex
    {
        #region Properties

        private OnboardingPageObject? onboardingPageObject;
        public OnboardingPageObject OnboardingPageObject
        {
            get
            {
                if (onboardingPageObject == null)
                    throw new NullReferenceException(message: "'OnboardingPageObject' not set");
                return onboardingPageObject;
            }
            set => onboardingPageObject = value;

        }
        private LoginPageObject? loginPageObject;
        public LoginPageObject LoginPageObject {
            get
            {
                if (loginPageObject == null)
                    throw new NullReferenceException(message: "'LoginPageObject' not set");
                return loginPageObject;
            }
            set => loginPageObject = value;
        }

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
