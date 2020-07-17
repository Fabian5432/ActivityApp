using System;
using System.IO;
using Xamarin.UITest;

namespace ActivityAppUITests.Pages
{
    public abstract class BasePageObject
    {
        protected IApp app => AppInitializer.App;
        protected bool OnAndroid => AppInitializer.Platform == Platform.Android;
        protected bool OniOS => AppInitializer.Platform == Platform.iOS;

        protected BasePageObject()
        {
            app.Screenshot($"On {this.GetType().Name}");
        }

        public void SaveScreenshot(string title)
        {
            var fileInfo = app.Screenshot(title);
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
            app.Back();
            return this;
        }

        /// <summary>
        /// Wait function that will repeatly query the app until all matching elements are found.
        /// </summary>
        public abstract void WaitForAllElements();
    }
}