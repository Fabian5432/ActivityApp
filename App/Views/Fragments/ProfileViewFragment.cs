using Android.OS;
using Android.Support.V7.App;
using Android.Views;

namespace App.Fragments
{
    public class ProfileViewFragment : Android.Support.V4.App.Fragment
    {
        #region Components

        View _view;

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
            return _view;
        }

        #endregion

    }
}
