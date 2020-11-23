using Android.App;
using Android.OS;
using ActivityApp.Views.Activities;
using Xamarin.Essentials;
using Android.Content;
using System.Threading.Tasks;
using ActivityApp.Services.Interfaces;

namespace ActivityApp.Activities
{
    [Activity(Label = "@string/app_name", NoHistory = true, Theme = "@style/MyTheme.Splash", MainLauncher = true)]
    public class SplashScreen : Activity
    {
        private readonly ILoginService _loginService; 

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            await CheckAsync();

            Finish();
        }

        public async Task CheckAsync()
        {
            if(await SecureStorage.GetAsync("token")!=null)
            {
                var intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            }
            else
            {
                var intent = new Intent(this, typeof(OnboardingActivity));
                StartActivity(intent);
            }
        }

    }
}