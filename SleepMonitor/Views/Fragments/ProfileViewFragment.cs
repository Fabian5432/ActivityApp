using Android.OS;
using Android.Views;

namespace SleepMonitor.Fragments
{
    public class ProfileViewFragment : Android.Support.V4.App.Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }
        public static ProfileViewFragment NewInstance()
        {
            var profile_fragment = new ProfileViewFragment { Arguments = new Bundle() };
            return profile_fragment;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            return inflater.Inflate(Resource.Layout.profile_page_layout, null);
        }
    }
}
