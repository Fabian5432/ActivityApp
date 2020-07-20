using System;
using Xamarin.UITest;

namespace ActivityAppUITests
{
    public class AppInitializer
    {
        private static IApp? app;
        public static IApp App
        {
            get
            {
                if (app == null)
                    throw new NullReferenceException("'AppInitializer.App' not set");
                return app;
            }
        }

        private static Platform? platform;
        public static Platform Platform
        {
            get
            {
                if (platform == null)
                    throw new NullReferenceException("'AppInitializer.Platform' not set.");
                return platform.Value;
            }

            set => platform = value;
        }

        public static void StartApp()
        {
            app =
            platform switch
            {
                Platform.Android =>
                    ConfigureApp
                    .Android
                    .Debug()
                    .EnableLocalScreenshots()
                    .StartApp(),
                Platform.iOS =>
                    ConfigureApp
                    .iOS
                    .Debug()
                    .EnableLocalScreenshots()
                    .StartApp(),
                _ => throw new Exception("Not supported platform")
            };

        }
    }
}
