using System;
using Android.Views;
using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Widget;
using App.Services;
using System.Threading;
using System.Threading.Tasks;

namespace App.Activities
{
    [Activity(Label = "@string/app_name", NoHistory =true)]
    public class LoginActivity : Activity
    {
        #region Fields

        private TextInputEditText _email;
        private TextInputEditText _password;
        private ProgressBar _progressBar;
        private RepositoryServices d;
        private Button _login;


        #endregion

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            SetContentView(Resource.Layout.login_page_layout);
            _login = FindViewById<Button>(Resource.Id.submit);
            _email = FindViewById<TextInputEditText>(Resource.Id.editText);
            _progressBar = FindViewById<ProgressBar>(Resource.Id.progressBar);
            _password = FindViewById<TextInputEditText>(Resource.Id.password);
            _progressBar.Visibility = ViewStates.Invisible;

            var d = new RepositoryServices();
            
        }

        protected override void OnResume()
        {
            base.OnResume();
            _login.Click += buttonClick;
            
        }

        protected override void OnPause()
        {
            base.OnPause();
            _login.Click -= buttonClick;
        }


        bool buttonClicked = false;
        public async void buttonClick(object sender, EventArgs e)
        {
            var d = ServiceLocator.GetLoginService;
            var c = ServiceLocator.GetRepositoryService;
       
            buttonClicked = true;
            await d.Login(_email.Text, _password.Text, buttonClicked);
            //await c.AddData(_email.Text, _password.Text, buttonClicked);
            Thread.Sleep(1000);
            _progressBar.Visibility = ViewStates.Visible;
            Toast.MakeText(this, "Succesfully logged in", ToastLength.Short).Show();
            StartActivity(typeof(MainActivity));
        }
    }
}