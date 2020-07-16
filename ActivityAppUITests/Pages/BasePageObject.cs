using Xamarin.UITest;

namespace ActivityAppUITests.Pages
{
    public abstract class BasePageObject
    {
        protected IApp App { get; }

        protected BasePageObject(IApp app)
        {
            App = app;
            App.Screenshot($"On {this.GetType().Name}");
        }

        public void Repl() => App.Repl();

        public BasePageObject TapOnHardwareBackbutton()
        {
            App.Back();
            return this;
        }

        /// <summary>
        /// Wait function that will repeatly query the app until all matching elements are found.
        /// </summary>
        public abstract void WaitForAllElements();
    }
}