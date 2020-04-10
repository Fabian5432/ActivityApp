using System.Threading;
using Android.App;
using Android.OS;

namespace App.Activities
{
    [Activity(Label= "@string/app_name", Theme = "@style/MyTheme.Splash", MainLauncher =true, NoHistory =true)]
    public class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Thread.Sleep(1000);
            StartActivity(typeof(MainActivity));
            Finish();
        }
    }
}