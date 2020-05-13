using System;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using App.Views.Activities;
using Fragment = Android.Support.V4.App.Fragment;

namespace App.Fragments
{
    public class ProfileViewFragment : Fragment
    {
        #region Components

        View _view;
        Button _account_settings;
        Button _device_admin;

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
            var intent = new Intent(Activity, typeof(AccountSettingsActivity));
            StartActivity(intent);
        }

        #endregion

    }
}
