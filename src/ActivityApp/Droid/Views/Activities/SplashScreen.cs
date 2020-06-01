using System.Threading;
using Android.App;
using Android.OS;
using ActivityApp.Views.Activities;

namespace ActivityApp.Activities
{
    [Activity(Label= "@string/app_name", NoHistory =true, Theme = "@style/MyTheme.Splash", MainLauncher =true)]
    public class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Thread.Sleep(500);
            StartActivity(typeof(OnboardingActivity));
            Finish();
        }
       }
    }
