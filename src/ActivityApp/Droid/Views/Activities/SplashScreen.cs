using Android.App;
using Android.OS;
using ActivityApp.Views.Activities;
using ActivityApp.Helper;

namespace ActivityApp.Activities
{
    [Activity(Label= "@string/app_name", NoHistory =true, Theme = "@style/MyTheme.Splash", MainLauncher =true)]
    public class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Check();
        }

        public void Check()
        {
            if(UserLocalData.logged.Equals("true"))
            {
                StartActivity(typeof(MainActivity));
              
            }
            else
            {
                StartActivity(typeof(OnboardingActivity));
            }
            Finish();
        }
       }
    }
