using System.Threading;
using Android.App;
using Android.OS;

namespace App.Activities
{
    [Activity(Label= "@string/app_name", Theme = "@style/MyTheme.Splash", MainLauncher =true)]
    public class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Thread.Sleep(500);
            StartActivity(typeof(LoginActivity));
            //Check();
        }
        
        //private async void Check()
        //{
        //    var c = new LoginService();

        //    if (await c.IsUserloggedinAsync() == true)
        //    {
        //        StartActivity(typeof(MainActivity));
        //    }
        //    else
        //    {
        //        StartActivity(typeof(LoginActivity));
        //    }
        //    Finish();
        //}
    }
}