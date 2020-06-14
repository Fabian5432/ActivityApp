using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using Fragment = Android.Support.V4.App.Fragment;
using ActivityApp.Views.Fragments;
using ActivityApp.Fragments;

namespace ActivityApp.Activities
{
    [Activity(Label = "@string/app_name", MainLauncher = false, ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {
        #region Components

        BottomNavigationView _bottomNavigationView;
        private Fragment _homeFragment;
        private Fragment _historyFragment;
        private Fragment _profileFragment;

        #endregion

        #region LifeCycle

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            _bottomNavigationView = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);

            _homeFragment = MainPageViewFragment.NewInstance();
            _historyFragment = HistoryViewFragment.NewInstance();
            _profileFragment = ProfileViewFragment.NewInstance();

            LoadFragment(Resource.Id.menu_home);
        }

        protected override void OnResume()
        {
            base.OnResume();
            _bottomNavigationView.NavigationItemSelected += BottomNavigation_NavigationItemSelected;
            
        }

        protected override void OnPause()
        {
            base.OnPause();
            _bottomNavigationView.NavigationItemSelected -= BottomNavigation_NavigationItemSelected;
        }

        #endregion

        #region Methods 

        private void BottomNavigation_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            LoadFragment(e.Item.ItemId); 
        }

        void LoadFragment(int id)
        {
            Fragment fragment = null;
            switch (id)
            { 
                case Resource.Id.menu_home:
                    fragment = _homeFragment;
                    break;
                case Resource.Id.menu_history:
                    fragment = _historyFragment;
                    break;
                case Resource.Id.menu_profile:
                    fragment = _profileFragment;
                    break;
            }
            if (fragment == null)
                return;

            ReplaceFragment(fragment);
        }

        public void ReplaceFragment(Fragment fragment)
        {
            SupportFragmentManager.BeginTransaction()
                                  .Replace(Resource.Id.content_frame, fragment)
                                  .Commit();
        }

        #endregion
    }
}
