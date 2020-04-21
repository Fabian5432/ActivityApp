using System;
using System.Threading;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Text;
using Android.Views;
using Android.Widget;
using App.Activities;
using App.ViewModel;
using App.Views.Fragments.Base;

namespace App.Views.Fragments
{
    public class LoginFragment : LoginBaseFragment<LoginViewModel>
    {
        private View _view;
        private TextInputEditText _email;
        private TextInputEditText _password;
        private ProgressBar _progressBar;
        private Button _login;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your fragment here
        }
        public static LoginFragment NewInstance()
        {
            var setting_fragment = new LoginFragment { Arguments = new Bundle() };
            return setting_fragment;
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            _view = inflater.Inflate(Resource.Layout.login_fragment_layout, null);
            _login = (Button)_view.FindViewById(Resource.Id.submit);
            _email = (TextInputEditText)_view.FindViewById(Resource.Id.editText);
            _progressBar = (ProgressBar)_view.FindViewById(Resource.Id.progressBar);
            _password = (TextInputEditText)_view.FindViewById(Resource.Id.password);

            _progressBar.Visibility = ViewStates.Gone;

            _email.TextChanged += EmailOnTextChanged;
            _password.TextChanged += PasswordOnTextChanged;

            return _view;
        }

        public  override void OnResume()
        {
            base.OnResume();
            _login.Click += LoginButtonClick;

        }

        public override void OnPause()
        {
            base.OnPause();
            _login.Click -= LoginButtonClick;
        }

        private void EmailOnTextChanged(object sender, TextChangedEventArgs e)
        {
            ViewModel.Email = _email.Text;
        }

        private void PasswordOnTextChanged(object sender, EventArgs e)
        {
            ViewModel.Password = _password.Text;
        }

        public async void LoginButtonClick(object sender, EventArgs e)
        {
            ViewModel.Email = _email.Text;
            ViewModel.Password = _password.Text;

            if(!ViewModel.isLoggedIn)
                return;

            try
            {
                await ViewModel.LoginAsync();
                _progressBar.Visibility = ViewStates.Visible;
                var intent = new Intent(Activity, typeof(MainActivity));
                StartActivity(intent);
            }
            catch (Exception ex)
            {
                var builder = new AlertDialog.Builder(Context);
                builder.SetTitle("Login failed");
                builder.SetMessage(ex.Message);
                builder.SetPositiveButton("Ok", (sender, e) => { });

                AlertDialog alertDialog = builder.Create();
                alertDialog.Show();
            }

        }
    }
}