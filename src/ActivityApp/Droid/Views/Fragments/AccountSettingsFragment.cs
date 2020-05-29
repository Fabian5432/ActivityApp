using System;
using ActivityApp.ViewModel;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using ActivityApp.Views.Activities;
using ActivityApp.Views.Fragments.Base;

namespace ActivityApp.Views.Fragments
{
    public class AccountSettingsFragment : LoginBaseFragment<LoginViewModel>
    {
        #region Components

        private View _view;
        private Button _changePasswordButton;
        private Button _logoutButton;
        #endregion

        #region LifeCycle

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            ((AppCompatActivity)Activity).SupportActionBar.SetTitle(Resource.String.accountSettings);

        }
        public static AccountSettingsFragment NewInstance()
        {
            var account_settings_fragment = new AccountSettingsFragment { Arguments = new Bundle() };
            return account_settings_fragment;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            _view = inflater.Inflate(Resource.Layout.account_settings_fragment_layout, null);
            _changePasswordButton = (Button)_view.FindViewById(Resource.Id.change_password_button);
            _logoutButton = (Button)_view.FindViewById(Resource.Id.logout_button);
            return _view;
        }

        public override void OnResume()
        {
            base.OnResume();
            _changePasswordButton.Click += goChangePassword;
            _logoutButton.Click += Logout;
        }

        public override void OnPause()
        {
            base.OnPause();
            _changePasswordButton.Click -= goChangePassword;
            _logoutButton.Click -= Logout;

        }

        #endregion

        #region Methods 

        private void goChangePassword(object sender, EventArgs e)
        {
            var intent = new Intent(Activity, typeof(ChangePasswordActivity));
            StartActivity(intent);
        }

        private void Logout(object sender, EventArgs e)
        {
            ViewModel.Logout();
            var intent = new Intent(Activity, typeof(OnboardingActivity));
            StartActivity(intent);
            Activity.Finish();
        }

        #endregion


    }
}
