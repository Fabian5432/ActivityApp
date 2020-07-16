using System;
using System.IO;
using NUnit.Framework;
using Xamarin.UITest;

namespace ActivityAppUITests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class BaseTextFixture
    {
        protected IApp App;
        protected bool OnAndroid => _platform == Platform.Android;
        protected bool OniOS => _platform == Platform.iOS;
        private readonly Platform _platform;
       
        public BaseTextFixture(Platform platform)
        {
            _platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            App = AppInitializer.StartApp(_platform);
        }

        [TearDown]
        public void AfterEachTest()
        {
            SaveScreenshot("");
        }

        public void SaveScreenshot(string title)
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var screenshotPath = Path.Combine(basePath, "../../UITestScreenshots");
            var fileInfo = App.Screenshot(title);
            if (File.Exists(screenshotPath))
            {
                File.Delete(screenshotPath);
            }
            fileInfo.MoveTo(screenshotPath);
        }
    }
}
