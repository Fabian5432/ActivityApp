using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using SleepMonitor.Fragments;
using SleepMonitor.Views.Fragments;

namespace SleepMonitor
{
    [Activity(Label = "@string/app_name", MainLauncher = true, LaunchMode = Android.Content.PM.LaunchMode.SingleTop)]
    public class MainActivity : AppCompatActivity
    {

        BottomNavigationView _bottomNavigationView;

        protected override void OnCreate(Bundle bundle)
        { 
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            _bottomNavigationView = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);

            _bottomNavigationView.NavigationItemSelected += BottomNavigation_NavigationItemSelected;

            LoadFragment(Resource.Id.menu_home);
        }

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
                case Resource.Id.menu_audio:
                    fragment = ProfileViewFragment.NewInstance();
                    break;
                case Resource.Id.menu_video:
                    fragment = SettingViewfragment.NewInstance();
                    break;
            }
            if (fragment == null)
                return;

            SupportFragmentManager.BeginTransaction()
               .Replace(Resource.Id.content_frame, fragment)
               .Commit();
        }

    }
}
