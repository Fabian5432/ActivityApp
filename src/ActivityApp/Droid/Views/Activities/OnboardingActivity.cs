using ActivityApp.Activities;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using System;

namespace ActivityApp.Views.Activities
{
    [Activity(Label = "OnboardingActivity", LaunchMode = Android.Content.PM.LaunchMode.SingleTop, Theme = "@style/NoActionBar")]
    public class OnboardingActivity : AppCompatActivity
    {
        #region Components

        private Button _loginButton;
        private Button _registerButton;

        #endregion
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.onboarding_page_layout);

            _loginButton = FindViewById<Button>(Resource.Id.go_to_login_button);
            _registerButton = FindViewById<Button>(Resource.Id.go_to_register_button);

            // Create your application here
        }

        protected override void OnResume()
        {
            base.OnResume();
            _loginButton.Click += GotoLogin;
            _registerButton.Click += GotoRegister;
        }

        protected override void OnPause()
        {
            base.OnPause();
            _loginButton.Click -= GotoLogin;
            _registerButton.Click -= GotoRegister;

        }

        private void GotoLogin(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(LoginActivity));
            StartActivity(intent);
        }

        private void GotoRegister(object snder, EventArgs e)
        {
            var intent = new Intent(this, typeof(RegisterActivity));
            StartActivity(intent);
        }
    }
}