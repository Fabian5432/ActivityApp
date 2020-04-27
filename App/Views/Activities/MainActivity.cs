using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using App.Fragments;
using App.Views.Fragments;

namespace App.Activities
{
    [Activity(Label = "@string/app_name", MainLauncher = false, LaunchMode = Android.Content.PM.LaunchMode.SingleTop)]
    public class MainActivity : AppCompatActivity
    {
        #region Components

        BottomNavigationView _bottomNavigationView;

        #endregion

        #region LifeCycle

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            _bottomNavigationView = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);

            _bottomNavigationView.NavigationItemSelected += BottomNavigation_NavigationItemSelected;

            LoadFragment(Resource.Id.menu_home);
        }

        #endregion

        #region Methods 

        private void BottomNavigation_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            LoadFragment(e.Item.ItemId);
        }

        void LoadFragment(int id)
        {
            Android.Support.V4.App.Fragment fragment = null;
            switch (id)
            {
                case Resource.Id.menu_home:
                    fragment = MainPageViewFragment.NewInstance();
                    break;
                case Resource.Id.menu_history:
                    fragment = HistoryViewFragment.NewInstance();
                    break;
                case Resource.Id.menu_profile:
                    fragment = ProfileViewFragment.NewInstance();
                    break;
            }
            if (fragment == null)
                return;

           SupportFragmentManager.BeginTransaction()
               .Replace(Resource.Id.content_frame, fragment)
               .Commit();
        }

        #endregion
    }
}
