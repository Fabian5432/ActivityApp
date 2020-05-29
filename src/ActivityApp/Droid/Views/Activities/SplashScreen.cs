using System.Threading;
using Android.App;
using Android.OS;
using ActivityApp.Services;
using Plugin.Connectivity;
using ActivityApp.Views.Activities;

namespace ActivityApp.Activities
{
    [Activity(Label= "@string/app_name", NoHistory =true, Theme = "@style/MyTheme.Splash", MainLauncher =true)]
    public class SplashScreen : Activity
    {
        private FirebaseDatabaseHelper firebaseDatabaseHelper;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            firebaseDatabaseHelper = new FirebaseDatabaseHelper(new ServiceLocator().GetFirebaseDatabaseConnection);
            base.OnCreate(savedInstanceState);
            Thread.Sleep(500);
            //StartActivity(typeof(OnboardingActivity));
            //Finish();
            Check();
        }
        
        private async void Check()
        {
           var c = await firebaseDatabaseHelper.GetCurrentUser();

            if (CrossConnectivity.Current.IsConnected)
            {
                if (c.Object.UserStatus.IsLoggedIn == true)
                {
                    StartActivity(typeof(MainActivity));
                }
                else
                {
                    StartActivity(typeof(OnboardingActivity));
                }
                Finish();
            }
            else
            {
                StartActivity(typeof(MainActivity));
                Finish();
            }
  
       }
    }
}