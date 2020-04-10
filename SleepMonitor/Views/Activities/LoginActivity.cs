using System;
using Android.App;
using Android.OS;
using Android.Widget;

namespace App.Activities
{
    [Activity(Label = "@string/app_name")]
    public class LoginActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.login_page_layout);
            Button login = FindViewById<Button>(Resource.Id.submit);

            login.Click += (object sender, EventArgs e) => {
                Android.Widget.Toast.MakeText(this, "Succesfully logged in", ToastLength.Short).Show();
                StartActivity(typeof(MainActivity));
            };
        }

    }
}