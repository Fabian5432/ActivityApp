using NUnit.Framework;
using Xamarin.UITest;

namespace ActivityAppUITests
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public abstract class BaseTextFixture
    {
        protected IApp App => AppInitializer.App;
        protected bool OnAndroid => AppInitializer.Platform == Platform.Android;
        protected bool OniOS => AppInitializer.Platform == Platform.iOS;
       
        public BaseTextFixture(Platform platform)
        {
            AppInitializer.Platform = platform; 
        }

        [SetUp]
        public virtual void BeforeEachTest()
        {
            AppInitializer.StartApp();
        }
    }
}
