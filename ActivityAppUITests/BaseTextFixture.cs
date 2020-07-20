using System;
using ActivityAppUITests.Pages.Helper;
using NUnit.Framework;
using Xamarin.UITest;

namespace ActivityAppUITests
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public abstract class BaseTextFixture
    {
        private PageObjectIndex? po_index;
        protected PageObjectIndex Po_index
        {
            get
            {
                if (po_index == null)
                    throw new NullReferenceException("'Po_index' not set");
                return po_index;
            }
            set => po_index = value;

        }
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
            Po_index = new PageObjectIndex();
        }
    }
}
