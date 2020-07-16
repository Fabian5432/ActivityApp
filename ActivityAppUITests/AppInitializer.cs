using System;
using System.IO;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace ActivityAppUITests
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            switch (platform)
            {
                case Platform.Android:
                    {

                        return ConfigureApp.Android
                            .InstalledApp("app.app")
                            .EnableLocalScreenshots()
                            .StartApp();
                    }
                case Platform.iOS:
                    {

                        return ConfigureApp.iOS.EnableLocalScreenshots()
                            .AppBundle("")
                            .StartApp();
                    }
                default:
                    throw new Exception("Unknown platform");
            }
        }
    }
}
