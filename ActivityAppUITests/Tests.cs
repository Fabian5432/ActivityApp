using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace ActivityAppUITests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void StartRepl()
        {
            app.Repl();
        }

        [Test]
        public void CompleteRegistration()
        {
            app.Tap(x => x.Marked("Login"));
            app.Tap(x => x.Marked("email"));
            app.EnterText("vlasceanufabian96@gmail.com");
            app.Tap(x => x.Marked("pass"));
            app.EnterText("1Intaimartie");
            app.Tap(x => x.Marked("submit"));
            var el = app.WaitForElement(x => x.Marked("Coffee consumption"));
            Assert.AreEqual("Coffee consumption", el[0].Text);

        }
    }
}
