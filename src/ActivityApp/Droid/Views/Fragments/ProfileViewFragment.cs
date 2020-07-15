using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using Android.Support.V7.App;
using ActivityApp.Views.Fragments;
using ActivityApp.ViewModel;
using ActivityApp.Views.Fragments.Base;

namespace ActivityApp.Fragments
{
    public class ProfileViewFragment : LoginBaseFragment<LoginViewModel>
    {
        #region Components

        View _view;
        Button _account_settings;
        Button _device_admin;
        TextView _userAccountText;

        #endregion

        #region LifeCycle

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            ((AppCompatActivity)Activity).SupportActionBar.SetTitle(Resource.String.profilePage);

        }
        public static ProfileViewFragment NewInstance()
        {
            var profile_fragment = new ProfileViewFragment { Arguments = new Bundle() };
            return profile_fragment;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            _view = inflater.Inflate(Resource.Layout.profile_page_layout, null);
            _account_settings = (Button)_view.FindViewById(Resource.Id.account_settings);
            _device_admin =(Button)_view.FindViewById(Resource.Id.device_admin);
            _userAccountText = (TextView)_view.FindViewById(Resource.Id.profile_account_textView);

            _userAccountText.Text = ViewModel.GetEmail();
            return _view;
            
        }

        public override void OnResume()
        {
            base.OnResume();
            _account_settings.Click += goSettings;
            _device_admin.Visibility = ViewStates.Gone;
          
        }

        public override void OnPause()
        {
            base.OnPause();
            _account_settings.Click -= goSettings;
            _device_admin.Visibility = ViewStates.Gone;
        }

        private void goSettings(object sender, EventArgs e)
        {
            FragmentTransaction fragmentTransaction = FragmentManager.BeginTransaction();
            AccountSettingsFragment accountSettingsFragment = new AccountSettingsFragment();

            fragmentTransaction.Replace(Resource.Id.content_frame, accountSettingsFragment, "accountSettingsFragment");
            fragmentTransaction.AddToBackStack(null);
            fragmentTransaction.Commit();
        }

        #endregion

    }
}
