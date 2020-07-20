using System;
using System.IO;
using Xamarin.UITest;

namespace ActivityAppUITests.Pages
{
    public abstract class BasePageObject
    {
        protected IApp App => AppInitializer.App;
        protected bool OnAndroid => AppInitializer.Platform == Platform.Android;
        protected bool OniOS => AppInitializer.Platform == Platform.iOS;

        protected BasePageObject() { }

        public void SaveScreenshot(string title)
        {
            var fileInfo = App.Screenshot(title);
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var screenshotPath = Path.Combine(basePath, $"../../Reports/{title}");     
            if (File.Exists(screenshotPath))
            {
                File.Delete(screenshotPath);
            }
            fileInfo.MoveTo(screenshotPath);
        }

        public BasePageObject TapOnHardwareBackbutton()
        {
            App.Back();
            return this;
        }

        /// Wait function that will repeatly query the app until all matching elements are found.
        public abstract void WaitForAllElements();
    }
}